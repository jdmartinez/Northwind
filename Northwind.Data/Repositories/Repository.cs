#region Licencia
/*
   Copyright 2013 Juan Diego Martinez

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

*/        
#endregion
          
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using ServiceStack;
using ServiceStack.OrmLite;
using Northwind.Data;
using Northwind.Data.Model;
using ServiceStack.Data;

namespace Northwind.Data.Repositories
{
	/// <summary>
	/// Clase que representa un repositorio
	/// </summary>
	public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity, new()
	{
		#region Campos

		/// <summary>
		/// Primer elemento de la lista por defecto
		/// </summary>
		public const int DefaultOffset = 1;

		/// <summary>
		/// Número de elementos por defecto
		/// </summary>
		public const int DefaultLimit = 100;

		private int offset = DefaultOffset;
		private int limit = DefaultLimit;

		#endregion

		#region Propiedades

		/// <summary>
		/// Conexión a la base de datos
		/// </summary>
		protected IDbConnectionFactory dbFactory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Offset
		{
			get { return offset; }
			set { offset = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public int Limit
		{
			get { return limit; }
			set { limit = value; }
		}
		
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="factory">Conexión</param>
		public Repository( IDbConnectionFactory factory )
		{
			dbFactory = factory;
		}
		#endregion

		#region Miembros de IRepository<TEntity>

		/// <summary>
		/// Añade la entidad TEntity a la base de datos
		/// </summary>
		/// <param name="entity">Entidad a añadir</param>	
		public TEntity Add( TEntity entity )
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{                
				db.Insert(entity);

				// Hay que asegurarse que OrmLite actualiza la propiedad Id
				var propertyInfo = entity.GetType().GetProperty("Id");
				if ( propertyInfo != null )
				{
					propertyInfo.SetValue(entity, Convert.ChangeType(db.LastInsertId(), propertyInfo.PropertyType), null);					
				}

				return entity;
			}
		}

		/// <summary>
		/// Añade todas las entidades de la lista a la base de datos
		/// </summary>
		/// <param name="entities">Lista de entidades</param>
		public void AddAll( IEnumerable<TEntity> entities )
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{                
				using ( var tr = db.OpenTransaction() )
				{
					foreach ( var e in entities )
					{
						Add(e);
					}

					tr.Commit();
				}
			}
		}

		/// <summary>
		/// Actualiza la entidad TEntity
		/// </summary>
		/// <param name="entity">Entidad a actualizar</param>
		/// <returns>true o false</returns>
		public void Update( TEntity entity )
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{
				db.Update(entity);
			}
		}

		/// <summary>
		/// Actualiza todas las entidades de la lista
		/// </summary>
		/// <param name="entities">Lista de entidades</param>
		public void UpdateAll( IEnumerable<TEntity> entities )
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{
				db.UpdateAll(entities);
			}
		}

		/// <summary>
		/// Elimina la entidad TEntity
		/// </summary>
		/// <param name="entity">Entidad a eliminar</param>
		/// <returns>true o false</returns>
		public void Delete( TEntity entity )
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{
				db.Delete<TEntity>(entity);
			}
		}

		/// <summary>
		/// Elimina todos los elementos de la lista
		/// </summary>
		/// <param name="entities">Elementos a eliminar</param>
		public void DeleteAll( IEnumerable<TEntity> entities )
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{
				//db.DeleteAll(entities);                
                db.DeleteByIds<TEntity>(entities);
			}
		}

		/// <summary>
		/// Obtiene un elemento por su clave primaria
		/// </summary>
		/// <param name="id">Valor de la clave</param>
		/// <returns>TEntity</returns>
		public TEntity Get( object id )
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{
				//return db.GetByIdOrDefault<TEntity>(id);
                return db.SingleById<TEntity>(id);
			}
		}

		/// <summary>
		/// Obtiene todos los registros
		/// </summary>
		/// <returns>Una lista de <typeparamref name="TEntity"/></returns>
		public IEnumerable<TEntity> GetAll()
		{
			using ( 
                var db = dbFactory.OpenDbConnection() )
			{
				return db.Select<TEntity>();
			}
		}

		/// <summary>
		/// Obtiene registros según los límites indicados
		/// </summary>
		/// <param name="start">Índice del primer registro que se recuperará</param>
		/// <param name="limit">Número de registros a recuperar</param>
		/// <returns>Una lista de <typeparamref name="TEntity"/></returns>
		public IEnumerable<TEntity> GetAll( int start, int limit )
		{
			if ( start <= 0 ) start = DefaultOffset;
			if ( limit <= 0 ) limit = DefaultLimit;

			return GetAll().Skip(start - 1).Take(limit);
		}

		/// <summary>
		/// Obtiene los registros según la selección indicada
		/// </summary>
		/// <param name="select">Expresión de selección</param>
		/// <returns>Una lista de <typeparamref name="TEntity"/></returns>
		public IEnumerable<TEntity> GetAll( Expression<Func<TEntity, object>> selector, int start, int limit )
		{
			if ( selector == null )
			{
				return GetAll(start, limit);
			}
			else
			{				
				using ( var db = dbFactory.OpenDbConnection() )
				{
					if ( start <= 0 ) start = DefaultOffset;
					if ( limit <= 0 ) limit = DefaultLimit;

					return db
						.Select<TEntity>(selector)
						.Skip(start - 1)
						.Take(limit);
				}
			}
		}
		
		/// <summary>
		/// Devuelve todos los registros que cumplen la expresión <paramref name="filter"/>
		/// </summary>
		/// <param name="filter">Expresión de filtrado</param>
		/// <returns>Una lista de TEntity</returns>
		public IEnumerable<TEntity> GetFiltered( Expression<Func<TEntity, bool>> filter )
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{
				
				return db.Select(filter);
			}
		}

		/// <summary>
		/// Devuelve el número total de registros
		/// </summary>
		/// <returns>El número de registros</returns>
		public long Count()
		{
			using ( var db = dbFactory.OpenDbConnection() )
			{
				return db.Count<TEntity>();
			}
		}

		/// <summary>
		/// Devuelve un elemento incluyendo entidades relacionadas
		/// </summary>
		/// <param name="id">Valor de la clave</param>
		/// <param name="includes">Entidades relacionadas que se incluirán en el resultado</param>
		/// <returns>TEntity</returns>
		public TEntity GetIncluding( object id, params Expression<Func<TEntity, object>>[] includes )
		{
			throw new NotImplementedException();
			/*
			using ( var db = dbFactory.OpenDbConnection() )
			{
				return db.GetByIdOrDefault<TEntity>(id);
			}
			 * */
		}

		#endregion
		
	}
}

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
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using ManHouse.Data.Model;

namespace ManHouse.Data.Repositories
{
    /// <summary>
    /// Interfaz que representa un Repositorio
    /// </summary>
    /// <typeparam name="TEntity">Tipo de clase para el repositorio</typeparam>
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Añade la entidad TEntity a la BD
        /// </summary>
        /// <param name="entity">Entidad a añadir</param>
        /// <returns>La entidad añadida</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Añade todas las entidades de la lista a la BD
        /// </summary>
        /// <param name="entities"></param>
        void AddAll(IEnumerable<TEntity> entities);

        /// <summary>
        /// Actualiza la entidad TEntity
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        void Update(TEntity entity);

        /// <summary>
        /// Actualiza todas las entidades de la lista
        /// </summary>
        /// <param name="entities"></param>
        void UpdateAll(IEnumerable<TEntity> entities);

        /// <summary>
        /// Elimina la entidad TEntity
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Elimina todos los elementos de la lista
        /// </summary>
        /// <param name="entities">Elementos de la lista</param>
        void DeleteAll(IEnumerable<TEntity> entities);

        /// <summary>
        /// Obtiene un elemento por su clave primaria
        /// </summary>
        /// <param name="id">valor de la clave</param>
        /// <returns>TEntity</returns>
        TEntity Get(object id);

        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns>Una lista de <typeparamref name="TEntity"/></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Obtiene los registros según la selección indicada
        /// </summary>
        /// <param name="selector">Expresión de selección</param>
        /// <param name="start">Inicio de la selección</param>
        /// <param name="limit">Fin de la selección</param>
        /// <returns>Una lista de <typeparamref name="TEntity"/></returns>
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> selector, int start, int limit);

        /// <summary>
        /// Devuelve el número total de registros
        /// </summary>
        /// <returns>Número de registros</returns>
        long Count();

        /// <summary>
        /// Devuelve un elemento incluyendo entidades relacionadas
        /// </summary>
        /// <param name="id">valor de la clave</param>
        /// <param name="includes">Entidades relacionadas que se incluirán en el resultado</param>
        /// <returns></returns>
        TEntity GetIncluding(object id, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }
    }
}

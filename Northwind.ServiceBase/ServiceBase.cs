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
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using ServiceStack;
using ServiceStack.Text;
using Northwind.Common;
using Northwind.Common.Collections;
using Northwind.Data;
using Northwind.Data.Model;
using Northwind.Data.Repositories;
using Northwind.ServiceBase.Common;
using Northwind.ServiceBase.Caching;
using Northwind.ServiceBase.Meta;
using Northwind.ServiceBase.Query;

namespace Northwind.ServiceBase
{
	public abstract class ServiceBase<TEntity, TDto> : Service
		where TEntity : IEntity, new()
		where TDto : CommonDto, new()
	{		

		/// <summary>
		/// Repositorio de comunicación con la base de datos
		/// </summary>
		protected readonly IRepository<TEntity> Repository;

		#region Constructor
		
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="repository">Repositorio que se utilizará para la comunicación con la base de datos</param>
		public ServiceBase( IRepository<TEntity> repository )
		{
			Verify.ArgumentNotNull(repository, "repository");

			Repository = repository;			
		}

		#endregion

		#region Métodos públicos

		#region GetCurrentRequestCacheKey
		/// <summary>
		/// Devuelve una clave de caché para la petición actual
		/// </summary>
		/// <returns>Cadena con la clave de caché para la petición actual</returns>
		public virtual string GetCurrentRequestCacheKey()
		{            
			return new CacheKey(base.Request.AbsoluteUri, (NameValueCollection)base.Request.Headers.Original).ToString();
		}
		#endregion		

		#endregion

		#region Métodos protegidos

		#region GetSingle
		/// <summary>
		/// Obtención de un elemento a partir de su clave
		/// </summary>
		/// <typeparam name="TResponse">Tipo de la respuesta</typeparam>
		/// <param name="request">Petición</param>
		/// <returns>Elemento</returns>
		protected TResponse GetSingle<TResponse>( SingleRequest request ) where TResponse : SingleResponse<TDto>, new()
		{
			var result = Repository.Get(request.Id);

			if ( result == null )
			{
				throw HttpError.NotFound("Not found");
			}

			Response.AddHeaderLastModified(result.LastUpdated);
			Response.AddHeader(HttpHeaders.ETag, result.GetETagValue());

			//return TypeExtensionHelper.CreateInstance<TResponse>(result.ConvertTo<TDto>());
			return CreateResponse<TResponse>(result.ConvertTo<TDto>());

		}
		#endregion

		#region GetCollection
		/// <summary>
		/// Obtención de una lista de elementos
		/// </summary>
		/// <typeparam name="TResponse">Tipo de la respuesta</typeparam>
		/// <param name="request">Parámetros de la petición</param>
		/// <returns>Lista de elementos</returns>
		protected TResponse GetCollection<TResponse>( CollectionRequest request ) where TResponse : CollectionResponse<TDto>, new()
		{
			var query = (QueryExpression<TEntity>)request.Query;
			var queryExpr = (query != null ? query.Select : null);
			var requestUrl = base.Request.GetPathUrl();

			FixOffsetAndLimit(request);

			// Búsqueda de resultados
			var result = Repository
				.GetAll(queryExpr, request.Offset, request.Limit)
				.Select(e =>
				{
					var dto = e.ConvertTo<TDto>();
					dto.Link = new Link(LinkRelationType.Self, new Uri(String.Format("{0}/{1}", requestUrl, dto.GetId<TDto>().ToString())));
					return dto;
				})
				.ToList();						

			// Totales			
			var totalCount = Repository.Count();

			// Enlaces de paginación
			var links = CreatePaginationLinks(request.Offset, request.Limit, totalCount);			

			// Creación de la respuesta
			var response = CreateResponse<TResponse>(result);

			// Metadatos
			response.Metadata = new Metadata()
			{
				Offset = request.Offset, 
				Limit = request.Limit,
				TotalCount = totalCount,
				Links = links
			};

			// Cabecera HTTP de paginación
			var headerLinks = links
				.Where(lnk => lnk.Relation != LinkRelationType.Self)
				.Select(lnk => lnk.ToString(LinkSerializationFormat.HttpHeader))
				.Join(",");

			if ( !String.IsNullOrEmpty(headerLinks) )
			{
				Response.AddHeader("Link", headerLinks);
			}

			return response;
				
		}
		#endregion

		#region ToOptimizedResultUsingCache
		/// <summary>
		/// Obtiene los resultados de una petición con comprobación de caché
		/// </summary>
		/// <param name="factoryFn">Elementos que se guardarán en caché si no existen</param>
		/// <returns>La respuesa optimizada</returns>
		protected object ToOptimizedResultUsingCache<TResponse>( Func<TResponse> factoryFn ) where TResponse : class
		{
			Verify.ArgumentNotNull(factoryFn, "factoryFn");

			return base.Request.ToOptimizedResultUsingCache<TResponse>(base.Cache, GetCurrentRequestCacheKey(), factoryFn);
		}
		#endregion

		#region Update
		/// <summary>
		/// Actualización completa de un elemento.
		/// <para>
		/// Devuelve el status 200 si la creación ha sido correcta
		/// </para>
		/// </summary>
		/// <typeparam name="TResponse">Tipo de la respuesta</typeparam>
		/// <param name="request">Elemento a añadir</param>
		/// <returns>El nuevo objeto creado</returns>
		protected object Update( TDto dto )
		{
			Repository.Update(dto.ConvertTo<TEntity>());			

			base.Request.RemoveFromCache(base.Cache, GetCurrentRequestCacheKey());            

			return new HttpResult(HttpStatusCode.OK);
		}
		#endregion

		#region Insert
		/// <summary>
		/// Creación de un elemento
		/// <para>
		/// Devuelve el status 201 si la creación ha sido correcta
		/// </para>
		/// </summary>
		/// <param name="request">Elemento a crear</param>
		/// <returns>{TResponse}</returns>
		protected object Insert<TResponse>( TDto dto ) where TResponse : SingleResponse<TDto>, new()
		{
			var newEntity = Repository.Add(dto.ConvertTo<TEntity>());
			var response = TypeExtensionHelper.CreateInstance<TResponse>(newEntity.ConvertTo<TDto>());

			return new HttpResult(response, HttpStatusCode.Created);			
		}
		#endregion

		#region Delete
		/// <summary>
		/// Eliminación de un elemento
		/// </summary>
		/// <param name="request">Elemento a eliminar</param>
		/// <returns>Status 204 (sin contenido)</returns>
		protected object Remove( TDto request )
		{
			Repository.Delete(request.ConvertTo<TEntity>());

			return new HttpResult(HttpStatusCode.NoContent);
		}
		#endregion

		#region Patch
		/// <summary>
		/// Actualización parcial de un elemento
		/// </summary>
		/// <param name="request">Elemento a actualizar</param>
		/// <returns></returns>
		protected object UpdatePartial( TDto request )
		{
			var current = Repository.Get(request.GetId<TDto>());
			current.PopulateWithNonDefaultValues(request);

			Repository.Update(current.ConvertTo<TEntity>());

			return new HttpResult(HttpStatusCode.OK);

		}
		#endregion

		#endregion

		#region Métodos privados

		#region FixOffsetAndLimit
		/// <summary>
		/// Establece los límites de recuperación de datos
		/// </summary>
		/// <param name="request"></param>
		private void FixOffsetAndLimit( ICollectionRequest request )
		{
			if ( request.Offset < 1 ) request.Offset = 1;
			if ( request.Limit < 1 ) request.Limit = 10;
		}		
		#endregion		

		#region CreatePaginationLink
		/// <summary>
		/// Creación de un link de paginación
		/// </summary>
		/// <param name="linkType"></param>
		/// <param name="offset"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		private Link CreatePaginationLink( LinkRelationType linkType, int offset, int limit )
		{
			var uri = new Uri(base.Request.AbsoluteUri)
				.AddQuery(ServiceOperations.Offset, offset.ToString())
				.AddQuery(ServiceOperations.Limit, limit.ToString());

			return new Link(linkType, uri);

		}
		#endregion

		#region CreatePaginationLinks

		/// <summary>
		/// Creación de los enlaces de paginación a partir del índice indicado
		/// </summary>
		/// <param name="offset">Índice del primer elemento de la lista</param>
		/// <param name="limit">Límite de elementos por página</param>
		/// <param name="totalCount">Número de elementos totales</param>
		/// <returns><see cref="List{Link}"/></returns>
		public List<Link> CreatePaginationLinks( int offset, int limit, long totalCount )
		{
			var pageCount = (totalCount > 0 ? (int)Math.Ceiling(totalCount / (double)limit) : 0);
			var pageNumber = (pageCount > 0 ? (int)Math.Ceiling((offset) / (double)limit) : 1);
			var links = new List<Link>();

			links.Add(CreatePaginationLink(LinkRelationType.Self, offset, limit));	// Actual			

			if ( pageNumber > 1 )
			{
				links.Add(CreatePaginationLink(LinkRelationType.First, 1, limit));
				links.Add(CreatePaginationLink(LinkRelationType.Previous, offset - limit, limit));
			}

			if ( pageNumber < pageCount )
			{
				links.Add(CreatePaginationLink(LinkRelationType.Next, offset + limit, limit));

				var lastOffset = (pageCount - 1) * limit + 1;
				links.Add(CreatePaginationLink(LinkRelationType.Last, lastOffset, limit));
			}

			return links;
		}

		#endregion

		#region CreateResponse
		/// <summary>
		/// Creación de un objecto de respuesta <see cref="TResponse"/>
		/// </summary>
		/// <typeparam name="TResponse">Tipo de la respuesta</typeparam>
		/// <param name="args">Parámetros del objeto</param>
		/// <returns>Un objeto de tipo <see cref="TResponse"/></returns>
		private TResponse CreateResponse<TResponse>( params object[] args )
		{
			return TypeExtensionHelper.CreateInstance<TResponse>(args);
		}
		#endregion

		#endregion

	}
}

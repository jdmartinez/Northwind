using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ManHouse.Data.Model;
using ManHouse.Data.Repositories;
using ManHouse.ServiceBase.Caching;
using ManHouse.ServiceBase.Query;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Common;
using ServiceStack.Common.Utils;
using ServiceStack.Common.Web;

namespace ManHouse.ServiceBase
{
    /// <summary>
    /// Clase que represena un servicio web
    /// </summary>
    public abstract class Servicebase<TEntity, TDto> : Service
        where TEntity : IEntity, new()
        where TDto : CommonDto, new()
    {
        #region Propiedades

        /// <summary>
        /// Repositorio
        /// </summary>
        public IRepository<TEntity> Repository { get; set; }            // Se establecerá mediante IoC

        #endregion

        #region Métodos CRUD

        #region GET

        public virtual object Get(SingleRequest<TDto> request)
        {
            var cacheKey = IdUtils.CreateUrn<TDto>(request.Id);

            return RequestContext.ToOptimizedResultUsingCache(base.Cache, cacheKey, () =>
                {
                    var result = Repository.Get(request.Id);

                    if (result == null)
                    {
                        throw HttpError.NotFound("Not found");
                    }

                    Response.AddHeaderLastModified(result.LastUpdated);
                    Response.AddHeader(HttpHeaders.ETag, result.GetETagValue());

                    return new SingleResponse<TDto> { Result = result.TranslateTo<TDto>() };
                });
        }

        /// <summary>
        /// Recuperación de todos los elementos
        /// </summary>
        /// <param name="request">Petición</param>
        /// <returns>Colección de elementos</returns>
        public virtual object Get(CollectionRequest<TDto> request)
        {
            var cacheKey = new CacheKey(Request.AbsoluteUri, Request.Headers).ToString();

            return RequestContext.ToOptimizedResultUsingCache(base.Cache, cacheKey,
                () =>
                {
                    var query = (QueryExpression<TEntity>)request.Query;
                    var queryExpr = (query != null ? query.Select : null);
                    var requestUrl = Request.GetPathUrl();

                    FixOffsetAndLimite(request);

                    var result = Repository
                        .GetAll(queryExpr, request.Offset, request.Limit)
                        .Select(e =>
                            {
                                var dto = e.TranslateTo<TDto>();
                                //var restPath = EndpointHostConfig.Instance.Metadata.Routes.RestPaths.Single(r => r.RequestType == request.GetType());
                                dto.Link = new Uri(String.Format("{0}/{1}", requestUrl, dto.GetId<TDto>().ToString()));
                                return dto;
                            })
                            .ToList();

                    // creación de la respuesta
                    return new CollectionResponse<TDto>(result, request.Offset, request.Limit, Repository.Count());
                });
        }

        #endregion

        #region POST

        /// <summary>
        /// Actualización
        /// <para>
        /// Devuelve Status 201 si la creación ha sido correcta
        /// </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual object Post(SingleRequest<TDto> request)
        {
            try
            {
                var newEntity = Repository.Add(request.TranslateTo<TEntity>());

                var result = new SingleResponse<TDto> { Result = newEntity.TranslateTo<TDto>() };

                return new HttpResult(result, HttpStatusCode.Created);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region PUT
        #endregion

        #endregion

        #region Métodos protegidos

        /// <summary>
        /// Establece los límites de recuperación de datos
        /// </summary>
        /// <param name="request"></param>
        protected void FixOffsetAndLimite (CollectionRequest<TDto> request)
        {
            if ( request.Offset < 1 ) request.Offset = 1;
            if ( request.Limit < 1 ) request.Limit = 10;
        }

        #endregion
    }
}

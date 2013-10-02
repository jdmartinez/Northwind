using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManHouse.Data.Model;
using ManHouse.Data.Repositories;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
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
                    //Response.AddHeader(HttpHeaders.ETag, result.GetE

                    //return new SingleResponse<TDto> {Result=result.Trans
                });
        }

        #endregion

        #endregion
    }
}

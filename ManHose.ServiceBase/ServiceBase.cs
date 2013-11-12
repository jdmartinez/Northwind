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
using System.Text;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Common.Web;
using ManHouse.Common;
using ManHouse.Data.Model;
using ManHouse.Data.Repositories;
using ManHouse.ServiceBase.Caching;

namespace ManHouse.ServiceBase
{
    public class ServiceBase<TEntity, TDto> : Service
        where TEntity : IEntity, new()
        where TDto : CommonDto, new()
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IRepository<TEntity> Repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            Verify.ArgumentNotNull(repository);

            Repository = repository;
        }

        #region Métodos públicos

        #region GetCurrentRequestCacheKey
        /// <summary>
        /// Devuelve una clave de caché para la petición actual
        /// </summary>
        /// <returns>Cadena con la clave de caché para la petición actual</returns>
        public virtual string GetCurrentRequestCacheKey()
        {
            return new CacheKey(Request.AbsoluteUri, Request.Headers).ToString();
        }
        #endregion

        #endregion

        #region Métodos protegidos

        #region GetSingle
        protected TResponse GetSingle<TResponse>(SingleRequest request) where TResponse : SingleResponse<TDto>, new()
        {
            var result = Repository.Get(request.Id);

            if (result == null)
            {
                throw HttpError.NotFound("Not Found");
            }

            Response.AddHeaderLastModified(result.LastUpdated);
            Response.AddHeader(HttpHeaders.ETag, result.GetETagValue());

            return TypeExtensionHelper.CreateInstance<TResponse>(result.TranslateTo<TDto>());
        }
        #endregion

        #endregion
    }
}

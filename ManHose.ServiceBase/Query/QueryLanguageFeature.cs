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
using System.Text;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceHost;
using ManHouse.Common;

namespace ManHouse.ServiceBase.Query
{
    /// <summary>
    /// Clase que interroga una petición
    /// </summary>
    public class QueryLanguageFeature : IPlugin
    {
        #region Campos

        /// <summary>
        /// Referencia a IAppHost
        /// </summary>
        private IAppHost _appHost;

        /// <summary>
        /// Diccionario donde se guardará las asociaciones entre clases
        /// </summary>
        private Dictionary<Type, Type> _associations = new Dictionary<Type, Type>();

        #endregion

        #region Propiedades

        #region IsEnabled

        /// <summary>
        /// Indica si el plugin está habilitado o no
        /// </summary>
        public static bool IsEnabled
        {
            get { return EndpointHost.Plugins.Any(p => p is QueryLanguageFeature); }
        }
        #endregion

        #endregion

        #region Miembros de IPlugin

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appHost"></param>
        void IPlugin.Register(IAppHost appHost)
        {
            Verify.ArgumentNotNull(appHost);

            _appHost = appHost;
            //_appHost.RequestFilters.Add(
        }

        #endregion

        #region Métodos privados

        #region ProcessRequest
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="res"></param>
        /// <param name="dto"></param>
        private void ProcessRequest(IHttpRequest req, IHttpResponse res, object dto)
        {
            Verify.ArgumentNotNull(req);
            Verify.ArgumentNotNull(res);
            Verify.ArgumentNotNull(dto);

            if (dto is ISearchable)
            {
                //SetQ
            }
        }

        #endregion

        #region SetQueryExpression

        /// <summary>
        /// Establece la expresión de selección
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="queryString"></param>
        private void SetQueryExpression(ISearchable dto, NameValueCollection queryString)
        {
            var typeOfDto = dto.GetType().IsGenericType ? dto.GetType().GetGenericArguments() : new Type[] { dto.GetType() };

            Type associatedType;

            if (_associations.TryGetValue(typeOfDto.First(), out associatedType))
            {
                var parserType = typeof(Query
            }
        }

        #endregion

        #endregion
    }
}

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
using System.Web;
//using ServiceStack.Api.Swagger;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common.Utils;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.OrmLite;
//using ServiceStack.OrmLite.Sqlite;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.Cors;
using ServiceStack.ServiceInterface.Validation;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;
using ManHouse.ServiceBase;
using ManHouse.ServiceBase.Query;
using ManHouse.ServiceInterface.Services;
using ManHouse.ServiceBase.Meta;
using ManHouse.ServiceBase.Relations;
using ManHouse.ServiceModel.Dto;
using ManHouse.Data.Repositories;

//using ServiceStack.Razor;

namespace ManHouse.Host.Web
{
    /// <summary>
    /// Clase que representa la aplicación Web
    /// </summary>
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("ManHouse web services", typeof(CustomersService).Assembly)
        {
        }

        #region Miembros de AppHostBase

        #region Configure

        /// <summary>
        /// Configuración de los servicios web
        /// </summary>
        /// <param name="container">Contenedor IoC</param>
        public override void Configure(Funq.Container container)
        {
            //JSON
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.IncludeNullValues = false;
            JsConfig.DateHandler = JsonDateHandler.ISO8601;
            JsConfig.EscapeUnicode = true;
            JsConfig<MetadataUriType>.SerializeFn = text => text.ToString().ToCamelCase();
            JsConfig<RelationType>.SerializeFn = text => text.ToString().ToCamelCase();

			// ServiceStack
			SetConfig(new EndpointHostConfig
			{
				DebugMode = true
			});

            // Plugins
            var queryPlugin = new QueryLanguageFeature();
            //queryPlugin.reg

            // Dependencias
            container.RegisterAs<MiembroEntityRepository, IMiembroEntityRepository>();
        }

        #endregion

        #endregion

        #region Miembros estáticos. Método de inicio del servicio Web

        #region Start. Desencadenador del servicio. Inicia la escucha de peticiones
        public static void Start()
        {
            new AppHost().Init();
        }
        #endregion

        #endregion
    }


}
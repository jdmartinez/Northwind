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
//using ServiceStack.Razor;

namespace ManHouse.Host
{
    /// <summary>
    /// Clase que representa la aplicación Web
    /// </summary>
    public class AppHost : AppHostBase
    {
//        public AppHost() : base("ManHouse web services",
//            base("Northwind web services", typeof(CustomersService).Assembly)
    }
}
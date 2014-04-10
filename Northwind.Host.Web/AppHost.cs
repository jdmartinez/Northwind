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
using System.Configuration;
using System.Linq;
using System.Web;
using System.Reflection;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Caching;
using ServiceStack.OrmLite;
using ServiceStack.Validation;
using ServiceStack.Text;
using ServiceStack.Api.Swagger;
using ServiceStack.Razor;
using Funq;
using Northwind.Data.Model;
using Northwind.Data.Repositories;
using Northwind.ServiceBase;
using Northwind.ServiceBase.Meta;
using Northwind.ServiceBase.Query;
using Northwind.ServiceBase.Relations;
using Northwind.ServiceInterface.Services;
using Northwind.ServiceInterface.Validators;
using Northwind.ServiceModel.Contracts;
using Northwind.ServiceModel.Dto;

namespace Northwind.Host.Web
{
	/// <summary>
	/// Clase que representa la aplicación Web
	/// </summary>
    public class AppHost : AppHostBase /*AppHostHttpListenerBase*/
	{
		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public AppHost() : base("Northwind web services", typeof(CustomersService).Assembly)
		{
		}        

		#region Miembros de AppHostBase

		#region Configure
		/// <summary>
		/// Configuración de los servicios web
		/// </summary>
		/// <param name="container">Contenedor IoC</param>
		public override void Configure( Container container )
		{
			// Configuración JSON
			JsConfig.EmitCamelCaseNames = true;
			JsConfig.IncludeNullValues = false;
			JsConfig.DateHandler = DateHandler.ISO8601;
			JsConfig.EscapeUnicode = true;			
			//JsConfig<LinkRelationType>.SerializeFn = (text => text.ToString().ToLower());

			// Configuración de ServiceStack            
			SetConfig(new HostConfig
			{
				DebugMode = true,
                ReturnsInnerException = true,
				WebHostUrl = "http://localhost:2828"/*HttpContext.Current.Request.Url.ToString()*/
			});			

			// Plugins
			var queryPlugin = new QueryLanguageFeature();
			queryPlugin.RegisterAssociation(typeof(Customer), typeof(CustomerEntity));
			queryPlugin.RegisterAssociation(typeof(GetCustomers), typeof(CustomerEntity));
			queryPlugin.RegisterAssociation(typeof(Order), typeof(OrderEntity));
			queryPlugin.RegisterAssociation(typeof(GetOrders), typeof(OrderEntity));

			Plugins.Add(queryPlugin as IPlugin);
			Plugins.Add(new ValidationFeature());
			Plugins.Add(new SwaggerFeature());
			Plugins.Add(new RazorFormat());
			Plugins.Add(new CorsFeature());

			// Validaciones
			//container.RegisterValidators(typeof(CustomerValidator).Assembly);						

			// Caché
			//container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register(new MemoryCacheClient());

            // Acceso a datos
            var dbFactory = new OrmLiteConnectionFactory("~/Northwind.sqlite".MapHostAbsolutePath(), SqliteDialect.Provider);

            container.Register(new OrmLiteConnectionFactory("~/Northwind.sqlite".MapHostAbsolutePath(), SqliteDialect.Provider));

			// Dependencias
            //container.RegisterAs<CategoryEntityRepository, ICategoryEntityRepository>();
            //container.RegisterAs<CustomerEntityRepository, ICustomerEntityRepository>();
            //container.RegisterAs<EmployeeEntityRepository, IEmployeeEntityRepository>();
            //container.RegisterAs<OrderEntityRepository, IOrderEntityRepository>();	
            //container.RegisterAs<OrderDetailEntityRepository, IOrderDetailEntityRepository>();
            //container.RegisterAs<ProductEntityRepository, IProductEntityRepository>();
            //container.RegisterAs<ShipperEntityRepository, IShipperEntityRepository>();
            //container.RegisterAs<SupplierEntityRepository, ISupplierEntityRepository>();
            //container.RegisterAs<RegionEntityRepository, IRegionEntityRepository>();
            //container.RegisterAs<TerritoryEntityRepository, ITerritoryEntityRepository>();

            container.Register<ICustomerEntityRepository>(c => new CustomerEntityRepository(dbFactory));            

            //container.RegisterAs<CategoryEntityRepository, IRepository<CategoryEntity>>();
            //container.RegisterAs<CustomerEntityRepository, IRepository<CustomerEntity>>();
            //container.RegisterAs<EmployeeEntityRepository, IRepository<EmployeeEntity>>();
            //container.RegisterAs<OrderEntityRepository, IRepository<OrderEntity>>();
            //container.RegisterAs<OrderDetailEntityRepository, IRepository<OrderDetailEntity>>();
            //container.RegisterAs<ProductEntityRepository, IRepository<ProductEntity>>();
            //container.RegisterAs<ShipperEntityRepository, IRepository<ShipperEntity>>();
            //container.RegisterAs<SupplierEntityRepository, IRepository<SupplierEntity>>();
            //container.RegisterAs<RegionEntityRepository, IRepository<RegionEntity>>();
            //container.RegisterAs<TerritoryEntityRepository, IRepository<TerritoryEntity>>();
                         
		}
		#endregion

		#endregion			        

		#region Miembros estáticos

		#region Start
		/// <summary>
		/// Inicio de una instancia de la aplicación
		/// </summary>
		public static void Start()
		{
			new AppHost().Init();
		}
		#endregion        

        #endregion
    }
}
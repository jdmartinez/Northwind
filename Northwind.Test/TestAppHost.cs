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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Funq;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Caching;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.Validation;
using ServiceStack.Text;
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
using Northwind.Test.Data;
using ServiceStack.Data;

namespace Northwind.Test
{
	/// <summary>
	/// Clase que representa la aplicación Web
	/// </summary>
	public class TestAppHost : AppHostHttpListenerBase
	{
		private static ILog log;

		/// <summary>
		/// Constructor de la clase
		/// </summary>
		public TestAppHost()
			: base("Northwind test web services", typeof(CustomersService).Assembly)
		{
			LogManager.LogFactory = new DebugLogFactory();
			log = LogManager.GetLogger(GetType());

			Instance = null;

			Init();

			try
			{
				Start(TestConfig.AbsoluteBaseUri.ToString());
			}
			catch ( Exception ex )
			{
				Console.WriteLine("Error al iniciar ConsoleHost: " + ex.Message);
			}
		}

		#region Miembros de AppHostBase

		#region Configure
		/// <summary>
		/// Configuración de los servicios web
		/// </summary>
		/// <param name="container">Contenedor IoC</param>
		public override void Configure( Container container )
		{
			// JSON
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.IncludeNullValues = false;
            JsConfig.DateHandler = DateHandler.ISO8601;
            JsConfig.EscapeUnicode = true;
			//JsConfig<LinkRelationType>.SerializeFn = text => text.ToString().ToCamelCase();
			//JsConfig<RelationType>.SerializeFn = text => text.ToString().ToCamelCase();

			// ServiceStack
			SetConfig(new HostConfig
			{
                DefaultContentType = MimeTypes.Json,
				DebugMode = true,
				WebHostUrl = TestConfig.AbsoluteBaseUri.ToString()
			});

			// Plugins
			var queryPlugin = new QueryLanguageFeature();
			queryPlugin.RegisterAssociation(typeof(Customer), typeof(CustomerEntity));
			queryPlugin.RegisterAssociation(typeof(GetCustomers), typeof(CustomerEntity));
			queryPlugin.RegisterAssociation(typeof(Order), typeof(OrderEntity));
			queryPlugin.RegisterAssociation(typeof(GetOrders), typeof(OrderEntity));

            Plugins.Add(queryPlugin as IPlugin);	
			Plugins.Add(new ValidationFeature());
			Plugins.Add(new CorsFeature());

			// Validaciones
			container.RegisterValidators(typeof(CustomerValidator).Assembly);

			// Caché
			container.Register<ICacheClient>(new MemoryCacheClient());			

			// Acceso a datos
			var dbFactory = new OrmLiteConnectionFactory(":memory:", /*false,*/ SqliteDialect.Provider);

			//container.Register<IDbConnectionFactory>(dbFactory);
            container.Register(dbFactory);

			using ( var db = dbFactory.OpenDbConnection() )
			{
				NorthwindData.LoadData();
				
				db.CreateTables(false, NorthwindFactory.ModelTypes.ToArray());
				db.InsertAll(NorthwindData.Categories);
				db.InsertAll(NorthwindData.Customers);
				db.InsertAll(NorthwindData.OrderDetails);
				db.InsertAll(NorthwindData.Orders);
				db.InsertAll(NorthwindData.Products);
				db.InsertAll(NorthwindData.Regions);
				db.InsertAll(NorthwindData.Shippers);
				db.InsertAll(NorthwindData.Suppliers);
				db.InsertAll(NorthwindData.Territories);				
			}

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

            container.Register<ICustomerEntityRepository>(c => new CustomerEntityRepository(dbFactory) 
            {
                OrderRepository = new OrderEntityRepository(dbFactory)
            });
            container.Register<IOrderEntityRepository>(c => new OrderEntityRepository(dbFactory));

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
		
	}
}
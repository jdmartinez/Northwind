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
using System.Text;
using System.Reflection;
using System.Web;
using ServiceStack;
using Northwind.Common;
using Northwind.ServiceBase.Common;
using Northwind.ServiceBase.Query.Parser;
using ServiceStack.Web;

namespace Northwind.ServiceBase.Query
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
		/// Diccionario donde se guardarán las asociaciones entre clases
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
            get { return HostContext.HasPlugin<QueryLanguageFeature>(); }
		}
		#endregion		

		#endregion

		#region Miembros de IPlugin

		/// <summary>
		/// 
		/// </summary>
		/// <param name="appHost"></param>
		public void Register( IAppHost appHost )
		{
			Verify.ArgumentNotNull(appHost, "appHost");

			_appHost = appHost;
            _appHost.GlobalRequestFilters.Add((req, res, dto) => ProcessRequest(req, res, dto));
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
		private void ProcessRequest( IRequest req, IResponse res, object dto )
		{
			Verify.ArgumentNotNull(req, "req");
			Verify.ArgumentNotNull(res, "res");
			Verify.ArgumentNotNull(dto, "dto");

            //if (((HttpRequestWrapper)req.OriginalRequest).HttpMethod != "GET") return;
            if (req.Verb != HttpMethods.Get) return;

			if ( dto is ISearchable )
			{
				// Sólo creamos la expresión si los parámetros contiene alguna de las operaciones de query
				if ( req.QueryString.AllKeys.Any(k => ServiceOperations.GetAllOperations().Contains(k)) )
				{
					SetQueryExpression(dto as ISearchable, (NameValueCollection)req.QueryString.Original);
				}
			}
		}
		#endregion

		#region SetQueryExpression
		/// <summary>
		/// Establece la expresión de selección 
		/// </summary>
		/// <param name="dto"></param>
		private void SetQueryExpression( ISearchable dto, NameValueCollection queryString )
		{
			var typeOfDto = dto.GetType().IsGenericType ? dto.GetType().GetGenericArguments() : new Type[] { dto.GetType() };

			Type associatedType;

			if ( _associations.TryGetValue(typeOfDto.First(), out associatedType) )
			{
				var parserType = typeof(QueryParametersParser<>).MakeGenericType(associatedType);
				//var parser = parserType.CreateTypeInstance();                
                var parser = parserType.CreateInstance();

				var queryExpr = Expression.Call(
					Expression.Constant(parser, parserType),
					"Parse",
					null,
					Expression.Constant(queryString));

				var lambda = Expression.Lambda<Func<IQueryExpression>>(queryExpr);

				dto.GetType()
				   .GetProperty("Query")
				   .SetValue(dto, lambda.Compile()(), null);
			}				
		}
		#endregion

		#endregion

		#region Métodos públicos

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		public void RegisterAssociation(Type t1, Type t2)
		{
			Type type;

			if ( !(_associations.TryGetValue(t1, out type)) ) 
			{
				_associations.Add(t1, t2);
			}
		}

		#endregion

	}
}

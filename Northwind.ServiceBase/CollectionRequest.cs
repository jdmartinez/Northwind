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
using ServiceStack;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceClient.Web;
using ServiceStack.WebHost.Endpoints;

using Northwind.Common;
using Northwind.ServiceBase.Query;
using Northwind.ServiceBase.Meta;

namespace Northwind.ServiceBase
{	
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class CollectionRequest : ICollectionRequest
	{
		#region Miembros de ICollectionRequest

		/// <summary>
		/// Índice del primer elemento de la colección
		/// </summary>
		public int Offset { get; set; }

		/// <summary>
		/// Número de elementos de la colección
		/// </summary>
		public int Limit { get; set; }

		#endregion

		#region Miembros de ISearchable

		/// <summary>
		/// Representa una expresión de búsqueda y filtrado de datos
		/// </summary>
		/// TODO: Añadir una función para la conversión de un string o IEnumerable<String> en IQueryExpression
		public IQueryExpression Query { get; set; }

		#endregion

		#region Constructores

		/// <summary>
		/// Constructur de la clase
		/// </summary>
		public CollectionRequest()
		{ }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="offset"></param>
		/// <param name="limit"></param>
		public CollectionRequest( int offset, int limit )
		{
			Offset = offset;
			Limit = limit;
		}

		#endregion		
	}
}

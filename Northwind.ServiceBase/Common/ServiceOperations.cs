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
using System.Reflection;
using System.Text;

namespace Northwind.ServiceBase.Common
{
	/// <summary>
	/// Definición de operaciones de servicio
	/// </summary>
	public static class ServiceOperations
	{
		/// <summary>
		/// 
		/// </summary>
		public const String Offset = "offset";

		/// <summary>
		/// 
		/// </summary>
		public const String Limit = "limit";

		/// <summary>
		/// 
		/// </summary>
		public const String Select = "select";

		/// <summary>
		/// 
		/// </summary>
		public const String Include = "include";

		/// <summary>
		/// 
		/// </summary>
		public const String SortBy = "sortby";

		/// <summary>
		/// 
		/// </summary>
		public const String SortAscending = "asc";

		/// <summary>
		/// 
		/// </summary>
		public const String SortDescending = "desc";

		/// <summary>
		/// Devuelve una lista con todas operaciones permitidas
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<string> GetAllOperations()
		{
			return typeof(ServiceOperations)
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(f => f.IsLiteral && !f.IsInitOnly)
				.Select(f => f.GetValue(null).ToString());
		}
	}
}

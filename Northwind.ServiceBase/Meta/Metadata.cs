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

using Northwind.Common;
using Northwind.Common.Collections;
using Northwind.ServiceBase.Common;

namespace Northwind.ServiceBase.Meta
{
	/// <summary>
	/// Clase que representa los metadatos de una respuesta
	/// </summary>
	public class Metadata
	{

		#region Propiedades

		/// <summary>
		/// Índice del primer elemento
		/// </summary>
		public int Offset { get; /*private*/ set; }

		/// <summary>
		/// Número límite de elementos
		/// </summary>
		public int Limit { get; /*private*/ set; }

		/// <summary>
		/// Número total de elementos
		/// </summary>
		public long TotalCount { get; /*private*/ set; }

		/// <summary>
		/// Lista de enlaces
		/// </summary>
		public List<Link> Links { get; set; }

		#endregion

		#region Constructores

		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public Metadata()
		{
		}			

		#endregion

	}
}

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
using System.Linq.Expressions;
using System.Text;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.Text;

using Northwind.Common;

namespace Northwind.ServiceBase.Meta
{	
	/// <summary>
	/// Clase que representa un enlace hypermedia
	/// </summary>
	public class Link
	{
		// Formatos
		private Dictionary<LinkSerializationFormat, string> _linkFormats = new Dictionary<LinkSerializationFormat, string>()
		{
			{ LinkSerializationFormat.HttpHeader, "<{0}>; rel={1}" }
		};

		#region Propiedades

		/// <summary>
		/// <see cref="Uri"/>
		/// </summary>
		public Uri Href { get; set; }
	
		/// <summary>
		/// Tipo de relación del enlace
		/// </summary>		
		public LinkRelationType Relation { get; set; }

		/// <summary>
		/// Título del enlace
		/// </summary>
		public string Title { get; set; }

		#endregion

		#region Constructores

		/// <summary>
		/// 
		/// </summary>
		public Link()
		{ }

		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="request">Petición base</param>
		/// <param name="rel">Tipo de relación</param>
		public Link(LinkRelationType rel, Uri uri )
		{			
			Verify.ArgumentNotNull(rel, "rel");
			Verify.ArgumentNotNull(uri, "uri");
			
			Relation = rel;
			Href = uri;

		}

		#endregion

		#region Métodos públicos

		#region ToString
		/// <summary>
		/// Devuelve la representación de cadena de <see cref="Link"/> según el formato indicado
		/// </summary>
		/// <param name="format"></param>
		public string ToString(LinkSerializationFormat format) 
		{
			var linkFormat = String.Empty;

			if ( !(_linkFormats.ContainsKey(format)) ) throw new ArgumentException();

			_linkFormats.TryGetValue(format, out linkFormat);
				
			return String.Format(linkFormat, Href.ToString(), Relation.SerializeToString());
		}
		#endregion		

		#endregion

		#region Overrides

		#region Equals
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals( object obj )
		{
			if ( obj == null ) return false;

			var target = (Link)obj;

			return target.Relation == this.Relation &&
				target.Href == this.Href &&
				target.Title == this.Title;
		}
		#endregion

		#endregion
	}
}

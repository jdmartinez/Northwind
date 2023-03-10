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
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using ServiceStack;
using ServiceStack.OrmLite;
using Northwind.Common;
using Northwind.Data.Expressions;

namespace Northwind.Data
{
	/// <summary>
	/// Clase con métodos de extensión que complementan los de OrmLite
	/// </summary>
	internal static class ReadExtensions
	{		
		/// <summary>
		/// Devuelve en una lista los datos que corresponden únicamente a las propiedades indicadas en <paramref name="selector"/>
		/// </summary>
		/// <typeparam name="T">Tipo que se devolverá</typeparam>
		/// <param name="dbConn">Conexión</param>
		/// <param name="selector">Expresión que contiene una clase anónica con las propiedades que se recuperarán</param>
		/// <returns><see cref="List"/> con el resultado</returns>
		public static List<T> Select<T>( this IDbConnection dbConn, Expression<Func<T, object>> selector )
		{
			Verify.ArgumentNotNull(dbConn, "dbConn");
			Verify.ArgumentNotNull(selector, "selector");
			
			var visitor = new SqlSelectExpressionTranslator();
			var selectStr = GenerateSelectExpression(ModelDefinition<T>.Definition, visitor.Translate(selector), false);

            return dbConn.Select<T>(selectStr);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fields"></param>
		/// <param name="distinct"></param>
		/// <returns></returns>
		private static String GenerateSelectExpression(ModelDefinition modelDef, String fields, bool distinct )
		{
			var columns = fields
				.Split(',')
				.ToList()
				.Select(c => OrmLiteConfig.DialectProvider.GetQuotedColumnName(c))
				.Join(",");

			return String.Format("SELECT {0}{1} \n FROM {2}", 
				(distinct ? "DISTINCT " : ""),
				(String.IsNullOrEmpty(columns) ? OrmLiteConfig.DialectProvider.GetColumnNames(modelDef) : columns),
				OrmLiteConfig.DialectProvider.GetQuotedTableName(modelDef));
		}
	}
}

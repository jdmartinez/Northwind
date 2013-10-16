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
using System.Reflection;

namespace ManHouse.ServiceBase.Query.Parser
{
    /// <summary>
    /// Representa una clase de generación de expresiones de selección
    /// </summary>
    public class SelectExpressionFactory<TEntity>
    {
        #region Campos

        /// <summary>
        /// Flags por defecto para buscar las propiedades 
        /// </summary>
        private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Diccionario donde se guardarán las selecciones
        /// </summary>
        private IDictionary<string, Expression<Func<TEntity, object>>> _selections;

        private Cla
        #endregion
    }
}

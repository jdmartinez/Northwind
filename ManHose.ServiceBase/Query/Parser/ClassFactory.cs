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
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using ManHouse.Common;

namespace ManHouse.ServiceBase.Query.Parser
{
    /// <summary>
    /// Define una clase que genera tipos de manera dinámica
    /// </summary>
    /// <seealso cref="http://mironabramson.com/blog/post/2008/06/Create-you-own-new-Type-and-use-it-on-run-time-(C).aspx"/>
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/5kyyyeh2(v=vs.100).aspx"/>
    /// <remarks>Adaptado de System.Linq.Dynamic</remarks>
    internal class ClassFactory
    {
        #region Campos

        /// <summary>
        /// Nombre del ensamblado virtual que se necesita para la creación de tipos
        /// </summary>
        private static readonly AssemblyName AssemblyName = new AssemblyName { Name = "QueryLanguageFeatureClass" };

        /// <summary>
        /// Atributos por defecto para una clase
        /// </summary>
        private static readonly TypeAttributes ClassAttributes = TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Serializable;

        /// <summary>
        /// Módulo de ensamblado dinámico
        /// </summary>
        private static ModuleBuilder _moduleBuilder;

        /// <summary>
        /// Número de instancias creadas
        /// </summary>
        private static ConcurrentDictionary<ClassSignature, Type> CreatedClasses = new ConcurrentDictionary<ClassSignature, Type>();

        /// <summary>
        /// Atributos para cada propiedad creados por cada tipo
        /// </summary>
        private static ConcurrentDictionary<Type, IEnumerable<CustomAttributeBuilder>> ClassAttributeBuilders = new ConcurrentDictionary<Type, IEnumerable<CustomAttributeBuilder>>();

        /// <summary>
        /// Atributos para cada propiedad creados por cada tipo
        /// </summary>
        private static ConcurrentDictionary<PropertyInfo, IEnumerable<CustomAttributeBuilder>> PropertyAttributeBuilders = new ConcurrentDictionary<PropertyInfo, IEnumerable<CustomAttributeBuilder>>();

        /// <summary>
        /// Gestor de bloqueos
        /// </summary>
        private static ReaderWriterLock _rwLock;

        /// <summary>
        /// Nombre por defecto para todas las clases
        /// </summary>
        private const string DefaultClassNameSuffix = "QueryLanguageClass";

        #endregion

        #region Constructores

        static ClassFactory()
        {
        }

        public ClassFactory()
        {
            _moduleBuilder = Thread
                .GetDomain()
                .DefineDynamicAssembly(AssemblyName, AssemblyBuilderAccess.Run)
                .DefineDynamicModule(AssemblyName.Name);

            _rwLock = new ReaderWriterLock();
        }

        #endregion

        #region Métodos públicos

        //public Type Create(Type sourceType, IEnumerable<PropertyInfo> properties)
        //{
        //    if ( !properties.Any() )
        //    {
        //        throw new ArgumentOutOfRangeException("properties");
        //    }

        //    var dictionary = properties.ToDictionary(p => p.Name, propInfo => propInfo);

        //    _rwLock.AcquireReaderLock(Timeout.Infinite);

        //    try
        //    {
        //        //return Created
        //        //return new Type();
        //    }
        //    finally
        //    {
        //    }
        //}

        #endregion

        #region Métodos privados

        #region CreateClass
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        //private Type CreateClass(Type sourceType, IEnumerable<PropertyInfo> properties)
        //{
        //    LockCookie cookie = _rwLock.UpgradeToWriterLock(Timeout.Infinite);

        //    try
        //    {
        //        var typeName = DefaultClassNameSuffix + (CreatedClasses.Count + 1).ToString();
        //        var typeBuilder = _moduleBuilder.DefineType(typeName, ClassAttributes);

                
        //    }
        //    finally
        //    {
        //    }
        //}

        #endregion

        #region CreateProperties
        /// <summary>
        /// Creación de propiedades
        /// </summary>
        /// <param name="typeBuilder"></param>
        /// <param name="properties"></param>
        private void CreateProperties(TypeBuilder typeBuilder, IEnumerable<PropertyInfo> properties)
        {
            Verify.ArgumentNotNull(typeBuilder);
            Verify.ArgumentNotNull(properties);
        }

        #endregion

        #region SetAttributes(TypeBuilder)

        private void SetAttribute(TypeBuilder typeBuilder, Type type)
        {
            Verify.ArgumentNotNull(typeBuilder);
            Verify.ArgumentNotNull(type);

            var attrbuilders = ClassAttributeBuilders
                .GetOrAdd(type,
                            t =>
                            {
                                var customAttr = t.GetCustomAttributesData();
                                return create
                            });
        }

        #endregion

        #endregion
    }
}

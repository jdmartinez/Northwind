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
using ServiceStack.ServiceInterface;
using ManHouse.ServiceBase;
using ManHouse.ServiceModel.Dto;
using ManHouse.ServiceModel.Contracts;
using ManHouse.Data.Model;


namespace ManHouse.ServiceInterface.Services
{
    /// <summary>
    /// Servicio de <see cref="Customer"/>
    /// </summary>
    public class CustomersService : Servicebase<CustomerEntity, Customer>
    {
        /// <summary>
        /// Recuperación de <see cref="Order"/> para un <see cref="Customer"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public object Get(CustomerOrders request)
        {
            var cacheKey = new Cach
        }
    }
}

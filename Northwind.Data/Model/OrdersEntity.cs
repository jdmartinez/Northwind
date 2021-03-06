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
using System.Web;
using ServiceStack.OrmLite;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace Northwind.Data.Model
{
	[Alias("Orders")]
	public partial class OrderEntity : IEntity, IHasId<long> 
    {
        [Alias("Id")]
        [Required]
        public long Id { get; set;}

        [StringLength(8000)]
		[References(typeof(CustomerEntity))]
        public string CustomerId { get; set;}
        
		[Required]
		[References(typeof(EmployeeEntity))]
        public long EmployeeId { get; set;}
        
		[StringLength(8000)]
        public string OrderDate { get; set;}
        
		[StringLength(8000)]
        public string RequiredDate { get; set;}
        
		[StringLength(8000)]
        public string ShippedDate { get; set;}
        
		public long? ShipVia { get; set;}
        
		[Required]
        public decimal Freight { get; set;}
        
		[StringLength(8000)]
        public string ShipName { get; set;}
        
		[StringLength(8000)]
        public string ShipAddress { get; set;}
        
		[StringLength(8000)]
        public string ShipCity { get; set;}
        
		[StringLength(8000)]
        public string ShipRegion { get; set;}
        
		[StringLength(8000)]
        public string ShipPostalCode { get; set;}
        
		[StringLength(8000)]
        public string ShipCountry { get; set;}

		public DateTime LastUpdated { get; set; }

		[Ignore]
		public virtual List<OrderDetailEntity> Details { get; set; }
    }
}


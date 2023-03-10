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
    [Alias("Users")]
    public partial class UsersEntity : IEntity, IHasId<byte[]>
    {
        [Alias("Id")]
        [Required]
        public byte[] Id { get; set; }

        [Required]
        [StringLength(8000)]        
        public string UserName { get; set; }

        [Required]
        [StringLength(8000)]
        public string Password { get; set; }

        [Required]
        [StringLength(8000)]
        public string FullName { get; set; }

        [Ignore]
        public DateTime LastUpdated { get; set; }
        
    }
}


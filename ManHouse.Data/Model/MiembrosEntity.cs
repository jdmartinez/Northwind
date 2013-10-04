#region Licencia
/*
   Copyright 2013 Juan Diego Martinez - Félix Amorós

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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;

namespace ManHouse.Data.Model
{
    [Alias("Miembros")]
    [ETag("Id", "LastUpdated")]
    public partial class MiembroEntity : IEntity, IHasId<string>
    {
        [Alias("Id")]
        [StringLength(8000)]
        [Required]
        public string Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Apellidos { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}

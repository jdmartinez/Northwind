using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManHouse.ServiceBase;

namespace ManHouse.ServiceModel.Dto
{
    /// <summary>
    /// Clase que representa una entidad <see cref="Miembro"/>
    /// </summary>
    public class Miembro : CommonDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}

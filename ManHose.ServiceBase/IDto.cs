using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManHouse.ServiceBase
{
    /// <summary>
    /// Interfaz que representa un DTO (Data Transfer Object)
    /// </summary>
    public interface IDto
    {
        /// <summary>
        /// Enlace a la entidad
        /// </summary>
        Uri Link { get; }
    }
}

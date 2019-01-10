using System;
using System.Collections.Generic;
namespace APITestDGT.Modelos
{
    /// <summary>
    /// CLase de entidad Vehiculos
    /// </summary>
    public class Vehiculo
    {
        /// <summary>
        /// Matricula y campo clave del vehiculo
        /// </summary>
        public string matricula { get; set; }
        /// <summary>
        /// Marca del vehiculo
        /// </summary>
        public string marca { get; set; }
        /// <summary>
        /// Modelo del vehiculo
        /// </summary>
        public string modelo { get; set; }
        /// <summary>
        /// Conductores del vehiculo
        /// </summary>
        public List<Conductor> conductores { get; set; }

    }
}

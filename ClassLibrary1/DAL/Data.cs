using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITestDGT.Modelos;

namespace APITestDGT.DAL
{
    /// <summary>
    /// Clase de servicio que representa el almacen de datos 
    /// En un entorno "real" esto sería por ejemplo el Datacontext o la base de datos 
    /// </summary>
    public static class Data
    {        
        /// <summary>
        /// Representa la tabla conductores
        /// </summary>
        public static List<Conductor> Conductores { get; set; }
        /// <summary>
        /// Representa la tabla vehiculos
        /// </summary>
        public static List<Vehiculo> Vehiculos { get; set; }
        /// <summary>
        /// Representa la tabla tipos infraccion
        /// </summary>
        public static List<TipoInfraccion> TiposInfraccion { get; set; }
        /// <summary>
        /// Representa la tabla infracciones
        /// </summary>
        public static List<Infraccion> Infracciones { get; set; }
    }
}

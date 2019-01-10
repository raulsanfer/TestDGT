using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestDGT.Modelos
{
    /// <summary>
    /// Clase de entidad Infraccion
    /// </summary>
    public class Infraccion
    {
        ///campo clave 
        public long id { get; set; }    
        ///Fecha Infraccion
        public DateTime fechahora { get; set; }        
        /// <summary>
        /// Tipo de la infracción 
        /// </summary>
        public TipoInfraccion tipo { get; set; }        
        /// <summary>
        /// Conductor de la infraccion
        /// </summary>
        public Conductor conductor { get; set; }
        /// <summary>
        /// Vehiculo de la infraccion
        /// </summary>
        public Vehiculo vehiculo { get; set; }

    }
}

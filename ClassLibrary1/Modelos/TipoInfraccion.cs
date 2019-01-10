using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestDGT.Modelos
{
    /// <summary>
    /// Entidad para definir TipoInfraccion 
    /// </summary>
    public class TipoInfraccion
    {
        /// <summary>
        /// Campo clave del tipo infraccion
        /// </summary>
        public short id { get; set; }
        /// <summary>
        /// Descripcion del tipo de infraccion
        /// </summary>       
        public string descripcion { get; set; }
        /// <summary>
        /// puntos a descontar del tipo
        /// </summary>
        public short puntos_descontar { get; set; }

    }
}

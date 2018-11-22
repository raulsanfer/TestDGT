using ClassLibrary1.Modelos.Interfaces;
using System;
using System.Collections.Generic;
namespace ClassLibrary1.Modelos
{
    /// <summary>
    /// Implementacion de Persona, para concretar las caracteristicas del Conductor
    /// como el número de puntos de trafico
    /// </summary>
    public class Conductor : IPersona
    {        
        /// <summary>
        /// Campo clave de la entidad, se entiende que el dni no se repite
        /// </summary>
        public string DNI {get;set;}
        /// <summary>
        /// nombre del conductor
        /// </summary>
        public string nombre{get;set;}
        /// <summary>
        /// Apellidos del conductor
        /// </summary>
        public string apellidos{get;set;}
        /// <summary>
        /// numero de puntos actuales 
        /// </summary>
        public Int16 numero_puntos { get; set; }
        /// <summary>
        /// vehiculos asociados  del conductor
        /// </summary>
        public List<Vehiculo> vehiculos { get; set; }
        /// <summary>
        /// Infracciones asociadas al conductor
        /// </summary>
        public List<Infraccion> infracciones { get; set; }

    }
}

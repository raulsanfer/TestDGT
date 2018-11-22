using System;
namespace ClassLibrary1.Modelos.Interfaces
{
    /// <summary>
    /// Interface para generalizar el sujeto
    /// </summary>
    public interface IPersona
    {
        /// <summary>
        /// Propiedad del interfaz de Persona
        /// </summary>
        string DNI { get; set; }
        /// <summary>
        /// Propiedad nombre
        /// </summary>
        string nombre { get; set; }
        /// <summary>
        /// Propiedad Apellidos
        /// </summary>
        string apellidos{get;set;}       
    }
}

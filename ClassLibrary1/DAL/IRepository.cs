using System;
using System.Collections.Generic;

namespace APITestDGT.DAL
{
    /// <summary>
    /// Interfaz Repositorio, base para centralizar los metodos de acceso a datos a implementar
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorio<T>
    {
        /// <summary>
        /// Metodo agregar del repositorio
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Agregar(T item);
        /// <summary>
        /// Metodo Actualizar entidad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Actualizar(T item);
        /// <summary>
        /// Metodo Eliminar entidad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Borrar(T item);
        /// <summary>
        /// Metodo Obtener todos genérico
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ObtenerTodos();
    }
}

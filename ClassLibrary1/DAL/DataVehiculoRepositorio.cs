using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Modelos;
namespace ClassLibrary1.DAL
{
    /// <summary>
    /// Clase de repositorio para tratar los vehiculos
    /// </summary>
    public class DataVehiculoRepositorio : IRepositorio<Vehiculo>
    {
        public bool Agregar(Vehiculo item)
        {
            try
            {
                if (Data.Vehiculos == null)
                    Data.Vehiculos = new List<Vehiculo>();

                Data.Vehiculos.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Actualizar(Vehiculo item)
        {
            try
            {               
                //todo actualizar

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Borrar(Vehiculo item)
        {
            try
            {
                //todo borrar
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Vehiculo> ObtenerTodos()
        {
            try
            {
                return Data.Vehiculos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo personalizado para obtener un vehiculo por su matricula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public Vehiculo ObtenerPorMatricula(string matricula)
        {
            try
            {
                if (Data.Vehiculos != null)
                    return Data.Vehiculos.Find(x => x.matricula == matricula);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}

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
    /// Clase de repositorio para las infracciones
    /// </summary>
    public class DataInfraccionRepositorio : IRepositorio<Infraccion>
    {        
        public bool Agregar(Infraccion item)
        {
            try
            {
                if (Data.Infracciones == null)
                    Data.Infracciones = new List<Infraccion>();

                Data.Infracciones.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Actualizar(Infraccion item)
        {
            try
            {                
                //if(Data.Infracciones!=null)
                  //  Data.Infracciones.Find

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Borrar(Infraccion item)
        {
            try
            {
                //if(Data.Infracciones!=null)
                //  Data.Infracciones.Find

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Infraccion> ObtenerTodos()
        {
            try
            {
                if (Data.Infracciones != null)
                    return Data.Infracciones;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Metodo personalizado que obtiene las infracciones por dni de conductor
        /// </summary>
        /// <param name="pDni"></param>
        /// <returns></returns>
        public IEnumerable<Infraccion> ObtenerPorDNI(string pDni)
        {
            try
            {
                if (Data.Infracciones != null)
                    return Data.Infracciones.FindAll(x=>x.conductor.DNI==pDni);
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

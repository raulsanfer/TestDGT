using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITestDGT.Modelos;
namespace APITestDGT.DAL
{
    /// <summary>
    /// Clase de repositorio para el tipo de infraccion
    /// </summary>
    public class DataTipoInfraccionRepositorio : IRepositorio<TipoInfraccion>
    {        
        public bool Agregar(TipoInfraccion item)
        {
            try
            {
                if (Data.TiposInfraccion == null)
                    Data.TiposInfraccion = new List<TipoInfraccion>();

                Data.TiposInfraccion.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Actualizar(TipoInfraccion item)
        {
            try
            {                
                //if(Data.TipoInfracciones!=null)
                  //  Data.TipoInfracciones.Find

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Borrar(TipoInfraccion item)
        {
            try
            {
                //if(Data.TipoInfracciones!=null)
                //  Data.TipoInfracciones.Find

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<TipoInfraccion> ObtenerTodos()
        {
            try
            {
                if (Data.TiposInfraccion != null)
                    return Data.TiposInfraccion;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// metodo personalizado para obtener un tipo de infraccion por su ID
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public TipoInfraccion ObtenerPorId(short pId)
        {
            try
            {
                if (Data.TiposInfraccion != null)
                    return Data.TiposInfraccion.Find(x=>x.id==pId);
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

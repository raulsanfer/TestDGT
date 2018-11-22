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
    /// Clase de repositorio para el Conductor
    /// </summary>
    public class DataConductorRepositorio : IRepositorio<Conductor>
    {        
        public bool Agregar(Conductor item)
        {
            try
            {
                if (Data.Conductores == null)
                    Data.Conductores = new List<Conductor>();
                                
                Data.Conductores.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Actualizar(Conductor item)
        {
            try
            {
                if (item != null)
                {
                    Conductor C = Data.Conductores.Find(x => x.DNI == item.DNI);
                    if (C != null)
                    {

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Borrar(Conductor item)
        {
            try
            {
                //if(Data.Conductores!=null)
                //  Data.Conductores.Find

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Conductor> ObtenerTodos()
        {
            try
            {
                return Data.Conductores;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Conductor ObtenerPorDNI(string dni)
        {
            try
            {
                if (Data.Conductores != null)
                    return Data.Conductores.Find(x => x.DNI == dni);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITestDGT;
using APITestDGT.DAL;
using APITestDGT.Modelos;
namespace TestDGT
{
    class Program
    {
        /// <summary>
        /// Punto de entrada de Aplicacion de Consola
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "TestDGT";// typeof(Program).Name;
            LoadMenu();
            Run();            
        }
        /// <summary>
        /// Metodo para generar el menú inicial de la consola
        /// </summary>
        static void LoadMenu()
        {
            SalidaConsola("10. Agregar Conductor");
            SalidaConsola("20. Agregar Vehículo");
            SalidaConsola(" - 21. Agregar Conductor a Vehículo");
            SalidaConsola("30. Agregar Tipo Infracción ");
            SalidaConsola("40. Agregar Infracción");
            SalidaConsola("50. Consultar historial infracciones por Conductor");
            SalidaConsola("51. Consultar 5 tipos infracción mas comunes");
            SalidaConsola(" ");
            //SalidaConsola("50. Agregar Infracción a Vehiculo (hh:mm;dd/mm/yyyy;matricula)");
        }

        /// <summary>
        /// Metodo que controla la entrada del usuario desde la consola
        /// Espera un parámetro y lo ejecuta, enviando el control al método Execute
        /// </summary>
        static void Run()
        {           

            while (true)
            {
                var consoleInput = LeerConsola("Elija una opción: ");
                if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                try
                {
                    // Ejecutar Comando
                    Execute(consoleInput);                   
                }
                catch (Exception ex)
                {
                    //mostrar error en consola
                    SalidaConsola(ex.Message);
                }
            }
        }
        /// <summary>
        /// Metodo para ejecutar el comando introducido en consola
        /// </summary>
        /// <param name="command"></param>
        static void Execute(string command)
        {
            string cadenaEntrada = string.Empty;

            //En el switch siguiente se toma el valor introducido por el usuario y se ejecuta 
            //una serie de instrucciones que devuelven un resultado a consola 
            switch (command.Trim())
            {
                case "10":
                    //queremos introducir un conductor
                    //solicitar ahora los datos separados por ;
                    cadenaEntrada = LeerConsola("Introduzca los datos del CONDUCTOR (DNI;nombre;apellidos;puntos): ");                    
                    try
                    {
                        List<String> parametros = cadenaEntrada.Split(';').ToList();
                        
                        if (parametros.Count > 1)
                        {
                            Conductor C = new Conductor();
                            C.DNI = parametros[0].ToString();//DNI
                            C.nombre = parametros[1].ToString();//nombre
                            C.apellidos = parametros[2].ToString();//apellidos
                            C.numero_puntos = Int16.Parse(parametros[3].ToString());//puntos
                            C.vehiculos = new List<Vehiculo>();

                            //instanciamos el repositorio de Conductor para consultarlo
                            DataConductorRepositorio db = new DataConductorRepositorio();                                                    
                            if (db.ObtenerPorDNI(C.DNI) == null)                            
                            {                                
                                db.Agregar(C);
                                List<Conductor> Conductores = (List<Conductor>)db.ObtenerTodos();
                                SalidaConsola(Conductores.Count.ToString() + " conductor agregado");
                            }
                            else
                            {
                                SalidaConsola("El conductor ya existe");
                            }                            
                        }
                        else
                        {
                            SalidaConsola(Constantes._entradaIncorrecta);
                        }
                    }
                    catch (Exception ex)
                    {
                        SalidaConsola(Constantes._ocurrioError);                        
                    }                                        
                    break;

                case "20":
                    //queremos introducir un vehiculo
                    //solicitar ahora los datos del vehiculo
                    cadenaEntrada = LeerConsola("Introduzca los datos del VEHÍCULO (matrícula;marca;modelo;DNI conductor habitual): ");                    
                    try
                    {
                        //la cadena de entrada se procesa para obtener los parametros
                        List<String> parametros = cadenaEntrada.Split(';').ToList();
                        if (parametros.Count > 1)
                        {
                            //instanciar el repositorio para tenerlo disponible 
                            DataVehiculoRepositorio dbVehiculo = new DataVehiculoRepositorio();

                            //1º obtener la matricula por si ya existe
                            string matricula = parametros[0].ToString();//matricula
                            if (dbVehiculo.ObtenerPorMatricula(matricula) != null)
                            {
                                //devolver error
                                SalidaConsola("El vehiculo ya existe");
                                break;
                            }

                            //2º consultar el dni del conductor habitual por si no existe
                            //en caso de que no exista 
                            string dni_habitual = parametros[3].ToString();//DNI
                            DataConductorRepositorio dbConductor=new DataConductorRepositorio();
                            Conductor conductor_habitual = dbConductor.ObtenerPorDNI(dni_habitual);
                            if(conductor_habitual==null)
                            {
                                //devolver error
                                SalidaConsola("El conductor no existe, agregue el conductor antes de guardar el vehículo");
                                break;
                            }
                            else  if(conductor_habitual.vehiculos.Count==10)
                            {
                                //devolver error
                                SalidaConsola("El conductor ya tiene 10 vehículos asignados, no puede tener más");
                                break;
                            }

                            //si todo ha ido bien se agregará el vehículo
                            //generamos el vehiculo y asignamos el conductor al mismo, 
                            //el primer conductor asignado al vehiculo será su conductor habitual
                            Vehiculo V = new Vehiculo();
                            V.matricula = matricula;
                            V.marca = parametros[1].ToString();//marca
                            V.modelo = parametros[2].ToString();//modelo                             
                            V.conductores = new List<Conductor>();
                            V.conductores.Add(conductor_habitual);

                            dbVehiculo.Agregar(V);
                            
                            //una vez agregado el vehiculo, 
                            //lo agregamos tambien como vehículo del conductor                             
                            if (conductor_habitual.vehiculos == null)
                                conductor_habitual.vehiculos = new List<Vehiculo>();                                                    

                            conductor_habitual.vehiculos.Add(V);
                            
                            //finalmente mostramos el resumen
                            List<Vehiculo> TotalVehiculos = (List<Vehiculo>)dbVehiculo.ObtenerTodos();                            
                            SalidaConsola(TotalVehiculos.Count.ToString() + " vehículo/s agregado");
                            
                        }
                        else
                        {
                            SalidaConsola(Constantes._entradaIncorrecta);
                        }
                    }
                    catch (Exception ex)
                    {
                        SalidaConsola(Constantes._ocurrioError);
                    }
                    break;
                case "21":
                    //queremos asignar un conductor a un vehiculo                    
                    cadenaEntrada = LeerConsola("Introduzca los datos para agregar un conductor a un vehículo (matrícula;DNI): ");
                    try
                    {
                        //la cadena de entrada se procesa para obtener los parametros
                        List<String> parametros = cadenaEntrada.Split(';').ToList();
                        if (parametros.Count > 1)
                        {
                            //instanciar el repositorio para tenerlo disponible 
                            DataVehiculoRepositorio dbVehiculo = new DataVehiculoRepositorio();

                            //1º obtener la matricula por si ya existe
                            string matricula = parametros[0].ToString();//matricula
                            Vehiculo V = dbVehiculo.ObtenerPorMatricula(matricula);
                            if (V == null)
                            {
                                //devolver error
                                SalidaConsola("El vehiculo no existe");
                                break;
                            }

                            //2º consultar el dni del conductor a agregar por si no existe                            
                            string dni_habitual = parametros[1].ToString();//DNI
                            DataConductorRepositorio dbConductor = new DataConductorRepositorio();
                            Conductor conductor_habitual = dbConductor.ObtenerPorDNI(dni_habitual);
                            if (conductor_habitual == null)
                            {
                                //devolver error
                                SalidaConsola("El conductor no existe, agregue el conductor antes");
                                break;
                            }
                            //por si la coleccion de conductores es nula (aunque no debe serlo, pues se habra inicializado al crearlo)
                            if(V.conductores == null)
                                V.conductores = new List<Conductor>();
                            else
                                if (V.conductores.Find(x => x.DNI == conductor_habitual.DNI) != null)
                                {
                                    SalidaConsola("El conductor ya está asignado a este vehículo");
                                    break;
                                }
                            V.conductores.Add(conductor_habitual);
                            //agregamos el vehiculo
                            dbVehiculo.Agregar(V);

                            //agregamos ahora el vehiculo como vehiculo del contacto tambien
                            if (conductor_habitual.vehiculos == null)
                                conductor_habitual.vehiculos = new List<Vehiculo>();
                            conductor_habitual.vehiculos.Add(V);

                            //finalmente mostramos el resumen                            
                            SalidaConsola(V.conductores.Count.ToString() + " conductor/es agregado al vehiculo");
                        }
                        else
                        {
                            SalidaConsola(Constantes._entradaIncorrecta);
                        }
                    }
                    catch (Exception ex)
                    {
                        SalidaConsola(Constantes._ocurrioError);
                    }
                    break;
                case "30":
                    //queremos introducir un tipo de infracción
                    //solicitar ahora los datos separados por ;
                    cadenaEntrada = LeerConsola("Introduzca los datos del TIPO INFRACCION (ID (INT);descripción;puntos a descontar): ");
                    try
                    {
                        List<String> parametros = cadenaEntrada.Split(';').ToList();
                        if (parametros.Count > 1)
                        {
                            DataTipoInfraccionRepositorio dbTipoInfraccion = new DataTipoInfraccionRepositorio();
                            TipoInfraccion TI = new TipoInfraccion();
                            if(dbTipoInfraccion.ObtenerTodos()!=null)
                                TI = dbTipoInfraccion.ObtenerTodos().LastOrDefault<TipoInfraccion>();

                            //A continuación se calcula el ID para la entidad 
                            //es un metodo adaptado a la situación practica
                            //en entorno de produccion, el id podría ser identidad o generado por guid
                            short id = 1;
                            if (TI != null)
                                id = (short)(TI.id+1);
                            
                            TI =  new TipoInfraccion();
                            TI.id = short.Parse(parametros[0].ToString());
                            TI.descripcion = parametros[1].ToString();//descripcion
                            TI.puntos_descontar = Int16.Parse(parametros[2].ToString());

                            dbTipoInfraccion.Agregar(TI);

                            //lanzamos resumen tras operación
                            List<TipoInfraccion> TotalTiposInfraccion = (List<TipoInfraccion>)dbTipoInfraccion.ObtenerTodos();
                            SalidaConsola(TotalTiposInfraccion.Count.ToString() + " Tipo/s de Infraccion agregado");

                        }
                        else
                        {
                            SalidaConsola(Constantes._entradaIncorrecta);
                        }
                    }
                    catch (Exception ex)
                    {
                        SalidaConsola(Constantes._ocurrioError);
                    }
                    break;

                case "40":
                    //queremos introducir un infracción                                 
                    cadenaEntrada = LeerConsola("Introduzca los datos de la INFRACCION (ID tipo infraccion;hh:mm;dd/mm/yyyy;matrícula): ");
                    try
                    {
                        List<String> parametros = cadenaEntrada.Split(';').ToList();
                        if (parametros.Count > 1)
                        {
                            short idTipoInfraccion = short.Parse(parametros[0].ToString());//tipo infraccion
                            string hora = parametros[1].ToString();//hora en texto
                            string fecha = parametros[2].ToString();//fecha en texto
                            //string dni = parametros[3].ToString();//dni del conductor
                            string matricula = parametros[3].ToString();//matricula
                                                        
                            Infraccion I = new Infraccion(); 
                            //calculo del ID
                            long id = 1;
                            if (I != null)
                                id = I.id + 1;
                            else
                                I = new Infraccion();

                            I.id = id;//asignamos el ID obtenido en funcion de si existen otras infracciones

                            //obtener el tipo de infraccion, con su información correspondiente de puntos a descontar
                            DataTipoInfraccionRepositorio dbTipoInfraccion = new DataTipoInfraccionRepositorio();
                            TipoInfraccion TI = dbTipoInfraccion.ObtenerPorId(idTipoInfraccion);

                            I.tipo = TI;//asignamos el tipo a la infraccion

                            //obtener el vehiculo de la infraccion
                            DataVehiculoRepositorio dbVehiculo = new DataVehiculoRepositorio();
                            Vehiculo V = dbVehiculo.ObtenerPorMatricula(matricula);
                            if (V == null)
                            {
                                //el vehiculo no existe...
                                SalidaConsola("El vehiculo no existe");
                                break;
                            }
                            I.vehiculo = V;//asignamos el vehiculo a la infraccion

                            //continuamos, ahora obtenemos el conductor habitual del vehiculo para descontarle los puntos
                            DataConductorRepositorio dbConductor = new DataConductorRepositorio();
                            dbConductor.ObtenerPorDNI(V.conductores[0].DNI).numero_puntos-=TI.puntos_descontar;
                            
                            Conductor C = dbConductor.ObtenerPorDNI(V.conductores[0].DNI);
                            I.conductor = C;//asignamos el conductor a la infraccion

                            //obtenemos un formato datetime de la hora y la fecha indicadas en la infraccion
                            DateTime fecha_hora = DateTime.Now;
                            if (hora != string.Empty & fecha != string.Empty)
                            {
                                 fecha_hora = DateTime.Parse(string.Format("{0} {1}", fecha, hora));
                            }
                            
                            //asignamos la fecha y hora a la infraccion
                            I.fechahora = fecha_hora;                            
                            
                            //finalmente grabamos la infraccion
                            DataInfraccionRepositorio dbInfraccion = new DataInfraccionRepositorio();
                            dbInfraccion.Agregar(I);

                            List<Infraccion> TotalInfraccion = (List<Infraccion>)dbInfraccion.ObtenerTodos();
                            SalidaConsola(TotalInfraccion.Count.ToString() + " Infraccion agregado");
                            SalidaConsola(string.Format("El conductor con DNI: {0} tiene ahora {1} puntos",C.DNI,C.numero_puntos.ToString()));
                        }
                        else
                        {
                            SalidaConsola(Constantes._entradaIncorrecta);
                        }
                    }
                    catch (Exception ex)
                    {
                        SalidaConsola(Constantes._ocurrioError);
                    }
                    break;

                case "50":
                    //queremos consultar las infracciones del conductor                          
                    cadenaEntrada = LeerConsola("Introduzca el DNI del conductor: ");
                    try
                    {
                        List<String> parametros = cadenaEntrada.Split(';').ToList();
                        if (parametros.Count > 0)
                        {
                            string dni = parametros[0].ToString();//dni conductor                                                                                   
                            
                            //recogemos informacion del conductor
                            DataConductorRepositorio dbConductor = new DataConductorRepositorio();
                            Conductor C = dbConductor.ObtenerPorDNI(dni);
                            if (C == null)
                            {
                                SalidaConsola("El conductor no existe");
                                break;
                            }
                            //recogemos informacion de las infracciones del mismo
                            DataInfraccionRepositorio dbInfraccion = new DataInfraccionRepositorio();
                            List<Infraccion> listaInfracciones = (List<Infraccion>)dbInfraccion.ObtenerPorDNI(dni);
                            if (listaInfracciones.Count > 0)
                            {
                                DataTipoInfraccionRepositorio dbTipoInfraccion = new DataTipoInfraccionRepositorio();

                                SalidaConsola(string.Format("INFRACCIONES DE {0} {1}", C.nombre, C.apellidos));
                                foreach (Infraccion item in listaInfracciones)
                                {
                                    TipoInfraccion TI = dbTipoInfraccion.ObtenerPorId(item.tipo.id);
                                    SalidaConsola(string.Format("{0} - {1}", TI.descripcion, item.fechahora.ToString()));
                                }
                                SalidaConsola("-----------------------");
                                SalidaConsola(string.Format("Puntos restantes:{0}", C.numero_puntos.ToString()));
                            }
                            else
                            {
                                SalidaConsola("El conductor no tiene infracciones");
                                break;
                            }
                        }
                        else
                        {
                            SalidaConsola(Constantes._entradaIncorrecta);
                        }
                    }
                    catch (Exception ex)
                    {
                        SalidaConsola(Constantes._ocurrioError);
                    }
                    break;
                case "51":
                    //queremos consultar los 5 tipos de infraccion mas comunes
                    try
                    {                        
                        //recogemos informacion de las infracciones del mismo
                        DataInfraccionRepositorio dbInfraccion = new DataInfraccionRepositorio();
                        List<Infraccion> listaInfracciones = (List<Infraccion>)dbInfraccion.ObtenerTodos();
                        if (listaInfracciones.Count > 0)
                        {
                            DataTipoInfraccionRepositorio dbTipoInfraccion = new DataTipoInfraccionRepositorio();

                            var multas =
	                                    from I in listaInfracciones
	                                    group I by I.tipo.descripcion into g
                                        select new { g.Key, puntos = g.Sum(x => x.tipo.puntos_descontar) };

                            SalidaConsola(string.Format("5 TIPOS DE INFRACCIÓN MAS COMUNES"));
                            foreach (dynamic item in multas)
                            {                                
                                SalidaConsola(string.Format("{0} - {1}", item.Key, item.puntos.ToString()));
                            }
                            SalidaConsola("-----------------------");
                            //SalidaConsola(string.Format("Puntos restantes:{0}", C.numero_puntos.ToString()));
                        }
                        else
                        {
                            SalidaConsola("No se han encontrado infracciones");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        SalidaConsola(Constantes._ocurrioError);
                    }
                    break;
                default:
                    break;
            }
            //tras ejecutar el comando volvemos a solicitar operación
            Run();            
        }

        /// <summary>
        /// Método para escribir texto a Consola para informar al usuario
        /// </summary>
        /// <param name="message"></param>
        public static void SalidaConsola(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }      
        

        /// <summary>
        /// Metodo para recogida de parámetros de la consola
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <returns></returns>
        public static string LeerConsola(string promptMessage = "")
        {
            // muestra el prompt y obtiene la entrada del usuario            
            Console.Write(Constantes._readPrompt + promptMessage);
            return Console.ReadLine();
        }
    }
    static class Constantes
    {
        public const string _readPrompt = "> ";
        public const string _entradaIncorrecta = "No se ha introducido nada o no es correcto el parámetro";
        public const string _ocurrioError = "Ocurrió un Error, vuelva a seleccionar opción";
    }
}

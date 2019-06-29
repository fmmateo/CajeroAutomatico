using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class Utilidades
    {
        static string path = Directory.GetCurrentDirectory() + "\\";

        static string[] Sucursar = new string[3] { "BANRESERVAS", "POPULAR", "BHD" };
    
         public void MenuSucursales()
        {
            Console.WriteLine("SELECCIONE LA SUCURSAR QUE DESEE:");
            Console.WriteLine("");
            Console.WriteLine("1)BANCO BANRESERVAS");
            Console.WriteLine("");
            Console.WriteLine("2)BANCO POPULAR");
            Console.WriteLine("");
            Console.WriteLine("3)BANCO BHD");
        }

        public void TituloMenu()

        {
            Console.WriteLine("CAJERO AUTOMATICO");
            Console.WriteLine("");
        }


        public void ValidarUsuario(string sucursar)
        {
            string cedula;

            Console.Clear();
            TituloMenu();
            Console.WriteLine("INGRESE SU CEDULA:");
            Console.WriteLine("");

            cedula = Console.ReadLine();


            switch (sucursar)

            {
                case "1":
                    LeerCedula(path + "BANRESERVAS", cedula);
                    break;

                case "2":
                    LeerCedula(path + "POPULAR",cedula);
                    break;

                case "3":
                    LeerCedula(path + "BHD",cedula);
                    break;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("TECLA INCORRECTA");
                    break;
            }
        }



        public void LeerCedula(string ruta, string cedula)
        {
            string[] ListaCedula = Directory.GetFiles(ruta );

            if (ListaCedula.Length == 0)
            {
                Console.WriteLine("NO TIENE CREDENCIALES, PASAREMOS A LA SECCION DE CREACION DE USUARIO");
                Console.WriteLine("");
                CrearUsuario(cedula, ruta);
            }
            else
            {
                foreach (var item in ListaCedula)
                {
                    if (item.Contains(cedula))
                    {
                        Utilidad.RutaUsuario = item;
                        Console.Clear();
                        LeerDatosUsuarios(item);
                        MenuDelCajero();
                        OpcionSelecionada(Console.ReadLine());
                        Utilidad.RutaUsuario = item ;
                    }
                    else
                    {
                        Console.WriteLine("NO TIENE CREDENCIALES, PASAREMOS A LA SECCION DE CREACION DE USUARIO");
                        Console.WriteLine("");
                        CrearUsuario(cedula, ruta);
                    }
                }
            }

        }

        public void CrearUsuario(string CEDULA, string RutaCompleta )
        {
            Console.Clear();

            Guardar_Usuario usuario = new Guardar_Usuario();


            Console.WriteLine("");
            Console.WriteLine("FORMULARIO PARA CREAR NUEVO USUARIO");
            Console.WriteLine("");
            Console.WriteLine("AGREGAR SU NOMBRE:");
            usuario.Nombre = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("AGREGAR SU CEDULA:");
            usuario.Cedula = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("AGREGAR SU NUMERO:");
            usuario.Numero = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("AGREGAR EL MONTO DESEADO PARA ABRIR LA CUENTA:");
            usuario.Monto = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("");

            Historial historial = new Historial();
            historial.Detalles = "SE CREO EL USUARIO";
            historial.Fecha = DateTime.Now.ToString();

            usuario.Historial.Add(historial);

            string json = JsonConvert.SerializeObject(usuario);

            System.IO.File.WriteAllText(RutaCompleta + $"//{usuario.Cedula}.json", json);

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("SE AGREGO CON EXITO");
        }

       

        public void CrearCarpetas()
        {

            for (int i = 0; i < 3; i++)
            {

                if (!Directory.Exists(path + Sucursar[i]))
                {
                    Directory.CreateDirectory(path + Sucursar[i]);



                }


            }

        }

        public void LeerDatosUsuarios(string rutaDatosUsuarios)
        {
            
            using (StreamReader jsonStream = File.OpenText(rutaDatosUsuarios))
            {
                var json = jsonStream.ReadToEnd();
                Guardar_Usuario usuario = JsonConvert.DeserializeObject<Guardar_Usuario>(json);

                Usuario.Nombre = usuario.Nombre;
                Usuario.Cedula = usuario.Cedula;
                Usuario.Numero = usuario.Numero;
                Usuario.Monto = usuario.Monto;
            }
        }

        public void MenuDelCajero()
        {
            Console.WriteLine("CAJERO AUTOMATICO:");
            Console.WriteLine("");
            Console.WriteLine("1)CONSULTA DE BALANCE");
            Console.WriteLine("");
            Console.WriteLine("2)RETIRO EFECTIVO");
            Console.WriteLine("");
            Console.WriteLine("3)TRANSFERENCIAS");
            Console.WriteLine("");
            Console.WriteLine("4)DEPOSITAR DINERO");
            Console.WriteLine("");
            Console.WriteLine("5)RECARGAS TELEFONICAS");
            Console.WriteLine("");
          

        }

        public void OpcionSelecionada(string opcion)
        {
            Console.Clear();
            TituloMenu();
            switch (opcion)
            {
                case "1":
                    ConsultaBalance consulta = new ConsultaBalance();
                    break;

                case "2":
                    RetiroEfectivo retiro = new RetiroEfectivo();
                    break;

                case "3":
                    Transferencia transferencia = new Transferencia();
                    break;

                case "4":
                    DepositarDinero depositarDinero = new DepositarDinero();
                    break;

                case "5":
                    RecargasTelefonicas recargas = new RecargasTelefonicas();
                    break;

                default:
                    break;
            }
        }
    }
}

    

    
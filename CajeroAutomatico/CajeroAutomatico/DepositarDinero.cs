using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
     public class DepositarDinero
    {
        string json1 = "";
        Guardar_Usuario usuario;
        public DepositarDinero ()
        {
            Console.WriteLine("DEPOSITAR DINERO");
            Console.WriteLine("");



            using (StreamReader jsonStream = File.OpenText(Utilidad.RutaUsuario))
            {
                var json = jsonStream.ReadToEnd();
                usuario = JsonConvert.DeserializeObject<Guardar_Usuario>(json);


                usuario.Monto = Usuario.Monto;

            }
            DEPOSITAR(usuario);
        }

        public void DEPOSITAR(Guardar_Usuario usuario)
        {
                double monto;

                Console.WriteLine("");
                Console.WriteLine("INGRESE EL MONTO QUE DESEA DEPOSITAR:");
                monto = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("");


                Baucher baucher = new Baucher(monto.ToString(), $"HICISTE UN DEPOSITO A TU CUENTA PERSONAL");
                Historial historial = new Historial();
                historial.Detalles = "REALIZASTE UN DEPOSITO A TU CUENTA PERSONAL";
                historial.Fecha = DateTime.Now.ToString();

                Usuario.Monto = usuario.Monto = usuario.Monto + monto;
                usuario.Historial.Add(historial);

                json1 = JsonConvert.SerializeObject(usuario);

                System.IO.File.WriteAllText(Utilidad.RutaUsuario, json1);

          
            
        }
    }
}
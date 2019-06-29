using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class RetiroEfectivo
    {
        string json1 = "";
        Guardar_Usuario usuario;
        public RetiroEfectivo()
        {
            Console.WriteLine("RETIRO DE EFECTIVO");
            Console.WriteLine("");



            using (StreamReader jsonStream = File.OpenText(Utilidad.RutaUsuario))
            {
                var json = jsonStream.ReadToEnd();
                usuario = JsonConvert.DeserializeObject<Guardar_Usuario>(json);


                usuario.Monto = Usuario.Monto;

            }
            RealizarRetiro(usuario);
        }

        public void RealizarRetiro(Guardar_Usuario usuario)
        {
            if (usuario.Monto > 0)
            {
                double monto;

                Console.WriteLine("");
                Console.WriteLine("INGRESE EL MONTO QUE DESEE RETIRAR:");
                monto = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("");


                Baucher baucher = new Baucher(monto.ToString(), $"RETIRO DE EFECTIVO");
                Historial historial = new Historial();
                historial.Detalles = "REALIZASTE RETIRO DE EFECTIVO";
                historial.Fecha = DateTime.Now.ToString();

                Usuario.Monto = usuario.Monto = usuario.Monto - monto;
                usuario.Historial.Add(historial);

                json1 = JsonConvert.SerializeObject(usuario);

                System.IO.File.WriteAllText(Utilidad.RutaUsuario, json1);

            }
            else
            {
                Console.WriteLine("NO TIENES BALANCE SUFICIENTE PARA REALIZAR SU RETIRO");
            }
        }
    }
}

        

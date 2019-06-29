using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class Transferencia
    {
        string json1 = "";
        Guardar_Usuario usuario;
        public Transferencia()
        {
            Console.WriteLine("TRANSFERENCIAS");
            Console.WriteLine("");



            using (StreamReader jsonStream = File.OpenText(Utilidad.RutaUsuario))
            {
                var json = jsonStream.ReadToEnd();
                usuario = JsonConvert.DeserializeObject<Guardar_Usuario>(json);


                usuario.Monto = Usuario.Monto;

            }
            Tranferencia(usuario);
        }

        public void Tranferencia(Guardar_Usuario usuario)
        {
            if (usuario.Monto > 0)
            {
                string numero;
                double monto;

                Console.WriteLine("INGRESE LA CUENTA QUE DESEA TRANFERIRLE:");
                numero = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("INGRESE EL MONTO QUE DESEA DEPOSITAR:");
                monto = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("");


                Baucher baucher = new Baucher(monto.ToString(), $"TRANSFERISTE A LA CUENTA {numero} ");
                Historial historial = new Historial();
                historial.Detalles = "REALIZASTE UNA TRANSFERENCIA";
                historial.Fecha = DateTime.Now.ToString();

                Usuario.Monto = usuario.Monto = usuario.Monto - monto;
                usuario.Historial.Add(historial);

                json1 = JsonConvert.SerializeObject(usuario);

                System.IO.File.WriteAllText(Utilidad.RutaUsuario, json1);

            }
            else
            {
                Console.WriteLine("NO TIENES BALANCE SUFICIENTE PARA REALIZAR SU REGARGA");
            }
        }
    }
}


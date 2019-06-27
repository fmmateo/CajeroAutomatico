using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class ConsultaBalance
    {
        string json1 = "";
        public ConsultaBalance()
        {
            Baucher baucher = new Baucher(Usuario.Monto.ToString(), "COMSULTA BALANCE");

            using (StreamReader jsonStream = File.OpenText(Utilidad.RutaUsuario))
            {
                var json = jsonStream.ReadToEnd();
                Guardar_Usuario usuario = JsonConvert.DeserializeObject<Guardar_Usuario>(json);



                usuario.Monto = Usuario.Monto;
                

                Historial historial = new Historial();
                historial.Detalles = "CONSULTO EL BALANCE";
                historial.Fecha = DateTime.Now.ToString();

                usuario.Historial.Add(historial);

                json1 = JsonConvert.SerializeObject(usuario);
               

             
            }

            System.IO.File.WriteAllText(Utilidad.RutaUsuario, json1);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public static class Utilidad
    {

        public static string RutaUsuario { get; set; }

    }

    public static class Usuario
    {
        public static string Nombre { get; set; }
        public static string Cedula { get; set; }
        public static string Numero { get; set; }
        public static double Monto { get; set; }

        public static List<Historial> Historial { get; set; }

    }
    public class Guardar_Usuario
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Numero { get; set; }
        public double Monto { get; set; }

        public List<Historial> Historial { get; set; }

        public Guardar_Usuario()
        {
            Historial = new List<Historial>(); 
        }

    }

    public class Historial
    {
        public string Detalles { get; set; }
        public string Fecha { get; set; }


    }
}

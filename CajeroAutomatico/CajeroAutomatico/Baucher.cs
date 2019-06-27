using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class Baucher
    {
        public Baucher(string monto, string consepto)
        {
            ImprimirBaucher(monto, consepto);
            Console.WriteLine("");
        }

        public void ImprimirBaucher(string monto, string  concepto)
        {
            var fecha = DateTime.Now;

            Console.WriteLine("TRANSACCION PROCESADA");
            Console.WriteLine(fecha.ToString());
            Console.WriteLine("");
            Console.WriteLine($"CODIGO DE TRANSACION:{ GeneradorCodigo.GetRandomAlfanumericTokenString ()}");
            Console.WriteLine("");
            Console.WriteLine($"MONTO: {monto}"); 
            Console.WriteLine("");
            Console.WriteLine($"CONCEPTO: {concepto}");
        }
    }
}

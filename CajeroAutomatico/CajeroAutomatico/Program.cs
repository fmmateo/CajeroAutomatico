using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Utilidades util = new Utilidades();
            util.CrearCarpetas();
            util.TituloMenu();
            util.MenuSucursales();
            util.ValidarUsuario(Console.ReadLine());
            
           
            



            Console.ReadKey();
        }
    }
}

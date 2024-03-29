﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
     public class RecargasTelefonicas
    {
        string json1 = "";
        Guardar_Usuario usuario;
        public RecargasTelefonicas()
        {
                 Console.WriteLine("RECARGAS TELEFONICAS");
                 Console.WriteLine("");



            using (StreamReader jsonStream = File.OpenText(Utilidad.RutaUsuario))
            {
                var json = jsonStream.ReadToEnd();
                usuario = JsonConvert.DeserializeObject<Guardar_Usuario>(json);


                usuario.Monto = Usuario.Monto;
              
            }
            ReaizarRecargas(usuario);
        }

        public void ReaizarRecargas(Guardar_Usuario usuario)
        {
            if (usuario.Monto > 0)
            {
                string numero;
                double monto;

                Console.WriteLine("INGRESE EL NUMERO A RECARGAR:");
                numero = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("INGRESE EL MONTO DE LA RECARGA:");
                monto = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("");


                Baucher baucher = new Baucher(Usuario.Monto.ToString(), $"RECARGASTE AL NUMERO {numero} UN MONTO DE {monto}");
                Historial historial = new Historial();
                historial.Detalles = "REALIZASTE UNA RECARGA";
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

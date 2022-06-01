using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Interfaz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" BIENVENIDO AL JUEGO DE LA PAPA");

            Servicio.ServiceClient servicio = new Servicio.ServiceClient();

            Servicio.Respuesta res = servicio.Jugar(new Random());

            while (!res.Termino)
            {
                foreach (int item in res.Numeros)
                {
                    Console.Write(" " + item);
                }

                Console.WriteLine(" ");

                res = servicio.Jugar(new Random());
            }

            Console.WriteLine($" PUNTOS: {res.Puntos}");
            Console.WriteLine($" Dados restantes: {res.DadosRestantes}");

            Console.ReadKey();
        }
    }
}

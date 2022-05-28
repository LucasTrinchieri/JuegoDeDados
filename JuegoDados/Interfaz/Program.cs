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
            Console.WriteLine(" PUNTOS: ");

            Servicio.ServiceClient servicio = new Servicio.ServiceClient();

            servicio.ObtenerNumeros(new Random());
        }
    }
}

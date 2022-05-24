using System;
using System.IO;
using System.Linq;

namespace CalculoDePrestacionesConsola
{
    class Program
    {
        private static int screenWidth = Console.LargestWindowWidth;
        private static int screenHeight = Console.LargestWindowHeight;

        static void Main(string[] args)
        {
            /*
             TODO: End this shit
                configurarlo para evitar errores en el futuro que hagan el programa crashear. Empezando por las fechas
                Arreglar los textos para que impriman algo
             */

            //Pantalla y variables basicas
            Console.Title = "CÁLCULO DE PRESTACIONES Y DERECHOS ADQUIRIDOS";
            Console.SetWindowSize(screenWidth - 50, screenHeight / 2);
            Console.WriteLine("¡Bienvenido a la aplicacion de calculo de prestaciones!");
            bool loop = true;
            bool success;
            int input = 0;

            while (loop)
            {
                Date date = new Date();
                Calculo calculo = new Calculo(date.Year, date.Month, date.Day);
                Prestaciones prestacion = new Prestaciones(calculo.Time, date.Month, calculo.promDiario, date.Entry);
                Console.WriteLine("****************************************************");
                date.TotalTimeWorking();
                Console.WriteLine("***************************************************");
                calculo.OverAllSalaries();
                Console.WriteLine("***************************************************");
                prestacion.MoneyToBePay();
                Console.WriteLine("***************************************************");
                Console.Write("¿Desea realizar otro calculo de prestaciones? (1) Si (2) No  ");
                success = Int32.TryParse(Console.ReadLine(), out input);
                if (success && input == 2)
                {
                    loop = false;
                }
                Console.Clear();
            }
            
            Console.Read();
        }

       

    }
}

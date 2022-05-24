using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoDePrestacionesConsola
{
    class Calculo
    {
        public int TPeriodo { get; private set; }
        public int TCalculo { get; private set; }
        public double SalarioSum { get; private set; }
        public double promMensual { get; private set; }
        public double promDiario { get; private set; }
        public int Time { get; private set; }
        public string TotalSalaries { get; private set; }

        public Calculo(int Year, int Month, double Day)
        {

            if (Year == 0)
            {
                if (Month == 0)
                {
                    Time = 1;
                }
                else
                {
                    Time = Month;
                }
            }
            else
            {
                Time = 12;
            }

            CalculoYPeriodo();
            SalariesCal(Time, TPeriodo, TCalculo, Day);
        }

        //Seleccion de periodo y tipo de calculo
        void CalculoYPeriodo()
        {
            int Periodo = 1;
            int Calculo = 1;
            bool loop = true;
            bool success;
            Console.Clear();
            Console.WriteLine("Frecuencia de pago");
            Console.WriteLine("Seleccione el período: ");
            Console.WriteLine(@"
             (1) Mensual        (2)Quincenal
             (3) Semanal        (4) Diario");
            while (loop)
            {
                Console.Write("Introdusca su respuesta: ");
                success = int.TryParse(Console.ReadLine(), out Periodo);

                if (success && (Periodo >= 1 && Periodo <=4 ))
                {
                    loop = false;
                }
                else
                    Console.WriteLine("Por favort inserte un valor valido.");
            }
            loop = true;
            Console.WriteLine("Seleccione el tipo de cálculo: ");
            Console.WriteLine(@"
             (1) Ordinario        (2)Intermitente");
            Console.WriteLine(@"
             Jornada ordinaria es la ejecutada por trabajadores dentro de un período que no exceda 
             de ocho (8) horas al día ni de cuarenta y cuatro (44) a la semana. 
               
             Referencia Art.147 del codigo de trabajo");

            Console.WriteLine(@"
             Jornada intermitente es la ejecutada por trabajadores que requieren su sola presencia 
             en el lugar de trabajo, los cuales pudieran laborar consecuentemente por un periodo 
             de hasta diez (10) horas diarias. Estos trabajadores son: los porteros, 
             los ascensoristas, los serenos, los guardianes, los conserjes, los barberos, 
             los sastres, los empleados de bombas para el expendio de gasolina, los capataces, 
             los mozos de cafés y restaurantes, las manicuristas, los camareros, los trabajadores 
             ocupados en vehículos de transporte terrestre que presten servicios intermitentes o entre dos 
             o más municipios y los trabajadores del campo.
                
             Referencias: resolución 04/93 del Ministerio de Trabajo, sobre trabajadores 
             que ejecutan labores intermitentes, arts. 281, 284 y 285 del Código de Trabajo 
             y art. 78 del Reglamento 258/93 para la aplicación del Código de Trabajo.

");
            while (loop)
            {
                Console.Write("Introdusca su respuesta: ");
                success = int.TryParse(Console.ReadLine(), out Calculo);


                if (success && (Calculo >= 1 && Calculo <= 2))
                {
                    loop = false;
                }
                else
                    Console.WriteLine("Por favort inserte un valor valido.");
            }
            (this.TPeriodo, this.TCalculo) = (Periodo, Calculo);
        }

      //Tabla de salarios y calculo de salarios
       void SalariesCal(int time, int periodo, int calculo, double days)
        {
            double[] Salaries = new double[time];
            double[] Comisions = new double[time];
            double[] totals = new double[time];
            if (days >= 30)
            {
                Salaries = new double[time + 1];
                Comisions = new double[time + 1];
                totals = new double[time + 1];
            }


            double salariesSum = 0.0;
            double promMonthly = 0.0;
            double promDaily = 0.0;
            bool loop = true;
            bool success;
            Console.Clear();
            Console.WriteLine(@"
             Para que el cálculo de las prestaciones laborales y derechos adquiridos 
             esté conforme a la normativa laboral,debe colocar su salario correspondiente 
             al último año de servicios prestados en orden de antigüedad, siendo 
             el número 1 el salario más antiguo y el número 12 el salario más reciente. 
             Esto así porque derechos como el de las vacaciones deben ser calculados en base 
             a la remuneración habitual, en cuyo caso tomaremos el salario reportado en el último mes. 
             
             Referencia: Art. 181 del Código de Trabajo.");

            //Salarios
            for (int i = 0; i < Salaries.Length; i++)
            {
                Console.Write($"{i + 1}. salario: ");
                while (loop)
                {
                    success = double.TryParse(Console.ReadLine(), out Salaries[i]);
                    if (success && Salaries[i] >= 0)
                    {
                        loop = false;
                    }
                    else
                        Console.WriteLine("Por favor incluya un salario valido.");
                }   
                loop = true;
                Console.WriteLine();
                if (time > 1)
                {
                    int input = 0;
                    if (i < Salaries.Length)
                    {
                        Console.Write("¿Deseas autocompletar desde este punto? 1)Si 2) No: ");
                        while (loop)
                        {
                            success = int.TryParse(Console.ReadLine(), out input);
                            if (success && (input >= 1 && input <= 2))
                            {
                                loop = false;
                            }
                            else
                                Console.WriteLine("Por favor, sea elija la opcion 1 o 2.");
                        }   
                    }
                    loop = true;
                    if (input == 1)
                    {
                        for (int j = i + 1; j < Salaries.Length; j++)
                        {
                            Salaries[j] = Salaries[i];
                        }
                        break;
                    }
                }
            }

            //Comisiones
            for (int i = 0; i < Comisions.Length; i++)
            {
                Console.Write($"{i + 1}. comision: ");
                while (loop)
                {
                    success = double.TryParse(Console.ReadLine(), out Comisions[i]);
                    if (success && Comisions[i] >= 0)
                    {
                        loop = false;
                    }
                    else
                        Console.WriteLine("Por favor incluya comisiones validas.");
                }
                loop = true;
                Console.WriteLine();
                if (time > 1)
                {
                    int input = 0;
                    if (i < Comisions.Length)
                    {
                        Console.Write("¿Deseas autocompletar desde este punto? 1)Si 2) No: ");
                        while (loop)
                        {
                            success = int.TryParse(Console.ReadLine(), out input);
                            if (success && (input >= 1 && input <= 2))
                            {
                                loop = false;
                            }
                            else
                                Console.WriteLine("Por favor, sea elija la opcion 1 o 2.");
                        }
                    }
                    if (input == 1)
                    {
                        for (int j = i + 1; j < Comisions.Length ; j++)
                        {
                            Comisions[j] = Comisions[i];
                        }
                        break;
                    }
                }
            }
            //Totales
            for (int i = 0; i < totals.Length; i++)
            {
                totals[i] = Salaries[i] + Comisions[i];
            }

            //Tabla
            Console.WriteLine("# Salaries  Comisiones  Totales");
            for (int t = 0; t < totals.Length; t++)
            {
                Console.WriteLine($"{t + 1}  {Salaries[t]:C2}    {Comisions[t]:C2}      {totals[t]:C2}");
            }
            Console.ReadKey();
            Console.Clear();

            //Suma de salarios
            salariesSum = totals.Sum();
            //Salario promedio mensual
            switch (periodo)
            {
                case 1:
                    promMonthly = salariesSum / time;
                    break;
                case 2:
                    promMonthly = (salariesSum * 2) / (time);
                    break;
                case 3:
                    promMonthly = (salariesSum * 4.3333) / (time);
                    break;
                case 4:
                    promMonthly = (salariesSum * (calculo == 1 ? 23.83 : 26)) / (time);
                    break;
            }
            //Salario promedio diarios
            promDaily = promMonthly / (calculo == 1 ? 23.83 : 26);
            (SalarioSum, promMensual, promDiario) = (salariesSum, promMonthly, promDaily);
        }
        //Resultados
        public void OverAllSalaries()
        {
            string total = $"\nSumatoria de los salarios {SalarioSum:C2}\nSalario promedio mensual {promMensual:C2}\nSalario promedio diario {promDiario:C2}";
            TotalSalaries = total;
            Console.WriteLine(total);
        }
    }
}

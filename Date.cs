using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoDePrestacionesConsola
{
    public class Date 
    {
       
        public int Year { get; private set; }
        public int Month { get; private set; }
        public double Day { get; private set; }
        public string TotalTimeWork { get; private set; }
        public DateTime Entry { get; private set; } = DateTime.Now;
        public DateTime Exit { get; private set; } = DateTime.Now;
        public Date()
        {
            FechasDeSalidaYEntrada();
        }

        /*Colecciona las fechas de ingreso/entrada y salida del empleado*/
        void FechasDeSalidaYEntrada()
        {
            string input = "";
            bool loop = true;
            bool success;
            DateTime value = DateTime.Now;
            Console.WriteLine("Seleccion de Fechas");
            Console.WriteLine("La fechas de entrada y salida deben ser escritas en el formato Mes/Dia/Año o Mes-Dia-Año");
            Console.WriteLine("Por favor inserte la fecha de entrada: ");
            //Loop de seguridad
            while (loop)
            {
                input = Console.ReadLine();
                success = DateTime.TryParse(input, out value);
                if (success)
                {
                    loop = false;
                }
                else
                    Console.WriteLine("Por favor inserte una fecha valida. Mes/Dia/Año o Mes-Dia-año");
            }
            Entry = value;
            loop = true;
            Console.WriteLine("Por favor inserte la fecha de salida: ");
            while (loop)
            {
                input = Console.ReadLine();
                success = DateTime.TryParse(input, out value);
                if ((success && value.Year > Entry.Year) || (success && value.Month >= Entry.Month && value.Year == Entry.Year))
                {
                    loop = false;
                }
                else
                    Console.WriteLine("Por favor inserte una fecha valida. Mes/Dia/Año o Mes-Dia-año.\nNota: Debe ser la misma o posterior a la de entrada");
            }
            Exit = value;
            YearsWorking(Entry, Exit);
            MonthsWorking(Entry, Exit, Year);
            DaysWorking(Entry, Exit, Month);
        }

        /*Años. Se le resta al año de salida el año de entrada
        Se le resta 1 por que el computador añade el año inicial como
        un año más*/
        void YearsWorking(DateTime entry, DateTime exit)
        {
            int Years = new DateTime(exit.Subtract(entry).Ticks).Year - 1;
            this.Year =  Years;
        }

        /*Meses. Se le suman los años medios y se van agregando
           meses hasta que sean iguales o mayor a los meses del
           año de salida.*/
        public void MonthsWorking(DateTime entry, DateTime exit, int Years)
        {
            DateTime PastYears = entry.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYears.AddMonths(i) == exit)
                {
                    Months = i;
                    break;
                }
                else if (PastYears.AddMonths(i) >= exit)
                {
                    Months = i - 1;
                    break;
                }
            }
            this.Month =  Months;
        }

        /*Days. Se agregan los meses que pasaron entre ambas fechas a
          la entrada, se le resta todo a la salida, se tranforma a dias
          y se le suma para que sea exacto.*/

        public void DaysWorking(DateTime entry, DateTime exit, int Months)
        {
            double Days = exit.Subtract(entry.AddMonths(Months)).Days + 1;

            while (Days > 30.42)
            {
                Days = Math.Round(Days / 30.42) - 12;
            }
            this.Day = Days;
        }

        //Tiempo de trabajo total
        public void TotalTimeWorking()
        {
            switch (Year)
            {
                case (0):
                    if (Month == 0)
                    {
                        TotalTimeWork = $"Tiempo laborado: {Day} dias";
                        break;

                    }
                    TotalTimeWork = $"Tiempo laborado: {Month} meses, y {Day} dias";
                    break;
                default:
                    if (Month == 0)
                    {
                        TotalTimeWork = $"Tiempo laborado: {Year} años y {Day} dias";
                        break;

                    }
                    TotalTimeWork = $"Tiempo laborado: {Year} años, {Month} meses, y {Day} dias";
                    break;
            }
            Console.WriteLine(TotalTimeWork);
        }
    }
}

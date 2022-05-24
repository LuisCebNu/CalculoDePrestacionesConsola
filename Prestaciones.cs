using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoDePrestacionesConsola
{
    class Prestaciones
    {
        public double TotalMoney { get; private set; }
        public string TotalPrestaciones { get; private set; }
        public double PreAviso { get; private set; }
        public double Cesantia1 { get; private set; }
        public double Cesantia2 { get; private set; }
        public double Vacacion { get; private set; }
        public double SalNavidad { get; private set; }

        public Prestaciones(int time, int month, double salario, DateTime entry)
        {
            PreAvised(time, salario);
            Cesantia(time,month,salario,entry);
            Vacaciones(time,month,salario);
            VacacionNavidad(salario);
        }

        //Pre-aviso
        void PreAvised(int time, double salario)
        {
            int input = 0;
            bool loop = true;
            bool success;
 
            Console.Write("¿Ha sido usted pre-avisado? (1)Si (2)No  ");
            while (loop)
            {
                success = Int32.TryParse(Console.ReadLine(), out input);
                if (success && (input >= 1 && input <= 2))
                {
                    loop = false;
                }
                else
                    Console.WriteLine("Por favor responda con 1 o 2.");
            }
            if (input == 2)
            {
                switch (time)
                {
                    case 1:
                    case 2:
                        break;
                    case 3:
                    case 4:
                    case 5:
                        PreAviso = salario * 7;
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                        PreAviso = salario * 14;
                        break;
                    default:
                        PreAviso = salario * 28;
                        break;
                }
            }
        }

        //Cesantia
        void Cesantia(int time, int months, double salario, DateTime entry)
        {
            int input = 0;
            bool loop = true;
            bool success;
            Console.Write("¿Desea cesantia? (1)Si (2)No  ");
            while (loop)
            {
                success = Int32.TryParse(Console.ReadLine(), out input);
                if (success && (input >= 1 && input <= 2))
                {
                    loop = false;
                }
                else
                    Console.WriteLine("Por favor responda con 1 o 2.");
            }
            if (input == 1)
            {
                //Art 80 C.T. antes de 1992
                if (entry.Year < 1992)
                {
                    switch (time)
                    {
                        case 1:
                        case 2:
                            break;
                        case 3:
                        case 4:
                        case 5:
                            Cesantia1 = salario * 6;
                            break;
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            Cesantia1 = salario * 13;
                            break;
                        default:
                            if (time < 60)
                            {
                                if (months == 0)
                                {
                                    Cesantia1 = (21 * (time + 0)) * salario;
                                }
                                else
                                    Cesantia1 = (21 * (time + (months >= 3 && months <= 5 ? 6 : 13))) * salario;
                                break;
                            }
                            else
                            {
                                if (months == 0)
                                {
                                    Cesantia1 = (23 * (time + 0)) * salario;
                                }
                                Cesantia1 = (23 * (time + (months >= 3 && months <= 5 ? 6 : 13))) * salario;
                                break;
                            }
                    }


                }

                //Art 80 C.T. despues de 1992
                switch (time)
                {
                    case 1:
                    case 2:
                        break;
                    case 3:
                    case 4:
                    case 5:
                        Cesantia2 = salario * 6;
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                        Cesantia2 = salario * 13;
                        break;
                    default:
                        if (time < 60)
                        {
                            if (months == 0)
                            {
                                Cesantia2 = 21 * salario;
                            }
                            else
                                Cesantia2 = 21 * (salario + (months >= 3 && months <= 5 ? 6 : 13));
                            break;
                        }
                        else
                        {
                            if (months == 0)
                            {
                                Cesantia2 = salario * 23;
                            }
                            else
                                Cesantia2 = 23 * (salario + (months >= 3 && months <= 5 ? 6 : 13));
                            break;
                        }
                }
            }
        }

        //Vacaciones correspondientes
        void Vacaciones(int time, int months, double salario)
        {
            int input = 0;
            bool loop = true;
            bool success;
            Console.Write("¿Ha tomado las vacaciones correspondientes el ultimo año? (1) Si (2) No ");
            while (loop)
            {
                success = Int32.TryParse(Console.ReadLine(), out input);
                if (success && (input>= 1 && input<= 2))
                {
                    loop = false;
                }
                else
                    Console.WriteLine("Por favor responda con 1 o 2.");
            }
            if (input == 2)
            {
                switch (time)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        break;
                    case 5:
                        Vacacion = ((salario * 6) / months);
                        break;
                    case 6:
                        Vacacion = ((salario * 7) / months); break;
                    case 7:
                        Vacacion = ((salario * 8) / months); break;
                    case 8:
                        Vacacion = ((salario * 9) / months); break;
                    case 9:
                        Vacacion = ((salario * 10) / months); break;
                    case 10:
                        Vacacion = ((salario * 11) / months); break;
                    case 11:
                        Vacacion = ((salario * 12) / months); break;
                    default:
                        if (time < 60)
                        {
                            if (months == 0)
                            {
                                Vacacion = salario * 14;
                            }
                            else
                            {
                                Vacacion = ((salario * 14) / months);
                            }
                        }
                        else
                        {
                            if (months == 0)
                            {
                                Vacacion = ((salario * 18));
                            }
                            else
                            {
                                Vacacion = ((salario * 18) / months);
                            }
                        }
                        break;
                }
            }
            else
            {
                switch (months)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        break;
                    case 5:
                        Vacacion = ((salario * 6) / months);
                        break;
                    case 6:
                        Vacacion = ((salario * 7) / months); break;
                    case 7:
                        Vacacion = ((salario * 8) / months); break;
                    case 8:
                        Vacacion = ((salario * 9) / months); break;
                    case 9:
                        Vacacion = ((salario * 10) / months); break;
                    case 10:
                        Vacacion = ((salario * 11) / months); break;
                    case 11:
                        Vacacion = ((salario * 12) / months); break;
                    default:
                        break;
                }

            }
        }

        void VacacionNavidad(double salario)
        {
            int input = 0;
            bool loop = true;
            bool success;
            //Salario navideño
            Console.Write("¿Desea incluir salario navideño? (1)Si (2)No ");
            while (loop)
            {
                success = Int32.TryParse(Console.ReadLine(), out input);
                if (success && (input >= 1 && input <= 2))
                {
                    loop = false;
                }
                else
                    Console.WriteLine("Por favor responda con 1 o 2.");
            }
            if (input == 1)
            {
                SalNavidad = (salario *111 ) / 12;
            }
        }

        //Pago a recibir
        public void MoneyToBePay()
        {
            string total;
            TotalMoney = PreAviso + Cesantia1 + Cesantia2 + SalNavidad;
            total = $"\nPRESTACIONES LABORALES Y DERECHOS ADQUIRIDOS\nPre-aviso {PreAviso:C2}.\nCesantia Art 80 C.T. antes 1992: {Cesantia1:C2}.\nCesantia Art 80 C.T. despues 1992: {Cesantia2:C2}.\nVacaciones tomadas {Vacacion:C2}.\nSalario de navidad {SalNavidad:C2}.\nTotal a recibir: {TotalMoney:C2}";
            //Console.WriteLine(total);
            TotalPrestaciones = total;
            Console.WriteLine(total);
        }
    }
}

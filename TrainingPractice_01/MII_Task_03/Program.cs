using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MII_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "password";
            int counter = 0;
            Console.Write("Введите пароль :");
            string vvod;
            while (true)
            {

                vvod = Console.ReadLine();
                if (vvod == password)
                {
                    Console.WriteLine("Веведено другое сообщение");
                    break;
                }
                counter++;
                if (counter > 2)
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Пароль неверный. Пожалуйста, введите пароль снова!");
                if (vvod.Length < password.Length) Console.WriteLine("Длина пороля не менее: " + password.Length);
            }
            Console.ReadLine();
        }
    }
}

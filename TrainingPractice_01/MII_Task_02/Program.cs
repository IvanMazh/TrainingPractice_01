using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MII_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ведите слова exit чтобы выйти из программы:");
            while (true)
            {
                if (Console.ReadLine() == "exit")
                {
                    break;
                }
            }
        }
    }
}

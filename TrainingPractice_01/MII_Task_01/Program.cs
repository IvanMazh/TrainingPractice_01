using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MII_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            uint temp_gold = 0;
            do
            {
                Console.Write("Сколько у вас золота? ");

                try
                {
                    temp_gold = Convert.ToUInt32(Console.ReadLine(), 10);
                }
                catch (Exception)
                { Console.WriteLine(" Ошибка при вводе числа!"); }

            } while (temp_gold == 0);



            uint crystal_price = 3;
            int buy_crystal = 0;

            do
            {
                try
                {
                    Console.Write("Сколько хотите купить кристалов? ");
                    buy_crystal = Math.Abs(Convert.ToInt32(Console.ReadLine(), 10));
                }
                catch (Exception)
                { Console.WriteLine(" Ошибка при вводе числа!"); }

            } while (buy_crystal < 1);


            uint max_buy_crystal = temp_gold / crystal_price;

            if (max_buy_crystal >= buy_crystal)

            { Console.WriteLine("Вы купили " + buy_crystal + " кристалов. У вас осталось " + (temp_gold - buy_crystal * crystal_price) + " золота"); }
            else
                Console.WriteLine("У вас недостаточно золота, хватит только для :  " + (max_buy_crystal) + " кристалов!");


            Console.ReadKey();
        }
    }
}

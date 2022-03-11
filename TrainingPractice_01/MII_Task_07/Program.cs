using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MII_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {

            int counter = 0;

            do
            {
                Console.Write("Введите количество элементов в массиве (больше 3): ");
                try
                {

                    counter = Math.Abs(Convert.ToInt32(Console.ReadLine(), 10));
                }
                catch (Exception)
                { Console.WriteLine(" Ошибка при вводе размера масива!"); }

            } while (counter < 3);


            int[] MyArray = new int[counter];
            bool result;

            for (int i = 0; i < counter; i++)
            {
                result = false;
                do
                {
                    Console.Write("Введите {0} элемент массива: ", i);
                    result = int.TryParse(Console.ReadLine(), out MyArray[i]);
                } while (result == false);
            }

            Random Shuffle = new Random();

            for (int i = 0; i < counter; i++)
            {
                int firstCounter, secondCounter;

                do
                {
                    firstCounter = Shuffle.Next(0, counter - 1);
                    secondCounter = Shuffle.Next(0, counter - 1);
                } while (firstCounter == secondCounter);

                var TempNum = MyArray[firstCounter];

                MyArray[firstCounter] = MyArray[secondCounter];
                MyArray[secondCounter] = TempNum;
            }


            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("{0} элемент массива после  Shuffle = {1}", i, MyArray[i]);

            }

            Console.ReadKey();
        }
    }
}

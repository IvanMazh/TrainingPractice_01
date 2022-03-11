using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MII_Task_06
{
    struct Person                 //тип дааных структура которая описывает человека
    {
        public int id;
        public string firstName;
        public string surName;
        public string thirdName;
        public string job;
    }

    class Program
    {
        static void Main(string[] args)
        {

            int idx = 1000;                                           //начальный индекс - индификатор
            Person[] persons = new Person[] { };                       //создаем масив для людей
            bool exit = false;


            while (true)
            {
                Console.WriteLine("Отдел кадров");
                Console.WriteLine("1 - Добавить досье");
                Console.WriteLine("2 - Вывести все досье");
                Console.WriteLine("3 - Удалить досье");
                Console.WriteLine("4 - Поиск по фамилии");
                Console.WriteLine("5 - Выход из программы");
                Console.Write("Выберите пункт меню: ");

                int command;
                int.TryParse(Console.ReadLine(), out command);

                switch (command)
                {
                    case 1:
                        Console.Clear();
                        idx = AddName(ref persons, idx);                   //вызов функции добовления досе AddName


                        break;
                    case 2:
                        Console.Clear();
                        PrintPersons(persons);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Удаление досье");
                        Console.Write("Введите номер досье которое хотите удалить :");

                        int _idx = 1000;

                        int.TryParse(Console.ReadLine(), out _idx);

                        if (persons.Length > 0)
                        {


                            if (Shift(ref persons, _idx))                                //сдвиг масива вверх
                            {
                                Array.Resize(ref persons, persons.Length - 1);           //удаление последней записи в масиве 
                                Console.WriteLine("Новая длина массива: " + persons.Length);
                            }
                        }
                        else
                        { Console.WriteLine("Элементы отсутсвуют!"); }

                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Поиск по фамилии");
                        Console.Write("Введите фамилию: ");
                        string _surname = Console.ReadLine();
                        Search(persons, _surname);
                        break;
                    case 5:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                if (exit) { break; } else { Console.ReadLine(); }
                Console.Clear();
            }
        }
        public static int AddName(ref Person[] name, int idx)            //добовления досе
        {
            Console.Write("Введите фамилию: ");
            string surName = Console.ReadLine();
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string thirdName = Console.ReadLine();

            Console.Write("Введите должность: ");
            string employeeJob = Console.ReadLine();

            int i = name.Length;                                 //опред длину масива

            Array.Resize(ref name, i + 1);                      // запись в масив

            name[i].id = idx + 1;
            name[i].firstName = firstName;
            name[i].surName = surName;
            name[i].thirdName = thirdName;
            name[i].job = employeeJob;


            return ++idx;

        }
        public static void PrintPersons(Person[] name)                  // 2.Вывод записи всех масивов
        {
            if (name.Length > 0)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    Console.WriteLine(name[i].id + "-" + name[i].surName + "-" + name[i].firstName + "-" + name[i].thirdName + "-" + name[i].job);
                }
            }
            else
            {
                Console.WriteLine("Здесь нет записей");
            }
        }
        static Boolean Shift(ref Person[] name, int indexToDelete)          //3 сдвиг 
        {

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i].id == indexToDelete)                        //поиск индекса для удаления 
                {
                    Console.WriteLine("Удаляем:" + name[i].surName + "-" + name[i].firstName + "-" + name[i].thirdName + "-" + name[i].job);

                    for (int j = i; j < name.Length - 1; j++)               //Сдвиг масива вверх 

                    {
                        name[j] = name[j + 1];
                    }


                    return true;
                }
            }

            Console.WriteLine("Здесь нет элемента с таким индексом!");
            return false;
        }
        static void Search(Person[] name, string surName)
        {
            if (name.Length > 0)
            {
                int counter = 0;
                for (var i = 0; i < name.Length; i++)
                {
                    if (name[i].surName.Contains(surName))              //сравнение с фамилией с поиска
                    {
                        Console.WriteLine(name[i].id + "-" + name[i].surName + "-" + name[i].firstName + "-" + name[i].thirdName + "-" + name[i].job);
                        counter++;
                    }
                }
                Console.WriteLine("Кол-во людей с фамилией {0} - {1}", surName, counter);
            }
            else
            {
                Console.WriteLine("Нет человека с такой фамилией");
            }
        }
    }
}

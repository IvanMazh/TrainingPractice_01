using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MII_Task_04
{
    public class User
    {
        public int Health = 0;
        int maxHealth = 800;
        public bool isRashmon = false;
        public bool isKatana = false;

        public User(int _MyHealth)
        {

            Health = (_MyHealth <= maxHealth) ? _MyHealth : maxHealth;
        }

        public int Udar(bool isRandom, int h1, int h2)              // метод смены удара по здаровю
        {
            var rnd = new Random();
            int vozdeistvie;
            if (isRandom)
            {
                vozdeistvie = this.Health + rnd.Next(h1, h2);
            }
            else
            {
                vozdeistvie = (this.Health + h1);
            }

            return (vozdeistvie <= maxHealth) ? vozdeistvie : maxHealth;

        }


    }



    class Program
    {

        public static void Print()
        {
            Console.WriteLine("1. Рашамон: призывает теневого духа для нанесения дальнейшей атаки но отнимает 100ед");
            Console.WriteLine("2. Хуганзакура: Может быть выполнен только после призыва теневого духа), наносит до 200ед. урона боссу");
            Console.WriteLine("3. Разлом:  позволяет скрыться в разломе и восстановить 250ед. Урон босса по вам не проходит");
            Console.WriteLine("4. Катана:  получаете меч катана ,но получаете ущерб до 100ед");
            Console.WriteLine("5. Удар Панды:  при наличи меча катана ущерб босса до 100ед , ваш ущерб до -50ед");
            Console.WriteLine("6. Банзаай: босса и ваш ущерб до -50ед");
        }

        static void Main(string[] args)
        {
            var rand = new Random();

            var MyUser = new User(rand.Next(500, 800));                 //Создан 2 обекта 
            var MyBoss = new User(rand.Next(500, 800));

            int turn = 0;


            Console.WriteLine("Ходы поочередные");
            Console.WriteLine("Величина урона, наносимого БОССОМ, для каждого хода случайна");
            Console.WriteLine("Игрок может пользоваться следующими заклинаниями:");


            while (MyUser.Health > 0 && MyBoss.Health > 0 && turn <= 20)                //цикл битв
            {
                Print();
                Console.WriteLine("         Ход " + turn);
                Console.WriteLine("Ваше здоровье: " + MyUser.Health);
                Console.WriteLine("Здоровье босса: " + MyBoss.Health + "\n");
                Console.Write("Введите номер заклинания: ");

                int command;
                int.TryParse(Console.ReadLine(), out command);
                turn++;

                switch (command)
                {
                    case 1:
                        {
                            MyUser.isRashmon = true;
                            MyUser.Health = MyUser.Udar(false, -100, 0);
                        }
                        break;
                    case 2:
                        {
                            MyBoss.Health = MyUser.isRashmon ? MyBoss.Udar(true, -200, -100) : MyBoss.Health;
                            if (MyUser.isRashmon == false) { Console.WriteLine(" Вы не подружились с духа Рашамон!"); }
                            MyUser.isRashmon = false;

                        }
                        break;
                    case 3:
                        {
                            MyUser.Health = MyUser.Udar(false, 250, 0);

                        }
                        break;
                    case 4:
                        {
                            MyUser.Health = MyUser.Udar(false, -100, 0);
                            MyUser.isKatana = true;

                        }
                        break;
                    case 5:
                        {
                            if (MyUser.isKatana)
                            {
                                MyUser.Health = MyUser.Udar(true, -50, 0);
                                MyBoss.Health = MyBoss.Udar(true, -100, -50);
                            }
                            else { Console.WriteLine("У вас нет меча Катаны!"); MyUser.Health = MyUser.Udar(true, -50, 0); }

                        }
                        break;

                    case 6:
                        {
                            Console.WriteLine("Банзаай!");
                            MyUser.Health = MyUser.Udar(true, -50, 0);
                            MyBoss.Health = MyBoss.Udar(true, -50, 0);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Неверное заклинание!"); turn--;
                            break;
                        }



                }

            }


            if (MyUser.Health <= 0)
            {
                Console.WriteLine("\n" + "Вы погибли!");
            }
            else
            {
                if (MyBoss.Health <= 0)
                    Console.WriteLine("\n" + "Вы победили! Поздравляю!");
                else
                {
                    Console.WriteLine("\n" + "У вас боевая ничья!");
                }

            }
            Console.WriteLine("\n" + "Спасибо, что поиграли в эту игру! Для выхода нажмите любую клавишу");
            Console.ReadKey();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MII_Task_05
{

    public class Player                           //в классе игрок: максимальное хп и кординаты
    {
        
        private int health = 0;
        public int maxHealth = 800;                 // максимальное хп

        public int Health
        {
            get { return health; }
            set
            { health = (value <= maxHealth) ? value : maxHealth; }
        }


        private int y = 0;
        private int x = 0;
        private int maxX, maxY;

        public int playerPositionX
        {
            get { return x; }
            set 
            { if (value > 0 && value < maxX) { x = value; } else Console.Beep(); }
        }

        public int playerPositionY
        {
            get { return y; }
            set { if (value > 0 && value < maxY) { y = value; } else Console.Beep(); }
        }


        public Player(int playerY, int playerX, int MaxX, int MaxY)
        {
            health = maxHealth;
            this.maxX = MaxX;
            this.maxY = MaxY;
            playerPositionX = playerX;
            playerPositionY = playerY;
            
        }

        public int Udar(bool isRandom, int h1, int h2)
        {
            var rnd = new Random();
            
            if (isRandom)
            {
                Health = Health + rnd.Next(h1, h2);
            }
            else
            {
                Health = Health + h1;
            }

            return Health;

        }


    }
    public static class MapBuilder
    {
        public static char[,] ReadMap(string mapName, out int performerX, out int performerY, out int MaxX , out int MaxY)
        {
            performerX = 0;
            performerY = 0;

            MaxX = 0;
            MaxY = 0;

            string[] newFile = File.ReadAllLines($"../../maps/{mapName}.txt");
                    

            char[,] map = new char[newFile.Length, newFile[0].Length];


            MaxX = map.GetLength(0) - 1;
            MaxY = map.GetLength(1) - 1;

            // j = X  i = Y
            Random rnd = new Random();
            int tmprnd = 50;

            for (int i = 0; i <= MaxY; i++)
            {
                for (int j = 0; j <= MaxX; j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '■')
                    {
                        performerX = j;
                        performerY = i;
                    }
                    else if (i > 1 && i < MaxX - 1 &&  (map[i, j] == ' ' || map[i, j] == '·'))   //генерация бандита или золото
                    {
                        tmprnd = rnd.Next(0, 100);
                        if (tmprnd < 5) { map[i, j] = 'b'; } else if (tmprnd > 95) map[i, j] = '*'; // вероятность спавна
                    }

                }
            }
            return map;
        }
    public static void DrawMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }
  
}

    class Movement
    {
        public static char[,] PlayerMove(char[,] map, Player player)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.RightArrow:

                        if (map[player.playerPositionY, player.playerPositionX + 1] == ' ' || map[player.playerPositionY, player.playerPositionX + 1] == '*'
                            || map[player.playerPositionY, player.playerPositionX + 1] == 'b' || map[player.playerPositionY, player.playerPositionX + 1] == '·')
                        {
                            map[player.playerPositionY, player.playerPositionX] = '·';                                      //ячейка откуда уходим

                            CellCheck(map[player.playerPositionY, player.playerPositionX + 1], player);

                            ++player.playerPositionX;                                                                        //ячейка куда уходим
                            map[player.playerPositionY, player.playerPositionX] = '■';                                             
                         }
                        else
                        { Console.Beep(); }
              
                       break;
 
                case ConsoleKey.LeftArrow:

                        if (map[player.playerPositionY, player.playerPositionX - 1] == ' ' || map[player.playerPositionY, player.playerPositionX - 1] == '*'
                            || map[player.playerPositionY, player.playerPositionX - 1] == 'b' || map[player.playerPositionY, player.playerPositionX - 1] == '·')
                        {
                            map[player.playerPositionY, player.playerPositionX] = '·';                                      //ячейка откуда уходим

                            CellCheck(map[player.playerPositionY, player.playerPositionX - 1], player);

                            --player.playerPositionX;                                                                        //ячейка куда уходим
                            map[player.playerPositionY, player.playerPositionX] = '■';
                        }
                        else
                        { Console.Beep(); }

                    break;
            
                case ConsoleKey.UpArrow:

                    if (map[player.playerPositionY - 1, player.playerPositionX] == ' ' || map[player.playerPositionY - 1, player.playerPositionX] == '*'
                           || map[player.playerPositionY - 1, player.playerPositionX] == 'b' || map[player.playerPositionY - 1, player.playerPositionX] == '·')
                    {
                        map[player.playerPositionY, player.playerPositionX] = '·';                                      //ячейка откуда уходим

                        CellCheck(map[player.playerPositionY - 1, player.playerPositionX], player);

                        --player.playerPositionY;                                                                        //ячейка куда уходим
                        map[player.playerPositionY, player.playerPositionX] = '■';
                    }


                    break;
                case ConsoleKey.DownArrow:
                    if (map[player.playerPositionY + 1, player.playerPositionX] == ' ' || map[player.playerPositionY + 1, player.playerPositionX] == '*'
                           || map[player.playerPositionY +1, player.playerPositionX] == 'b' || map[player.playerPositionY +1, player.playerPositionX] == '·')
                    {
                        map[player.playerPositionY, player.playerPositionX] = '·';                                      //ячейка откуда уходим

                        CellCheck(map[player.playerPositionY + 1, player.playerPositionX], player);

                        ++player.playerPositionY;                                                                        //ячейка куда уходим
                        map[player.playerPositionY, player.playerPositionX] = '■';
                    }

                    else
                    { Console.Beep(); }
                    break;

                case ConsoleKey.Escape:
                    player.Health = 0;
                    break;
            }
            return map;
        }
        public static void CellCheck(char cell, Player player)  //встреча золота или бандита
        {
            switch (cell)
            {
                case '*':
                    player.Udar(true, 50, 100);  
                    break;
                case 'b':
                    Console.Beep(500,300);
                    player.Udar(true, -200, -100);
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        { 
            int playrX;
            int playrY;

            int MaxX, MaxY;                  //размерность матрецы

            char[,] map = MapBuilder.ReadMap("level1", out playrX, out playrY, out MaxX , out MaxY);

            
            Player player = new Player(playrY, playrX, MaxX,  MaxY);

            Console.WriteLine("Управление стрелкми и Esc для выхода");

            MapBuilder.DrawMap(map);
            Console.WriteLine("Координаты: " + player.playerPositionY + " " + player.playerPositionX);
 

            while (player.Health > 0 && !(player.playerPositionY >= 29 && player.playerPositionX == 23))
            {
                Movement.PlayerMove(map, player);
                Console.Clear();
 
                MapBuilder.DrawMap(map);
 
                Console.WriteLine("Координаты: "+player.playerPositionY + " " + player.playerPositionX);
                Console.WriteLine("Здоровье игрока: " + player.Health);
                Console.WriteLine("Здоровье игрока: " + Math.Round(((double)player.Health/player.maxHealth)*100) + "%");

             }
            if (player.Health > 0) Console.WriteLine(" Победа! Вы вишли из лабиринта!"); 

            Console.Write("\nGame over! Press any key "); Console.ReadKey();
        }
    }
}

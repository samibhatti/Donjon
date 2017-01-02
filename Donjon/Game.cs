using System;

namespace Donjon
{
    internal class Game
    {
        private Map map;
        private Hero hero;

        public Game(int width, int height)
        {
            map = new Map(width, height);
        }

        internal void Run()
        {
            // init game
            hero = new Hero(health: 100);
            PopulateMap();

            // game loop
            do
            {
                Console.Clear();
                PrintMap();
                PrintStatus();

                ConsoleKey key = GetInput();

                // process actions
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (hero.Y > 0) hero.Y -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (hero.Y < map.Height - 1) hero.Y += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (hero.X > 0) hero.X -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (hero.X < map.Width - 1) hero.X += 1;
                        break;
                }


            } while (true);

            // game over
        }

        private void PopulateMap()
        {
            map.Cells[7, 4].Monster = new Goblin();
            map.Cells[4, 7].Monster = new Goblin();
            map.Cells[9, 7].Monster = new Orc();
            map.Cells[7, 9].Monster = new Orc();
        }

        private void PrintStatus()
        {
            Console.WriteLine();
            Console.WriteLine($"Health: {hero.Health} hp");
         // Console.WriteLine("Health: " + hero.Health.ToString() + " hp");
        }

        private ConsoleKey GetInput()
        {
            Console.WriteLine("Press a key");
            var keyInfo = Console.ReadKey(intercept: true);
            var key = keyInfo.Key;
            return key;
        }

        private void PrintMap()
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    var cell = map.Cells[x, y];
                    Console.Write(" ");
                    if (hero.X == x && hero.Y == y)
                    {
                        Console.Write("H");
                    }
                    else if (cell.Monster != null)
                    {
                        Console.ForegroundColor = cell.Monster.Color;
                        Console.Write(cell.Monster.MapSymbol);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
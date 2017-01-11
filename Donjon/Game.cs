using System;

namespace Donjon
{
    internal class Game //3
    {
        private Map map;
        private Hero hero; //11
        private string log;

      //  private Monster monster;

        //private int height;
        //private int width;

        public Game(int width, int height)
        {
            map = new Map(width, height); //5
        }

        internal void Run()
        {
            // init game
            //var hero = new Hero(health: 100); //4
            hero = new Hero(health: 100);     //12
            var cell = new Cell();
            //monster = new Monster();
            PopulateMap();
            // game loop 8
            do
            {

                Console.Clear();
                PrintMap();
                //process actions
                PrintStatus();
                PrintVisible();
                //PrintLog();


                Console.WriteLine("Arrow=Move and Spacebar to kill");
                Console.WriteLine("What do you do?");
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
                    case ConsoleKey.P:
                        if (cell.Item != null)
                        {
                            PickUp(cell);
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        var monster = map.Cells[hero.X, hero.Y].Monster;
                        if (monster != null)
                        {
                            Fight(monster);
                            if (monster.Health <= 40) map.Cells[hero.X, hero.Y].Monster = null;
                        }
                        break;

                    default:
                        break;
                }
        //    } while (true);
            } while (hero.Health > 0);
            Console.Clear();
            PrintMap();
            PrintStatus();
            PrintVisible();
            Console.WriteLine("All your base are belong to us!");
            Console.WriteLine("Game slut!");


            // game over
        }

        private void PickUp(Cell cell)
        {
            if (hero.Pickup(cell.Item))
            {
                Log($"You picked up the {cell.Item}");
                cell.Item = null;
            }
            else
            {
                Log($"You picked up Nothing! In your face!");

            }
        }

        /*private void PrintLog()
        {
            throw new NotImplementedException();
        }*/

        private void Fight(Monster monster)
        {
            Log(hero.Fight(monster));

            // log += hero.Fight(monster) + "\n";
            //string result = hero.Fight(monster);
            Console.WriteLine(hero.Fight(monster));
            if (monster.Health > 0)
            {
                //   result = monster.Fight(hero);
                // Console.WriteLine(monster.Fight(hero));
                Log(monster.Fight(hero));
            }
        }

        private void Log(string message)
        {
            log += message + "\n"; //use string builder instead
        }

        private void PrintVisible()
        {
            var cell = map.Cells[hero.X, hero.Y];
            var monster = cell.Monster;
            //if (monster != null)
            if (monster != cell.Monster)
            {
                Console.WriteLine();
                Console.WriteLine($"You see a {monster.Name} ({monster.Health} hp)");
            }
        }

        private void PopulateMap()
        {
            map.Cells[7, 4].Monster = new Goblin();
            map.Cells[8, 4].Monster = new Goblin();
            map.Cells[4, 7].Monster = new Goblin();
            map.Cells[9, 7].Monster = new Orc();
            map.Cells[5, 7].Monster = new Orc();
            map.Cells[8, 7].Monster = new Orc();
            map.Cells[7, 9].Monster = new Orc();
            //map.Cells[4, 9].Item = new Item("I"); //a3
            //map.Cells[5, 8].Item = new Item("C"); //a4
            map.Cells[4, 8].Item = new Item("C");
            map.Cells[9, 8].Item = new Item("C");
            map.Cells[5, 8].Item = new Item("C");
            map.Cells[2, 8].Item = new Item("C");
            map.Cells[1, 9].Item = new Item("C");
            map.Cells[1, 6].Item = new Item("C");
            map.Cells[7, 6].Item = new Item("C");

        }

        private void PrintStatus()
        {
            Console.WriteLine();
            Console.WriteLine($"Health: {hero.Health} hp");
        }

        private ConsoleKey GetInput()
        {
            Console.WriteLine("Press a key");
            var keyInfo = Console.ReadKey(intercept: true); //???
            var key = keyInfo.Key;
            return key;
        }

        private void PrintMap()
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    var cell = map.Cells[x, y]; //9
                    Console.Write(" ");

                    //Creature creature = null; //a
                    IVisible entity = null; //a5
                    if ((hero.X) == x && hero.Y == y)
                    {
                        entity = hero; //c
                        //Console.Write("H"); //b
                    }
                    else if (cell.Monster != null)
                    {
                        entity = cell.Monster; //d
                    }
                    else
                    {
                        Console.Write(".");
                    }

                    if (entity != null)                                                 //e
                    {
                        Console.ForegroundColor = entity.Color;
                        Console.Write(entity.MapSymbol);
                        Console.ResetColor();
                    }
                }
           
                    Console.WriteLine();
            }
        }   
    }
}
﻿using Donjon.Lib;
using System;

namespace Donjon
{
    internal class Hero : Creature //4 a inheritance added
    {
        public int Health { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Damage { get; } = 10;

        public LimitedList<Item> Backpack { get; } = new LimitedList<Item>(8); // a1

        public Hero(int health) : base("H") //b changed
        {
            Health = health;
            Color = ConsoleColor.White;
        }

        internal string Fight(Monster monster)
        {
            monster.Health -= Damage;
            if (monster.Health > 0)
            {
                return $"You attacked the {monster.Name} for {Damage} hp damage.";
            }
            else
            {
                return $"You slayed the {monster.Name}!";
            }
        }

        public bool Pickup(Item item) => Backpack.Add(item);
        /*public bool Pickup(Item item)
        {
            return Backpack.Add(item);
        }*/
    }
}
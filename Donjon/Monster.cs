using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donjon
{
    interface IVisible //a2
    {
        string MapSymbol { get; }
        ConsoleColor Color { get; }
    }
    public abstract class Creature : IVisible //a
    {
        public string MapSymbol { get; }
        public ConsoleColor Color { get; protected set; }

        public Creature(string mapSymbol)
        {
            MapSymbol = mapSymbol;
        }
    }
    public abstract class Monster : Creature
    {
        //public string MapSymbol { get; } //b moved up
        public int Health { get; set; }
        public string Name { get; set; }

        //public ConsoleColor Color { get; set; } = ConsoleColor.Red; //c moved up

        protected int Damage = 20;

        private string v1;
        private int v2;
        
        public Monster(string mapSymbol, string name, int health) : base(mapSymbol) //e base added
        {
           // MapSymbol = mapSymbol; //d moved up
            Name = name;
            Health = health;
            Color = ConsoleColor.Red; //f added
        }

        internal string Fight(Hero hero)
        {
            hero.Health -= Damage;
            if (hero.Health > 0)
            {
                return $"You attacked the {Name} for {Damage} hp damage.";
            }
            else
            {
                return $"You were killed by the {Name}!!!!1!||1one";
            }
        }
    }

    public class Goblin : Monster
    {
        public Goblin() : base("G", "goblin", 20) {
            Color = ConsoleColor.Green;
        }
    }

    public class Orc : Monster
    {
        public Orc() : base("O", "orc", 40) {
            Damage = 40;
        }
    }
}

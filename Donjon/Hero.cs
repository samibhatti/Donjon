namespace Donjon
{
    internal class Hero
    {
        public int Health { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int Damage { get; } = 10;

        public Hero(int health)
        {
            Health = health;
        }
    }
}
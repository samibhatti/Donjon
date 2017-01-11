using System;
namespace Donjon
{
    public class Item
    {
        public string MapSymbol { get; }
        public ConsoleColor Color { get; protected set; }

        public Item(string mapSymbol)
        {
            MapSymbol = mapSymbol;
            Color = ConsoleColor.Magenta;
        }
    }
}
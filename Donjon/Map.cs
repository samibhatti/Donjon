namespace Donjon
{
    internal class Map
    {
        public readonly int Height;
        public readonly int Width;
        public readonly Cell[,] Cells;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }
    }
}
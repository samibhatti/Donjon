namespace Donjon
{
    internal class Map
    {
        public int Height;
        public int Width;
        //private readonly Cell[,] Cells;
        public readonly Cell[,] Cells;

        public Map(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            Cells = new Cell[width, height]; //6 
            for (int x = 0; x < width; x++) //7
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }
    }
}
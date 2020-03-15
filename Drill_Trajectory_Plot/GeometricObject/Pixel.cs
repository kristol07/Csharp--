namespace GeometricObject
{
    public struct Pixel
    {
        public int X
        {
            get; set;
        }
        public int Y
        {
            get; set;
        }

        public char Symbol
        {
            get; set;
        }

        public Pixel(int x, int y, char symbol = ' ')
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }
    }
}
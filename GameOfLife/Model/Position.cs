namespace GameOfLife.Model
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            return this.X==((Position)obj).X && this.Y == ((Position)obj).Y;
        }
    }
}
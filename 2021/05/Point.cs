namespace Basje.AdventOfCode.Y2021.D05
{
    public record Point // : IComparable<Point>
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        //public int CompareTo(Point? other)
        //{
        //    if (other is null)
        //    {
        //        throw new ArgumentNullException(nameof(other));
        //    }
            
        //    if (X != other.X)
        //    {
        //        return X.CompareTo(other.X);
        //    }

        //    if (Y != other.Y)
        //    { 
        //        return Y.CompareTo(other.Y);
        //    }

        //    return 0;
        //}
    }
}

namespace Basje.AdventOfCode.Y2021.D05
{
    public record Line
    {
        public Point Start { get; init; }
        public Point End { get; init; }

        public bool IsHorizontal => Start.Y == End.Y;
        public bool IsVertical => Start.X == End.X;
        public bool IsDiagonal => !IsHorizontal && !IsVertical;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public IEnumerable<Point> ToPoints()
        {
            if (IsHorizontal)
            {
                var startX = Math.Min(Start.X, End.X);
                var endX = Math.Max(Start.X, End.X);

                return Enumerable.Range(startX, endX - startX + 1).Select(x => new Point(x, Start.Y));
            }

            if (IsVertical)
            {
                var startY = Math.Min(Start.Y, End.Y);
                var endY = Math.Max(Start.Y, End.Y);

                return Enumerable.Range(startY, endY - startY + 1 ).Select(y => new Point(Start.X, y));
            }

            if (IsDiagonal)
            {
                var startX = Start.X;
                var startY = Start.Y;
                var delta = Math.Abs(Start.X - End.X) + 1;
                var directionX = Start.X - End.X > 0 ? -1 : 1;
                var directionY = Start.Y - End.Y > 0 ? -1 : 1;

                return Enumerable.Range(0, delta).Select(d => new Point(startX + d * directionX, startY + d * directionY));
            }

            return Array.Empty<Point>();
        }
    }
}

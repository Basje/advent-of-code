using System.Collections.Generic;

namespace AdventOfCode_2019.Day_03
{
    internal class Right : Direction
    {
        public Right(int size) : base(size)
        {
        }

        public override IReadOnlyList<Coordinate> ToCoordinatesFrom(Coordinate start)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            for (int i = 1; i <= Size; i++)
            {
                coordinates.Add(new Coordinate(start.X + i, start.Y));
            }

            return coordinates;
        }
    }
}

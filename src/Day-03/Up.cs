using System.Collections.Generic;

namespace AdventOfCode_2019.Day_03
{
    internal class Up : Direction
    {
        public Up(int size) : base(size)
        {
        }

        public override IReadOnlyList<Coordinate> ToCoordinatesFrom(Coordinate start)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            for (int i = 1; i <= Size; i++)
            {
                coordinates.Add(new Coordinate(start.X, start.Y + i));
            }

            return coordinates;
        }
    }
}

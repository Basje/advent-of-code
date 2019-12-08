using System.Collections.Generic;

namespace AdventOfCode_2019.Day_03
{
    public interface IDirection
    {
        public int Size { get; }

        public abstract IReadOnlyList<Coordinate> ToCoordinatesFrom(Coordinate start);
    }
}

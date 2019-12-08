using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2019.Day_03
{
    internal class Wire
    {
        private readonly List<Direction> Directions = new List<Direction>();

        public Wire(IList<Direction> directions)
        {
            Directions.AddRange(directions);
        }

        public IReadOnlyList<Coordinate> FindIntersectionsWith(Wire wire)
        {
            var theseCoordinates = ToCoordinates();
            var thoseCoordinates = wire.ToCoordinates();

            return theseCoordinates.Intersect(thoseCoordinates).ToList();
        }

        public IReadOnlyList<Coordinate> ToCoordinates()
        {
            var coordinates = new List<Coordinate>();
            Coordinate endOfWire;
            coordinates.Add(new Coordinate(0, 0));

            foreach (var direction in Directions)
            {
                endOfWire = coordinates[coordinates.Count - 1];
                coordinates.AddRange(direction.ToCoordinatesFrom(endOfWire));
            }

            return coordinates;
        }
    }
}

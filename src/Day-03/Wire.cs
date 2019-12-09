using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2019.Day_03
{
    internal class Wire
    {
        private readonly List<Direction> Directions = new List<Direction>();

        public Wire(IEnumerable<Direction> directions)
        {
            Directions.AddRange(directions);
        }

        public IEnumerable<Coordinate> FindIntersectionsWith(Wire otherWire)
        {
            var theseCoordinates = ToCoordinates();
            var thoseCoordinates = otherWire.ToCoordinates();

            return theseCoordinates.Intersect(thoseCoordinates).ToList();
        }

        public int GetPathLengthToCoordinate(Coordinate location)
        {
            return ToCoordinates().ToList().IndexOf(location);
        }

        public IEnumerable<Coordinate> ToCoordinates()
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

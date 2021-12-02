using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode_2019.Day_03
{
    internal class CircuitBoard
    {
        private Wire BlueWire { get; }
        private Coordinate Origin { get; }
        private Wire RedWire { get; }

        internal CircuitBoard(Wire redWire, Wire blueWire)
        {
            RedWire = redWire;
            BlueWire = blueWire;
            Origin = new Coordinate(0, 0);
        }

        internal int FindNearestManhattanDistanceIntersection()
        {
            var intersections = GetWireIntersections();

            intersections.Remove(Origin);

            return intersections.Select(coordinate => Origin.CalculateManhattanDistanceTo(coordinate)).Min();
        }

        internal int FindShortestIntersectionPath()
        {
            var intersections = GetWireIntersections();

            intersections.Remove(Origin);

            return intersections.Select(coordinate => RedWire.GetPathLengthToCoordinate(coordinate) + BlueWire.GetPathLengthToCoordinate(coordinate)).Min();
        }

        private IList<Coordinate> GetWireIntersections()
        {
            return RedWire.FindIntersectionsWith(BlueWire).Distinct().ToList();
        }
    }
}

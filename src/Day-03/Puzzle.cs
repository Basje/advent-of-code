using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2019.Day_03
{
    internal static class Puzzle
    {
        internal static void SolveWith(List<List<string>> input)
        {
            ShowHeader();

            var firstPath = input[0];
            var secondPath = input[1];

            var firstWire = new Wire(firstPath.Select(direction => Direction.FromString(direction)).ToList());
            var secondWire = new Wire(secondPath.Select(direction => Direction.FromString(direction)).ToList());

            var intersections = firstWire.FindIntersectionsWith(secondWire).Distinct().ToList();

            var origin = new Coordinate(0, 0);
            intersections.Remove(origin);

            var nearestIntersectionDistance = intersections.Select(coordinate => origin.CalculateManhattanDistanceTo(coordinate)).Min();

            ShowResult(nearestIntersectionDistance);
        }

        private static void ShowHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Day 3");
            Console.WriteLine("-----");
            Console.WriteLine();
        }

        private static void ShowResult(int distance)
        {
            Console.WriteLine($"Distance to nearest intersection is {distance}");
        }
    }
}

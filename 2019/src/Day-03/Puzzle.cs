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

            var redWirePath = input[0];
            var blueWirePath = input[1];

            var redWire = new Wire(redWirePath.ToDirections());
            var blueWire = new Wire(blueWirePath.ToDirections());

            var circuit = new CircuitBoard(redWire, blueWire);
            var part1Answer = circuit.FindNearestManhattanDistanceIntersection();
            var part2Answer = circuit.FindShortestIntersectionPath();

            ShowResult(part1Answer, part2Answer);
        }

        private static void ShowHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Day 3");
            Console.WriteLine("-----");
            Console.WriteLine();
        }

        private static void ShowResult(int distance, int pathLength)
        {
            Console.WriteLine($"Manhattan distance to nearest intersection is {distance}");
            Console.WriteLine($"Shortest intersection path is {pathLength}");
        }

        private static IEnumerable<Direction> ToDirections(this IEnumerable<string> path)
        {
            return path.Select(step => Direction.FromString(step));
        }
    }
}

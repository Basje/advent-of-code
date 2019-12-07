using System;
using System.Collections.Generic;

namespace AdventOfCode_2019.Day_01
{
    internal static class Puzzle
    {
        internal static void SolveWith(IEnumerable<int> masses)
        {
            ShowHeader();

            var naiveFuelRequirement = FuelCounterUpper.NaiveCalculateForMass(masses);
            var properFuelRequirement = FuelCounterUpper.ProperCalculateForMass(masses);

            ShowResults(naiveFuelRequirement, properFuelRequirement);
        }

        private static void ShowHeader()
        {
            Console.WriteLine("Day 1");
            Console.WriteLine("-----");
            Console.WriteLine();
        }

        private static void ShowResults(int naiveRequirement, int properRequirement)
        {
            Console.WriteLine($"Naive fuel requirement:  {naiveRequirement}");
            Console.WriteLine($"Proper fuel requirement: {properRequirement}");
        }
    }
}

using System;
using System.Collections.Generic;

namespace AdventOfCode_2019.Day_04
{
    internal static class Puzzle
    {
        internal static void SolveWith(List<int> input)
        {
            ShowHeader();

            var start = input[0];
            var end = input[1];

            var bruteForcer = new PasswordBruteForcer(start, end);
            var firstSolution = bruteForcer.CalculateAllValidCombinations().Count;
            var secondSolution = bruteForcer.CalculateAllImprovedValidCombinations().Count;

            ShowResult(firstSolution, secondSolution);
        }

        private static void ShowHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Day 4");
            Console.WriteLine("-----");
            Console.WriteLine();
        }

        private static void ShowResult(int numberOfCombinations, int improvedNumberOfCombinations)
        {
            Console.WriteLine($"Possible number of combinations: {numberOfCombinations}");
            Console.WriteLine($"Improved possible number of combinations: {improvedNumberOfCombinations}");
        }
    }
}

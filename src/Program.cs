using System;
using System.IO;
using AdventOfCode_2019.Day_01;

namespace AdventOfCode_2019
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2019");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            var fileLocation = @$"{Directory.GetCurrentDirectory()}\Day-01\input.txt";

            if (!File.Exists(fileLocation))
            {
                Console.WriteLine($"Input file '{fileLocation}' could not be found. Aborting...");
                return;
            }

            var inputs = File.ReadAllLines(fileLocation);
            var firstSum = 0;
            var secondSum = 0;

            foreach (var input in inputs)
            {
                if (int.TryParse(input, out int mass))
                {
                    firstSum += FuelCounterUpper.CalculateForMass(mass);
                    secondSum += FuelCounterUpper.ReCalculateForMass(mass);
                }
            }

            Console.WriteLine($"Total fuel requirement: {firstSum}");
            Console.WriteLine($"Total fuel requirement 2: {secondSum}");
        }
    }
}
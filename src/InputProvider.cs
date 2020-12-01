using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode_2020
{
    public class InputProvider<T> where T : struct
    {
        public InputProvider(int day, int part)
        {
            Day = day;
            Part = part;
        }

        private int Day { get; }
        private int Part { get; }

        public IList<T> GetInputs()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var inputFile = $"{currentDirectory}\\input\\{Day.ToString().PadLeft(2, '0')}-{Part}.txt";

            if (!File.Exists(inputFile))
            {
                return new List<T>();
            }

            var rawInputs = File.ReadAllLines(inputFile);

            return rawInputs.Select(input => (T)Convert.ChangeType(input, typeof(T))).ToList();
        }
    }
}
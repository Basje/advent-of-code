using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode_2019.Day_03
{
    internal abstract class Direction : IDirection
    {
        private static readonly Regex commandFormat = new Regex(@"^(?<direction>[UDLR])(?<size>\d+)$");

        protected Direction(int size)
        {
            Size = size;
        }

        public int Size { get; }

        public static Direction FromString(string direction)
        {
            if (!commandFormat.IsMatch(direction)) throw new ArgumentException($"'{direction}' is not a valid direction");

            var match = commandFormat.Match(direction);

            var d = match.Groups["direction"].Value;
            var s = int.Parse(match.Groups["size"].Value);

            return d switch
            {
                "U" => new Up(s),
                "D" => new Down(s),
                "L" => new Left(s),
                "R" => new Right(s),

                _ => throw new ArgumentException($"'{direction}' is not a valid direction")
            };
        }

        public abstract IReadOnlyList<Coordinate> ToCoordinatesFrom(Coordinate start);
    }
}

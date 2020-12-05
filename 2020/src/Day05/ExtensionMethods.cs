using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2020.Day05
{
    public static class ExtensionMethods
    {
        public static IList<string> ToBinaryString(this IList<string> input)
        {
            return input
                .Select(boardingPass => boardingPass
                    .Replace('F', '0')
                    .Replace('B', '1')
                    .Replace('L', '0')
                    .Replace('R', '1'))
                .ToList();
        }

        public static IList<int> ToSeatIds(this IList<string> input)
        {
            return input
                .Select(binaryString => Convert.ToInt32(binaryString, 2))
                .ToList();
        }
    }
}
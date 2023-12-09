namespace Basje.AdventOfCode.Y2023.Toolbox
{
    public static class NumberExtensions
    {
        /// <summary>
        ///   Calculates the smallest positive number that is divisible by all numbers in the collection.
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/Least_common_multiple"/>
        public static long LeastCommonMultiple(this IEnumerable<long> numbers)
        {
            return numbers.Aggregate(LeastCommonMultiple);
        }

        /// <summary>
        ///   Calculates the largest positive number that divides each of the numbers in the collection.
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/Greatest_common_divisor"/>
        public static long GreatestCommonDivisor(this IEnumerable<long> numbers)
        {
            return numbers.Aggregate(GreatestCommonDivisor);
        }

        /// <remarks>
        ///   Copied from realmathack for AoC 2023 day 8
        ///   https://github.com/realmathack/advent-of-code/blob/main/AdventOfCode/NumberTheory.cs
        /// </remarks>
        private static long LeastCommonMultiple(long a, long b)
        {
            return (a * b) / GreatestCommonDivisor(a, b);
        }

        /// <remarks>
        ///   Copied from realmathack for AoC 2023 day 8
        ///   https://github.com/realmathack/advent-of-code/blob/main/AdventOfCode/NumberTheory.cs
        /// </remarks>
        private static long GreatestCommonDivisor(long a, long b)
        {
            return b == 0 ? a : GreatestCommonDivisor(b, a % b);
        }
    }
}

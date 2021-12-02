using System.Collections.Generic;

namespace AdventOfCode_2019.Day_04
{
    internal class PasswordBruteForcer
    {
        private int End { get; }
        private int Start { get; }

        internal PasswordBruteForcer(int start, int end)
        {
            Start = start;
            End = end;
        }

        internal IList<int> CalculateAllImprovedValidCombinations()
        {
            var combinations = new List<int>();

            for (int i = Start; i <= End; i++)
            {
                var combination = new Password(i);

                if (combination.HasNoDecreasingDigits() && !combination.HasDistinctDigits() && combination.HasNumberOfSomeDigit(2))
                {
                    combinations.Add(i);
                }
            }

            return combinations;
        }

        internal IList<int> CalculateAllValidCombinations()
        {
            var combinations = new List<int>();

            for (int i = Start; i <= End; i++)
            {
                var combination = new Password(i);

                if (combination.HasNoDecreasingDigits() && !combination.HasDistinctDigits())
                {
                    combinations.Add(i);
                }
            }

            return combinations;
        }
    }
}

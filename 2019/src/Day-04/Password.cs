using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2019.Day_04
{
    internal class Password
    {
        private IList<int> Value { get; }

        internal Password(int password)
        {
            Value = ToDigits(password);
        }

        internal bool HasDistinctDigits()
        {
            return Value.Distinct().ToList().Count == Value.Count;
        }

        internal bool HasNoDecreasingDigits()
        {
            var highestDigit = Value.First();

            for (int i = 1; i < Value.Count; i++)
            {
                if (Value[i] < highestDigit)
                {
                    return false;
                }

                if (Value[i] > highestDigit)
                {
                    highestDigit = Value[i];
                }
            }

            return true;
        }

        internal bool HasNumberOfSomeDigit(int numberOfOccurences)
        {
            var digitGroups = Value.GroupBy(i => i);

            foreach (var digit in digitGroups)
            {
                if (digit.Count() == numberOfOccurences)
                {
                    return true;
                }
            }

            return false;
        }

        private IList<int> ToDigits(int number)
        {
            return number
                .ToString()
                .Select(digit => int.Parse(digit.ToString()))
                .ToList();
        }
    }
}

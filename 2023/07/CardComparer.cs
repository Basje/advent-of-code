using System.Collections;

namespace Basje.AdventOfCode.Y2023.D07
{
    public class CardComparer : IComparer<char>
    {
        public int Compare(char left, char right)
        {
            return right.CardValue() - left.CardValue();
        }
    }
}

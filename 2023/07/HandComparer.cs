namespace Basje.AdventOfCode.Y2023.D07
{
    internal class HandComparer : IComparer<Hand>
    {
        public int Compare(Hand left, Hand right)
        {
            var typeCompare = right.HandValue - left.HandValue;

            if (typeCompare != 0) return typeCompare;

            var index = 0;

            while (index < 4 && right.Cards[index] == left.Cards[index]) index++;

            return right.Cards[index].CardValue() - left.Cards[index].CardValue();
        }
    }
}

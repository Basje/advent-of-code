namespace Basje.AdventOfCode.Y2023.D07
{
    internal class HandComparerWithJokers : IComparer<Hand>
    {
        public int Compare(Hand left, Hand right)
        {
            var typeCompare = right.HandValueWithJokers - left.HandValueWithJokers;

            if (typeCompare != 0) return typeCompare;

            var index = 0;

            while (index < 4 && right.Cards[index] == left.Cards[index]) index++;

            return right.Cards[index].CardValueWithJokers() - left.Cards[index].CardValueWithJokers();
        }
    }
}

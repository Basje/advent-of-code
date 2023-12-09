namespace Basje.AdventOfCode.Y2023.D07
{
    public static class Extensions
    {
        public static int CardValue(this char card) 
        {
            return card switch
            {
                >= '2' and <= '9' => card - '0',
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
            };
        }

        public static int CardValueWithJokers(this char card)
        {
            return card switch
            {
                'J' => 1,
                >= '2' and <= '9' => card - '0',
                'T' => 10,
                'Q' => 11,
                'K' => 12,
                'A' => 13,
            };
        }

        public static Dictionary<char, int> TallyCards(this string hand)
        {
            var tally = new Dictionary<char, int>();
            var cards = hand.ToCharArray();
            foreach (var card in hand.Distinct())
            {
                tally[card] = cards.Count(c => c == card);
            }
            return tally;
        }
    }
}

namespace Basje.AdventOfCode.Y2023.D07
{
    public record Hand
    {
        public required string Cards { init; get; }

        public int HandValue => Cards.TallyCards().Count switch
        {
            1 => 7,
            2 => Cards.TallyCards().Any(tally => tally.Value == 4) ? 6 : 5,
            3 => Cards.TallyCards().Any(tally => tally.Value == 3) ? 4 : 3,
            4 => 2,
            5 => 1,
        };

        public int HandValueWithJokers => UseJokers().TallyCards().Count switch
        {
            1 => 7,
            2 => UseJokers().TallyCards().Any(tally => tally.Value == 4) ? 6 : 5,
            3 => UseJokers().TallyCards().Any(tally => tally.Value == 3) ? 4 : 3,
            4 => 2,
            5 => 1,
        };

        private string UseJokers()
        {
            var tallies = Cards.TallyCards();
            var jokerCount = tallies.Count(tally => tally.Key == 'J');

            if (jokerCount == 0) return Cards;

            var bestCard = tallies
                .Where(tally => tally.Key != 'J')
                .OrderBy(tallies => tallies.Value)
                .ThenBy(tallies => tallies.Key.CardValue())
                .LastOrDefault(new KeyValuePair<char, int>('A', 0))
                .Key;

            return Cards.Replace('J', bestCard);
        }
    }
}

using Basje.AdventOfCode.Y2023.Input;

namespace Basje.AdventOfCode.Y2023.D04;

public class Day04 : Solution<IEnumerable<Card>>
{
    protected override IEnumerable<Card> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => line.Split(": "))
            .Select(line => (CardInfo: line.First(), NumberInfo: line.Last()))
            .Select(line => (
                CardInfo: line.CardInfo.Split(" ").Last(),
                NumberInfo: line.NumberInfo.Split(" | ")))
            .Select(line => (
                CardInfo: int.Parse(line.CardInfo),
                WinningNumbers: line.NumberInfo.First(),
                OurNumbers: line.NumberInfo.Last()))
            .Select(line => (
                line.CardInfo,
                WinningNumbers: line.WinningNumbers.Split(" ").IgnoreEmptyLines(),
                OurNumbers: line.OurNumbers.Split(" ").IgnoreEmptyLines()))
            .Select(line => (
                line.CardInfo,
                WinningNumbers: line.WinningNumbers.Select(int.Parse),
                OurNumbers: line.OurNumbers.Select(int.Parse)))
            .Select(line => new Card(line.CardInfo, line.WinningNumbers, line.OurNumbers));
    }

    protected override object SolvePart1(IEnumerable<Card> cards)
    {
        return cards
            .Select(card => card.WinningNumbers.Intersect(card.OurNumbers))
            .Select(bothSides => bothSides.Count())
            .Select(numberCount => Math.Pow(2, numberCount - 1))
            .Select(points => (int)Math.Round(points))
            .Sum();
    }

    protected override object SolvePart2(IEnumerable<Card> cards)
    {
        var numberOfCards = cards.ToDictionary(card => card.Number, card => 1);

        foreach (var card in cards)
        {
            var wins = card.WinningNumbers.Intersect(card.OurNumbers).Count();
            var copies = numberOfCards[card.Number];

            for (var i = 1; i <= wins; i++)
            {
                numberOfCards[card.Number + i] += copies;
            }
        }

        return numberOfCards
            .Select(card => card.Value)
            .Sum();
    }
}
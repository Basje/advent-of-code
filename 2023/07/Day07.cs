using Basje.AdventOfCode.Y2023.Input;

namespace Basje.AdventOfCode.Y2023.D07;

public class Day07 : Solution<IEnumerable<(string Hand, int Bid)>>
{
    protected override IEnumerable<(string Hand, int Bid)> ParseInput(string input)
    {
        return input
            .PerLine()
            .IgnoreEmptyLines()
            .Select(line => line.Split(" "))
            .Select(line => (Hand: line.First(), Bid: int.Parse(line.Last())));
    }

    protected override object SolvePart1(IEnumerable<(string Hand, int Bid)> lines)
    {
        return lines
            .Select(line => (Hand: new Hand() { Cards = line.Hand }, Bid: line.Bid))
            .OrderByDescending(line => line.Hand, new HandComparer())
            .Select((line, index) => (index + 1) * line.Bid)
            .Sum();
    }

    protected override object SolvePart2(IEnumerable<(string Hand, int Bid)> lines)
    {
        return lines
            .Select(line => (Hand: new Hand() { Cards = line.Hand }, Bid: line.Bid))
            .OrderByDescending(line => line.Hand, new HandComparerWithJokers())
            .Select((line, index) => (index + 1) * line.Bid)
            .Sum();
    }
}
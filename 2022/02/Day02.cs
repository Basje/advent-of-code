namespace Basje.AdventOfCode.Y2022.D02;

public class Day02 : ISolution
{
    private readonly IEnumerable<(char opponent, char me)> strategyGuide;

    public Day02(string input)
    {
        strategyGuide = input
            // Split into separate instructions
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            // Split into opponent's play and our answer
            .Select(instruction => instruction.Split(' ').Select(char.Parse))
            // Convert to tuple
            .Select(instruction => (opponent: instruction.First(), me: instruction.Last()));
    }

    public long SolvePart1()
    {
        return strategyGuide
            .Select(instruction => instruction.TranslateFromChoice())
            .Select(instruction => instruction.MatchScore() + instruction.me.ShapeScore())
            .Sum();
    }

    public long SolvePart2()
    {
        return strategyGuide
            .Select(instruction => instruction.TranslateFromResult())
            .Select(instruction => instruction.me.ShapeScore() + instruction.MatchScore())
            .Sum();
    }
}

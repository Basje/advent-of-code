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

    public object SolvePart1()
    {
        return strategyGuide
            .Select(instruction => instruction.TranslateFromChoice())
            .Select(instruction => instruction.MatchScore() + instruction.me.ShapeScore())
            .Sum();
    }

    public object SolvePart2()
    {
        return strategyGuide
            .Select(instruction => instruction.TranslateFromResult())
            .Select(instruction => instruction.MatchScore() + instruction.me.ShapeScore())
            .Sum();
    }
}

internal static class Extensions
{
    public static (int opponent, int me) TranslateFromChoice(this (char opponent, char me) instruction)
    {
        // ASCII math trick. Results in 0 = rock, 1 = paper, 2 is scissors
        return (instruction.opponent - 'A', instruction.me - 'X');
    }

    public static (int opponent, int me) TranslateFromResult(this (char opponent, char me) instruction)
    {
        var opponent = instruction.opponent - 'A';
        var me = instruction switch
        {
            // Draw, make same choice as opponent
            (_, 'Y') => opponent,
            // I win, modulo math magic
            (_, 'Z') => (opponent + 1) % 3,
            // I lose, modulo math magic
            (_, 'X') => (opponent + 2) % 3,
            // Error
            _ => throw new ArgumentException()
        }; ;
        return (opponent, me);
    }

    public static int ShapeScore(this int shape)
    {
        // Shape is 0-based, score is 1-based
        return shape + 1;
    }

    public static int MatchScore(this (int opponent, int me) instruction)
    {
        return instruction switch
        {
            // I win
            (0, 1) or (1, 2) or (2, 0) => 6,
            // Draw
            (_, _) when instruction.opponent == instruction.me => 3,
            // I lose
            (_, _) => 0,
        };
    }
}

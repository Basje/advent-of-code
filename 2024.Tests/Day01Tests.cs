using Basje.AdventOfCode.Y2024.D01;

namespace Basje.AdventOfCode.Y2024.Tests;

public static class Day01Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day01();
        const string input = """
                             3   4
                             4   3
                             2   5
                             1   3
                             3   9
                             3   3
                             """;

        var answer = solution.SolvePart1(input);

        answer.Should().Be(11);
    }

    [Fact]
    public static void Part2()
    {
        var solution = new Day01();
        const string input = """
                             3   4
                             4   3
                             2   5
                             1   3
                             3   9
                             3   3
                             """;

        var answer = solution.SolvePart2(input);

        answer.Should().Be(31);
    }
}
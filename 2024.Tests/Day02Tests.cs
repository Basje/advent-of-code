using Basje.AdventOfCode.Y2024.D02;

namespace Basje.AdventOfCode.Y2024.Tests;

public static class Day02Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day02();
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;

        var answer = solution.SolvePart1(input);

        answer.Should().Be(2);
    }

    [Fact]
    public static void Part2()
    {
        var solution = new Day02();
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;

        var answer = solution.SolvePart2(input);

        answer.Should().Be(4);
    }
}
using Basje.AdventOfCode.Y2024.D03;

namespace Basje.AdventOfCode.Y2024.Tests;

public static class Day03Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day03();
        const string input = """
                             xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
                             """;

        var answer = solution.SolvePart1(input);

        answer.Should().Be(161);
    }

    [Fact]
    public static void Part2()
    {
        var solution = new Day03();
        const string input = """
                             xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
                             """;

        var answer = solution.SolvePart2(input);

        answer.Should().Be(48);
    }
}
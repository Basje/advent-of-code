using Basje.AdventOfCode.Y2024.D07;

namespace Basje.AdventOfCode.Y2024.Tests;

public static class Day07Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day07();
        const string input = """
                             190: 10 19
                             3267: 81 40 27
                             83: 17 5
                             156: 15 6
                             7290: 6 8 6 15
                             161011: 16 10 13
                             192: 17 8 14
                             21037: 9 7 18 13
                             292: 11 6 16 20
                             """;

        var answer = solution.SolvePart1(input);

        answer.Should().Be(3749);
    }

    [Fact]
    public static void Part2()
    {
        var solution = new Day07();
        const string input = """
                             190: 10 19
                             3267: 81 40 27
                             83: 17 5
                             156: 15 6
                             7290: 6 8 6 15
                             161011: 16 10 13
                             192: 17 8 14
                             21037: 9 7 18 13
                             292: 11 6 16 20
                             """;
        
        var answer = solution.SolvePart2(input);
        
        answer.Should().Be(11387);
    }
}
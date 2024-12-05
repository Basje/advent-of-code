using Basje.AdventOfCode.Y2024.D05;

namespace Basje.AdventOfCode.Y2024.Tests;

public static class Day05Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day05();
        const string input = """
                             47|53
                             97|13
                             97|61
                             97|47
                             75|29
                             61|13
                             75|53
                             29|13
                             97|29
                             53|29
                             61|53
                             97|53
                             61|29
                             47|13
                             75|47
                             97|75
                             47|61
                             75|61
                             47|29
                             75|13
                             53|13
                             
                             75,47,61,53,29
                             97,61,53,29,13
                             75,29,13
                             75,97,47,61,53
                             61,13,29
                             97,13,75,29,47
                             """;

        var answer = solution.SolvePart1(input);

        answer.Should().Be(143);
    }

    [Fact]
    public static void Part2()
    {
        var solution = new Day05();
        const string input = """
                             47|53
                             97|13
                             97|61
                             97|47
                             75|29
                             61|13
                             75|53
                             29|13
                             97|29
                             53|29
                             61|53
                             97|53
                             61|29
                             47|13
                             75|47
                             97|75
                             47|61
                             75|61
                             47|29
                             75|13
                             53|13
                             
                             75,47,61,53,29
                             97,61,53,29,13
                             75,29,13
                             75,97,47,61,53
                             61,13,29
                             97,13,75,29,47
                             """;

        var answer = solution.SolvePart2(input);

        answer.Should().Be(123);
    }
}
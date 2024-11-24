using Basje.AdventOfCode.Y2023.D07;

namespace Basje.AdventOfCode.Y2023.Tests;

public static class Day07Tests
{
    [Fact]
    public static void Part1()
    {
        // Arrange 
        var solution = new Day07();
        var input = """
                    32T3K 765
                    T55J5 684
                    KK677 28
                    KTJJT 220
                    QQQJA 483
                    """;

        // Act
        var answer = solution.SolvePart1(input);

        // Assert
        answer.Should().Be(6440);
    }

    [Fact]
    public static void Part2()
    {
        // Arrange 
        var solution = new Day07();
        var input = """
                    32T3K 765
                    T55J5 684
                    KK677 28
                    KTJJT 220
                    QQQJA 483
                    """;

        // Act
        var answer = solution.SolvePart2(input);

        // Assert
        answer.Should().Be(5905);
    }
}
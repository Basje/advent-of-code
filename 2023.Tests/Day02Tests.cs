using Basje.AdventOfCode.Y2023.D02;

namespace Basje.AdventOfCode.Y2023.Tests;

public static class Day02Tests
{
    [Fact]
    public static void Part1()
    {
        // Arrange
        var solution = new Day02();
        var input = """
                    Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                    Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                    Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                    Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                    Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                    """;

        // Act
        var answer = solution.SolvePart1(input);

        // Assert
        answer.Should().Be(8);
    }

    [Fact]
    public static void Part2()
    {
        // Arrange
        var solution = new Day02();
        var input = """
                    Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                    Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                    Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                    Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                    Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                    """;
        
        // Act
        var answer = solution.SolvePart2(input);
        
        // Assert
        answer.Should().Be(2286);
    }
}
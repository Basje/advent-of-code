using Basje.AdventOfCode.Y2023.D03;

namespace Basje.AdventOfCode.Y2023.Tests;

public static class Day03Tests
{
    [Fact]
    public static void Part1()
    {
        // Arrange
        var solution = new Day03();
        var input = """
                    467..114..
                    ...*......
                    ..35..633.
                    ......#...
                    617*......
                    .....+.58.
                    ..592.....
                    ......755.
                    ...$.*....
                    .664.598..
                    """;
        
        // Act 
        var answer = solution.SolvePart1(input);
        
        // Assert
        answer.Should().Be(4361);
    }

    [Fact]
    public static void Part2()
    {
        // Arrange
        var solution = new Day03();
        var input = """
                    467..114..
                    ...*......
                    ..35..633.
                    ......#...
                    617*......
                    .....+.58.
                    ..592.....
                    ......755.
                    ...$.*....
                    .664.598..
                    """;
        
        // Act 
        var answer = solution.SolvePart2(input);
        
        // Assert
        answer.Should().Be(467835);
    }
}
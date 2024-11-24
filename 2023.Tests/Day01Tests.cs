using Basje.AdventOfCode.Y2023.D01;

namespace Basje.AdventOfCode.Y2023.Tests;

public static class Day01Tests
{
    [Fact]
    public static void Part1()
    {
        // Arrange
        var solution = new Day01();
        const string input = """
                             1abc2
                             pqr3stu8vwx
                             a1b2c3d4e5f
                             treb7uchet
                             """;

        // Act
        var answer = solution.SolvePart1(input);
        
        // Assert
        answer.Should().Be(142);
    }

    [Fact]
    public static void Part2()
    {
        // Arrange
        var solution = new Day01();
        const string input = """
                             two1nine
                             eightwothree
                             abcone2threexyz
                             xtwone3four
                             4nineeightseven2
                             zoneight234
                             7pqrstsixteen
                             """;

        // Act
        var answer = solution.SolvePart2(input);
        
        // Assert 
        answer.Should().Be(281);
    }
}
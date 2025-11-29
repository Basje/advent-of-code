using Basje.AdventOfCode.Y2025.D01;

namespace Basje.AdventOfCode.Y2025.Tests;

public static class Day01Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day01();
        const string input = """
                             // Waiting for the first puzzle
                             """;
        
        var answer = solution.SolvePart1(input);
        
        answer.ShouldBe("// Waiting for the first puzzle");
    }
}
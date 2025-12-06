using Basje.AdventOfCode.Y2025.D06;

namespace Basje.AdventOfCode.Y2025.Tests;

public static class Day06Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day06();
        const string input = """
                             123 328  51 64 
                              45 64  387 23 
                               6 98  215 314
                             *   +   *   + 
                             """;
        
        var answer = solution.SolvePart1(input);
        
        answer.ShouldBe(4277556);
    }
    
    [Fact]
    public static void Part2()
    {
        var solution = new Day06();
        const string input = """
                             X
                             """;
        
        var answer = solution.SolvePart2(input);
        
        answer.ShouldBe("X");
    }
}
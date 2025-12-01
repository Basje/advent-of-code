using Basje.AdventOfCode.Y2025.D01;

namespace Basje.AdventOfCode.Y2025.Tests;

public static class Day01Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day01();
        const string input = """
                             L68
                             L30
                             R48
                             L5
                             R60
                             L55
                             L1
                             L99
                             R14
                             L82
                             """;
        
        var answer = solution.SolvePart1(input);
        
        answer.ShouldBe(3);
    }
    
    [Fact]
    public static void Part2()
    {
        var solution = new Day01();
        const string input = """
                             L68
                             L30
                             R48
                             L5
                             R60
                             L55
                             L1
                             L99
                             R14
                             L82
                             """;
        
        var answer = solution.SolvePart2(input);
        
        answer.ShouldBe(6);
    }
    
    [Fact]
    public static void Part2_FullRotationEdgeCase()
    {
        var solution = new Day01();
        const string input = """
                             L68
                             L30
                             R48
                             L5
                             R60
                             L55
                             L1
                             L99
                             R14
                             L182
                             R1000
                             """;
        
        var answer = solution.SolvePart2(input);
        
        answer.ShouldBe(17);
    }
}
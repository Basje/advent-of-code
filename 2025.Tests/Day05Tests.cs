using Basje.AdventOfCode.Y2025.D05;

namespace Basje.AdventOfCode.Y2025.Tests;

public static class Day05Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day05();
        const string input = """
                             3-5
                             10-14
                             16-20
                             12-18
                             
                             1
                             5
                             8
                             11
                             17
                             32
                             """;
        
        var answer = solution.SolvePart1(input);
        
        answer.ShouldBe(3);
    }
    
    [Fact]
    public static void Part2()
    {
        var solution = new Day05();
        const string input = """
                             3-5
                             10-14
                             16-20
                             12-18
                             
                             1
                             5
                             8
                             11
                             17
                             32
                             """;
        
        var answer = solution.SolvePart2(input);
        
        answer.ShouldBe(14);
    }
}
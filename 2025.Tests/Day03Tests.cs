using Basje.AdventOfCode.Y2025.D03;

namespace Basje.AdventOfCode.Y2025.Tests;

public static class Day03Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day03();
        const string input = """
                             987654321111111
                             811111111111119
                             234234234234278
                             818181911112111
                             """;
        
        var answer = solution.SolvePart1(input);
        
        answer.ShouldBe(357);
    }
    
    [Fact]
    public static void Part2()
    {
        var solution = new Day03();
        const string input = """
                             987654321111111
                             811111111111119
                             234234234234278
                             818181911112111
                             """;
        
        var answer = solution.SolvePart2(input);
        
        answer.ShouldBe(3121910778619);
    }
}
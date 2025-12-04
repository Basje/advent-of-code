using Basje.AdventOfCode.Y2025.D04;

namespace Basje.AdventOfCode.Y2025.Tests;

public static class Day04Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day04();
        const string input = """
                             ..@@.@@@@.
                             @@@.@.@.@@
                             @@@@@.@.@@
                             @.@@@@..@.
                             @@.@@@@.@@
                             .@@@@@@@.@
                             .@.@.@.@@@
                             @.@@@.@@@@
                             .@@@@@@@@.
                             @.@.@@@.@.
                             """;
        
        var answer = solution.SolvePart1(input);
        
        answer.ShouldBe(13);
    }
    
    [Fact]
    public static void Part2()
    {
        var solution = new Day04();
        const string input = """
                             ..@@.@@@@.
                             @@@.@.@.@@
                             @@@@@.@.@@
                             @.@@@@..@.
                             @@.@@@@.@@
                             .@@@@@@@.@
                             .@.@.@.@@@
                             @.@@@.@@@@
                             .@@@@@@@@.
                             @.@.@@@.@.
                             """;
        
        var answer = solution.SolvePart2(input);
        
        answer.ShouldBe(43);
    }
}
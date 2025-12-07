using Basje.AdventOfCode.Y2025.D07;

namespace Basje.AdventOfCode.Y2025.Tests;

public static class Day07Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day07();
        const string input = """
                             .......S.......
                             ...............
                             .......^.......
                             ...............
                             ......^.^......
                             ...............
                             .....^.^.^.....
                             ...............
                             ....^.^...^....
                             ...............
                             ...^.^...^.^...
                             ...............
                             ..^...^.....^..
                             ...............
                             .^.^.^.^.^...^.
                             ...............  
                             """;
        
        var answer = solution.SolvePart1(input);
        
        answer.ShouldBe(21);
    }
    
    [Fact]
    public static void Part2()
    {
        var solution = new Day07();
        const string input = """
                             X  
                             """;
        
        var answer = solution.SolvePart2(input);
        
        answer.ShouldBe("X");
    }
}
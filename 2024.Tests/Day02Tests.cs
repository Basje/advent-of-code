using Basje.AdventOfCode.Y2024.D02;

namespace Basje.AdventOfCode.Y2024.Tests;

public static class Day02Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day02();
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;

        var answer = solution.SolvePart1(input);

        answer.Should().Be(2);
    }

    [Fact]
    public static void Part2()
    {
        var solution = new Day02();
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;

        var answer = solution.SolvePart2(input);

        answer.Should().Be(4);
    }

    [Fact]
    public static void Part2EdgeCases()
    {
        var solution = new Day02();
        
        // These edge cases are the ones that tripped 
        // up my initial solution. It anticipates the 
        // fact that increase or decrease are determined
        // using the first two numbers, and then go
        // into the other direction. Well played, Eric.
        const string input = """
                             88 86 88 89 90 93 95
                             47 50 47 46 44 41 38 37
                             """;

        var answer = solution.SolvePart2(input);

        answer.Should().Be(2);
    }
}
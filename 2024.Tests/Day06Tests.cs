using Basje.AdventOfCode.Y2024.D06;

namespace Basje.AdventOfCode.Y2024.Tests;

public static class Day06Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day06();
        const string input = """
                             ....#.....
                             .........#
                             ..........
                             ..#.......
                             .......#..
                             ..........
                             .#..^.....
                             ........#.
                             #.........
                             ......#...
                             """;

        var answer = solution.SolvePart1(input);

        answer.Should().Be(41);
    }

    [Fact]
    public static void Part2()
    {
        // var solution = new Day06();
        // const string input = """
        //                      ....#.....
        //                      .........#
        //                      ..........
        //                      ..#.......
        //                      .......#..
        //                      ..........
        //                      .#..^.....
        //                      ........#.
        //                      #.........
        //                      ......#...
        //                      """;
        //
        // var answer = solution.SolvePart2(input);
        //
        // answer.Should().Be(6);
    }
}
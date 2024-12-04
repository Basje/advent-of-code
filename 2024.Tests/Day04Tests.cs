using Basje.AdventOfCode.Y2024.D04;

namespace Basje.AdventOfCode.Y2024.Tests;

public static class Day04Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day04();
        const string input = """
                             MMMSXXMASM
                             MSAMXMSMSA
                             AMXSXMAAMM
                             MSAMASMSMX
                             XMASAMXAMM
                             XXAMMXXAMA
                             SMSMSASXSS
                             SAXAMASAAA
                             MAMMMXMMMM
                             MXMXAXMASX
                             """;

        var answer = solution.SolvePart1(input);

        answer.Should().Be(18);
    }

    [Fact]
    public static void Part2()
    {
        var solution = new Day04();
        const string input = """
                             MMMSXXMASM
                             MSAMXMSMSA
                             AMXSXMAAMM
                             MSAMASMSMX
                             XMASAMXAMM
                             XXAMMXXAMA
                             SMSMSASXSS
                             SAXAMASAAA
                             MAMMMXMMMM
                             MXMXAXMASX
                             """;

        var answer = solution.SolvePart2(input);

        answer.Should().Be(9);
    }
}
using Basje.AdventOfCode.Y2023.D06;

namespace Basje.AdventOfCode.Y2023.Tests
{
    public static class Day06Tests
    {
        [Fact]
        public static void Part1() 
        {
            // Arrange 
            var solution = new Day06();
            var input = """
                        Time:      7  15   30
                        Distance:  9  40  200
                        """;

            // Act
            var answer = solution.SolvePart1(input);

            // Assert
            answer.Should().Be(288);
        }

        [Fact]
        public static void Part2()
        {
            // Arrange 
            var solution = new Day06();
            var input = """
                        Time:      7  15   30
                        Distance:  9  40  200
                        """;

            // Act
            var answer = solution.SolvePart2(input);

            // Assert
            answer.Should().Be(71503);
        }
    }
}

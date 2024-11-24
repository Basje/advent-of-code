using Basje.AdventOfCode.Y2023.D09;

namespace Basje.AdventOfCode.Y2023.Tests
{
    public static class Day09Tests
    {
        [Fact]
        public static void Part1()
        {
            // Arrange
            var solution = new Day09();
            var input = """
                        0 3 6 9 12 15
                        1 3 6 10 15 21
                        10 13 16 21 30 45
                        """;

            // Act
            var answer = solution.SolvePart1(input);

            // Assert
            answer.Should().Be(114);
        }

        [Fact]
        public static void Part2()
        {
            // Arrange
            var solution = new Day09();
            var input = """
                        0 3 6 9 12 15
                        1 3 6 10 15 21
                        10 13 16 21 30 45
                        """;

            // Act
            var answer = solution.SolvePart2(input);

            // Assert
            answer.Should().Be(2);
        }
    }
}

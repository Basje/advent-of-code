using Basje.AdventOfCode.Y2021.D01;

using FluentAssertions;

using Xunit;

namespace Basje.AdventOfCode.Y2021.Tests
{
    public class Day01Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Arrange
            var puzzle = new Day01(ExampleInput());

            // Act
            var answer1 = puzzle.SolvePart1();

            // Assert
            answer1.Should().Be(7.ToString());
        }

        [Fact]
        public void Part2Test()
        {
            // Arrange
            var puzzle = new Day01(ExampleInput());

            // Act
            var answer1 = puzzle.SolvePart2();

            // Assert
            answer1.Should().Be(5.ToString());
        }

        private string[] ExampleInput()
        {
            return new[]
            {
                "199",
                "200",
                "208",
                "210",
                "200",
                "207",
                "240",
                "269",
                "260",
                "263",
            };
        }
    }
}
using Basje.AdventOfCode.Y2021.D06;

using FluentAssertions;

using Xunit;

namespace Basje.AdventOfCode.Y2021.Tests
{
    
    public class Day06Tests
    {
        [Fact]
        public void Part1_Should_Return_5934_For_Example_Input()
        {
            var puzzle = new Day06(TestInput.Lines);

            var answer = puzzle.SolvePart1();

            answer.Should().Be(5934.ToString());
        }

        [Fact]
        public void Part2_Should_Return_26984457539_For_Example_Input()
        {
            var puzzle = new Day06(TestInput.Lines);

            var answer = puzzle.SolvePart2();

            answer.Should().Be(26984457539.ToString());
        }

        private static class TestInput
        {
            public static string[] Lines => new string[] {
                "3,4,3,1,2",
            };
        }
    }
}

using Basje.AdventOfCode.Y2021.D07;

using FluentAssertions;

using Xunit;

namespace Basje.AdventOfCode.Y2021.Tests
{
    
    public class Day07Tests
    {
        [Fact]
        public void Part1_Should_Return_37_For_Example_Input()
        {
            var puzzle = new Day07(TestInput.Locations);

            var answer = puzzle.SolvePart1();

            answer.Should().Be(37.ToString());
        }

        [Fact]
        public void Part2_Should_Return_168_For_Example_Input()
        {
            var puzzle = new Day07(TestInput.Locations);

            var answer = puzzle.SolvePart2();

            answer.Should().Be(168.ToString());
        }

        private static class TestInput
        {
            public static string[] Locations => new[] { "16,1,2,0,4,2,7,1,2,14" };
        }
    }
}

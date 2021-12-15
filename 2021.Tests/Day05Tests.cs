using Basje.AdventOfCode.Y2021.D05;

using FluentAssertions;

using Xunit;

namespace Basje.AdventOfCode.Y2021.Tests
{
    
    public class Day05Tests
    {
        [Fact]
        public void Part1_Should_Return_5_For_Example_Input()
        {
            var puzzle = new Day05(TestInput.Lines);

            var answer = puzzle.SolvePart1();

            answer.Should().Be(5.ToString());
        }

        [Fact]
        public void Part2_Should_Return_12_For_Example_Input()
        {
            var puzzle = new Day05(TestInput.Lines);

            var answer = puzzle.SolvePart2();

            answer.Should().Be(12.ToString());
        }

        private static class TestInput
        {
            public static string[] Lines => new string[] {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2",
            };
        }
    }
}

using Basje.AdventOfCode.Y2021.D09;

using FluentAssertions;

using Xunit;

namespace Basje.AdventOfCode.Y2021.Tests
{
    
    public class Day09Tests
    {
        [Fact]
        public void Part1_Should_Return_15_For_Example_Input()
        {
            var puzzle = new Day09(TestInput.Lines);

            var answer = puzzle.SolvePart1();

            answer.Should().Be(15.ToString());
        }

        //[Fact]
        //public void Part2_Should_Return_X_For_Example_Input()
        //{
        //    var puzzle = new Day09(TestInput.Lines);

        //    var answer = puzzle.SolvePart2();

        //    answer.Should().Be("X");
        //}

        private static class TestInput
        {
            public static string[] Lines => new string[] {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678",
            };
        }
    }
}

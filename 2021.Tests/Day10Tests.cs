using Basje.AdventOfCode.Y2021.D10;

using FluentAssertions;

using Xunit;

namespace Basje.AdventOfCode.Y2021.Tests
{
    
    public class Day10Tests
    {
        [Fact]
        public void Part1_Should_Return_26397_For_Example_Input()
        {
            var puzzle = new Day10(TestInput.Lines);

            var answer = puzzle.SolvePart1();

            answer.Should().Be(26397.ToString());
        }

        [Fact]
        public void Part2_Should_Return_288957_For_Example_Input()
        {
            var puzzle = new Day10(TestInput.Lines);

            var answer = puzzle.SolvePart2();

            answer.Should().Be(288957.ToString());
        }

        private static class TestInput
        {
            public static string[] Lines => new string[] {
                "[({(<(())[]>[[{[]{<()<>>",
                "[(()[<>])]({[<{<<[]>>(",
                "{([(<{}[<>[]}>{[]{[(<()>",
                "(((({<>}<{<{<>}{[]{[]{}",
                "[[<[([]))<([[{}[[()]]]",
                "[{[{({}]{}}([{[{{{}}([]",
                "{<[[]]>}<{[{[{[]{()[[[]",
                "[<(<(<(<{}))><([]([]()",
                "<{([([[(<>()){}]>(<<{{",
                "<{([{{}}[<[[[<>{}]]]>[]]",
            };
        }
    }
}

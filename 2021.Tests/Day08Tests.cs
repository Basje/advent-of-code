using Basje.AdventOfCode.Y2021.D08;

using FluentAssertions;

using Xunit;

namespace Basje.AdventOfCode.Y2021.Tests
{
    
    public class Day08Tests
    {
        [Fact]
        public void Part1_Should_Return_26_For_Example_Input()
        {
            var puzzle = new Day08(TestInput.Lines);

            var answer = puzzle.SolvePart1();

            answer.Should().Be(26.ToString());
        }

        [Fact]
        public void Part2_Should_Return_61229_For_Example_Input()
        {
            var puzzle = new Day08(TestInput.Lines);

            var answer = puzzle.SolvePart2();

            answer.Should().Be(61229.ToString());
        }

        private static class TestInput
        {
            public static string[] Lines => new string[] {
                "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
                "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
                "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
                "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
                "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
                "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
                "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
                "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
                "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
                "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
            };
        }
    }
}

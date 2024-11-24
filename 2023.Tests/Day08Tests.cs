using Basje.AdventOfCode.Y2023.D08;

namespace Basje.AdventOfCode.Y2023.Tests
{
    public static class Day08Tests
    {
        [Fact]
        public static void Part1a()
        {
            // Arrange
            var solution = new Day08();
            var input = """
                        RL

                        AAA = (BBB, CCC)
                        BBB = (DDD, EEE)
                        CCC = (ZZZ, GGG)
                        DDD = (DDD, DDD)
                        EEE = (EEE, EEE)
                        GGG = (GGG, GGG)
                        ZZZ = (ZZZ, ZZZ)
                        """;

            // Act
            var answer = solution.SolvePart1(input);

            // Assert
            answer.Should().Be(2);
        }

        [Fact]
        public static void Part1b() 
        {
            // Arrange
            var solution = new Day08();
            var input = """
                        LLR

                        AAA = (BBB, BBB)
                        BBB = (AAA, ZZZ)
                        ZZZ = (ZZZ, ZZZ)
                        """;

            // Act
            var answer = solution.SolvePart1(input);

            // Assert
            answer?.Should().Be(6);
        }

        [Fact]
        public static void Part2() 
        {
            // Arrange
            var solution = new Day08();
            var input = """
                        LR

                        11A = (11B, XXX)
                        11B = (XXX, 11Z)
                        11Z = (11B, XXX)
                        22A = (22B, XXX)
                        22B = (22C, 22C)
                        22C = (22Z, 22Z)
                        22Z = (22B, 22B)
                        XXX = (XXX, XXX)
                        """;

            // Act
            var answer = solution.SolvePart2(input);

            // Assert
            answer?.Should().Be(6);
        }
    }
}

using Basje.AdventOfCode.Y2021.D04;

using FluentAssertions;

using System.Linq;

using Xunit;

namespace Basje.AdventOfCode.Y2021.Tests
{
    public class Day04Tests
    {
        [Fact]
        public void SolvePart1_Should_Return_4512_For_Example_Input()
        {
            // Arrange
            var puzzle = new Day04(ExampleData.ExampleInput);

            // Act
            var answer = puzzle.SolvePart1();

            // Assert
            answer.Should().Be(4512.ToString());
        }

        [Fact]
        public void SolvePart2_Should_Return_1924_For_Example_Input()
        {
            // Arrange
            var puzzle = new Day04(ExampleData.ExampleInput);

            // Act
            var answer = puzzle.SolvePart2();

            // Assert
            answer.Should().Be(1924.ToString());
        }

        [Fact]
        public void BingoBoard1()
        {
            // Arrange
            var board = new BingoBoard(ExampleData.ExampleBoard1);
            var numbers = ExampleData.ExampleNumbers;

            // Act
            foreach(var number in numbers)
            {
                board.Mark(number);
            }

            // Assert
            board.IsBingoColumn(0).Should().BeFalse();
            board.IsBingoColumn(1).Should().BeFalse();
            board.IsBingoColumn(2).Should().BeFalse();
            board.IsBingoColumn(3).Should().BeFalse();
            board.IsBingoColumn(4).Should().BeFalse();

            board.IsBingoRow(0).Should().BeFalse();
            board.IsBingoRow(1).Should().BeFalse();
            board.IsBingoRow(2).Should().BeFalse();
            board.IsBingoRow(3).Should().BeFalse();
            board.IsBingoRow(4).Should().BeFalse();
        }

        [Fact]
        public void BingoBoard2()
        {
            // Arrange
            var board = new BingoBoard(ExampleData.ExampleBoard2);
            var numbers = ExampleData.ExampleNumbers;

            // Act
            foreach (var number in numbers)
            {
                board.Mark(number);
            }

            // Assert
            board.IsBingoColumn(0).Should().BeFalse();
            board.IsBingoColumn(1).Should().BeFalse();
            board.IsBingoColumn(2).Should().BeFalse();
            board.IsBingoColumn(3).Should().BeFalse();
            board.IsBingoColumn(4).Should().BeFalse();

            board.IsBingoRow(0).Should().BeFalse();
            board.IsBingoRow(1).Should().BeFalse();
            board.IsBingoRow(2).Should().BeFalse();
            board.IsBingoRow(3).Should().BeFalse();
            board.IsBingoRow(4).Should().BeFalse();
        }

        [Fact]
        public void BingoBoard3()
        {
            // Arrange
            var board = new BingoBoard(ExampleData.ExampleBoard3);
            var numbers = ExampleData.ExampleNumbers;

            // Act
            foreach (var number in numbers)
            {
                board.Mark(number);
            }

            var unmarkedNumbers = board.GetUnmarkedNumbers();
            var lastNumber = numbers.Last();
            var answer = unmarkedNumbers.Sum() * lastNumber;

            // Assert
            board.IsBingoColumn(0).Should().BeFalse();
            board.IsBingoColumn(1).Should().BeFalse();
            board.IsBingoColumn(2).Should().BeFalse();
            board.IsBingoColumn(3).Should().BeFalse();
            board.IsBingoColumn(4).Should().BeFalse();

            board.IsBingoRow(0).Should().BeTrue();
            board.IsBingoRow(1).Should().BeFalse();
            board.IsBingoRow(2).Should().BeFalse();
            board.IsBingoRow(3).Should().BeFalse();
            board.IsBingoRow(4).Should().BeFalse();

            unmarkedNumbers.Sum().Should().Be(188);
            lastNumber.Should().Be(24);
            answer.Should().Be(4512);
        }

        private static class ExampleData {

            public static string ExampleInput => @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

            public static int[] ExampleNumbers => new[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24 };

            public static int[,] ExampleBoard1 => new[,] {
                { 22, 13, 17, 11,  0 },
                {  8,  2, 23,  4, 24 },
                { 21,  9, 14, 16,  7 },
                {  6, 10,  3, 18,  5 },
                {  1, 12, 20, 15, 19 },
            };

            public static int[,] ExampleBoard2 => new[,] {
                {  3, 15,  0,  2, 22 },
                {  9, 18, 13, 17,  5 },
                { 19,  8,  7, 25, 23 },
                { 20, 11, 10, 24,  4 },
                { 14, 21, 16, 12,  6 },
            };

            public static int[,] ExampleBoard3 => new[,] {
                { 14, 21, 17, 24,  4 },
                { 10, 16, 15,  9, 19 },
                { 18,  8, 23, 26, 20 },
                { 22, 11, 13,  6,  5 },
                {  2,  0, 12,  3,  7 },
            };

        }
    }
}

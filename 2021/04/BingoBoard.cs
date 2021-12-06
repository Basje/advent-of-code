namespace Basje.AdventOfCode.Y2021.D04
{
    public class BingoBoard
    {
        private readonly int[,] numbers;
        private readonly bool[,] marks;

        public BingoBoard(int[,] numbers)
        {
            this.numbers = numbers;
            this.marks = new bool[numbers.GetLength(0), numbers.GetLength(1)];
        }

        public void Mark(int number)
        {
            for (var x = 0; x < numbers.GetLength(0); x++)
            {
                for (var y = 0; y < numbers.GetLength(1); y++)
                {
                    if (numbers[x, y] == number)
                    {
                        marks[x, y] = true;
                    }
                }
            }
        }

        public IEnumerable<int> GetUnmarkedNumbers()
        {
            for (var x = 0; x < marks.GetLength(0); x++)
            {
                for (var y = 0; y < marks.GetLength(1); y++)
                {
                    if (marks[x, y] == false)
                    {
                        yield return numbers[x, y];
                    }
                }
            }
        }

        public bool HasBingo()
        {
            for (var row = 0; row < marks.GetLength(0); row++)
            {
                if (IsBingoRow(row)) return true;
            }
            for (var column = 0; column < marks.GetLength(0); column++)
            {
                if (IsBingoColumn(column)) return true;
            }
            return false;
        }

        public bool IsBingoRow(int rowNumber)
        {
            return GetMarksForRow(rowNumber).All(mark => mark);
        }

        public bool IsBingoColumn(int columnNumber)
        {
            return GetMarksForColumn(columnNumber).All(mark => mark);
        }

        private bool[] GetMarksForColumn(int columnNumber)
        {
            return GetColumn(marks, columnNumber);
        }

        private bool[] GetMarksForRow(int rowNumber)
        {
            return GetRow(marks, rowNumber);
        }

        private static T[] GetColumn<T>(T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        private static T[] GetRow<T>(T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}

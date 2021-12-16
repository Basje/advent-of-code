namespace Basje.AdventOfCode.Y2021.D09
{
    public class Day09 : ISolution
    {
        private readonly int[,] heightmap;
        private int MatrixWidth => heightmap.GetLength(0);
        private int MatrixHeight => heightmap.GetLength(1);

        public Day09(IEnumerable<string> input)
        {
            var matrixWidth = input.First().Length;
            var matrixHeight = input.Count();

            heightmap = new int[matrixWidth, matrixHeight];

            for (var x = 0; x < matrixWidth; x++)
            {
                for (var y = 0; y < matrixHeight; y++)
                {
                    heightmap[x, y] = int.Parse(input.ElementAt(y)[x].ToString());
                }
            }
        }

        public string SolvePart1()
        {
            var totalRiskLevel = 0;

            for (var x = 0; x < MatrixWidth; x++)
            {
                for (var y = 0; y < MatrixHeight; y++)
                {
                    if (IsLowPoint(x, y))
                    {
                        totalRiskLevel += heightmap[x, y] + 1;
                    }
                }
            }
            return totalRiskLevel.ToString();
        }

        public string SolvePart2()
        {
            return string.Empty;
        }

        private bool IsLowPoint(int x, int y)
        {
            var isLowestPoint = true;

            for (var deltaX = -1; deltaX <= 1; deltaX++)
            {
                for (var deltaY = -1; deltaY <= 1; deltaY++)
                {
                    var checkX = x + deltaX;
                    var checkY = y + deltaY;

                    if (checkX < 0 || checkY < 0) continue;
                    if (checkX >= MatrixWidth || checkY >= MatrixHeight) continue;
                    if (checkX == x && checkY == y) continue;
                    if (checkX != x && checkY != y) continue;

                    isLowestPoint = isLowestPoint && heightmap[x, y] < heightmap[checkX, checkY];
                }
            }

            return isLowestPoint;
        }
    }
}

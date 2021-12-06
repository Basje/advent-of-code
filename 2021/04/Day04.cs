namespace Basje.AdventOfCode.Y2021.D04
{
    public class Day04 : ISolution
    {
        private readonly IEnumerable<int> numberDraws;
        private readonly IList<BingoBoard> boards = new List<BingoBoard>();

        public Day04(string input)
        {
            input = input.Replace("\r", string.Empty);

            var blocks = input.Split("\n\n").ToList();

            numberDraws = blocks.First().Split(',').Select(int.Parse).ToArray();

            blocks.RemoveAt(0);

            var boardsData = blocks
                .Select(block => block.Split("\n", StringSplitOptions.RemoveEmptyEntries))
                .Select(block => block.Select(line => 
                    line
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray()
                    )
                    .ToArray()
                )
                .ToArray();

            foreach (var boardData in boardsData)
            {
                var matrixHeight = boardData.Count();
                var matrixWidth = boardData.First().Count();
                var data = new int[matrixWidth, matrixHeight];

                for (var x = 0; x < matrixWidth; x++)
                {
                    for (var y = 0; y < matrixHeight; y++)
                    {
                        data[x, y] = boardData[y][x];
                    }
                }


                boards.Add(new BingoBoard(data));
            }
        }

        public string SolvePart1()
        {
            BingoBoard? winningBoard = null;
            int winningNumber = 0;

            foreach (var number in numberDraws)
            {
                foreach (var board in boards)
                {
                    board.Mark(number);

                    if (board.HasBingo())
                    {
                        winningBoard = board;
                        winningNumber = number;

                        break;
                    }
                }
                if (winningBoard is not null) break;
            }

            return checked(winningNumber * winningBoard!.GetUnmarkedNumbers().Sum()).ToString();
        }

        public string SolvePart2()
        {
            var remainingBoards = boards.ToList();
            int winningNumber = 0;
            BingoBoard? winningBoard = null;

            foreach (var number in numberDraws)
            {
                foreach (var board in boards)
                {
                    board.Mark(number);

                    if (board.HasBingo())
                    {
                        remainingBoards.Remove(board);
                    }

                    if (!remainingBoards.Any())
                    {
                        winningNumber = number;
                        winningBoard = board;
                        break;
                    }
                }

                if (!remainingBoards.Any()) break;
            }

            return checked(winningNumber * winningBoard!.GetUnmarkedNumbers().Sum()).ToString();

        }
    }
}

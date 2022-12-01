namespace Basje.AdventOfCode.Y2021.D06
{
    public class Day06 : ISolution
    {
        private readonly List<int> initialState;

        public Day06(IEnumerable<string> input)
        {
            var stateLine = input.First();

            initialState = stateLine.Split(",").Select(int.Parse).ToList();
        }

        public string SolvePart1()
        {
            var state = new LanternFishState(initialState);

            for (int i = 0; i < 80; i++)
            {
                state.NextDay();
            }

            return state.FishCount.ToString();
        }

        public string SolvePart2()
        {
            var state = new LanternFishState(initialState);

            for (int i = 0; i < 256; i++)
            {
                state.NextDay();
            }

            return state.FishCount.ToString();
        }
    }
}

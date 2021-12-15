namespace Basje.AdventOfCode.Y2021.D06
{
    public class LanternFishState
    {
        private readonly Dictionary<int, long> state = new();

        public long FishCount => state.Sum(entry => entry.Value);

        public LanternFishState(IEnumerable<int> initialState)
        {
            Enumerable.Range(0,9).ToList().ForEach(i => state[i] = 0);

            initialState.ToList().ForEach(i => state[i]++);
        }

        public void NextDay()
        {
            var oldState = state.ToDictionary(entry => entry.Key, entry => entry.Value);

            Enumerable.Range(0, 9).ToList().ForEach(i => { 
                switch (i)
                {
                    case 0:
                        state[8] = oldState[0];
                        state[6] = oldState[0];
                        break;
                    case 7:
                        state[6] += oldState[7];
                        break;
                    default:
                        state[i - 1] = oldState[i];
                        break;
                }
            });
        }
    }
}

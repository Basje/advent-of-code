namespace Basje.AdventOfCode.Y2021.D07
{
    public class Day07 : ISolution
    {
        private readonly IEnumerable<int> positions;

        public Day07(string input)
        {
            positions = input.Split(',').Select(int.Parse);
        }

        public string SolvePart1()
        {
            var fuelConsumption = new Dictionary<int, int>();

            foreach (var destination in positions)
            {
                fuelConsumption[destination] = positions.Select(position => Math.Abs(position - destination)).Sum();
            }
            var answer = fuelConsumption.Min(entry => entry.Value);

            return answer.ToString();
        }

        public string SolvePart2()
        {
            var fuelConsumption = new Dictionary<int, int>();
            var max = positions.Max();
            var min = positions.Min();

            for (int destination = min; destination <= max; destination++)
            {
                fuelConsumption[destination] = positions.Select(position => CalculateNonLinearFuelConsumption(Math.Abs(position - destination))).Sum();
            }
            var answer = fuelConsumption.Min(entry => entry.Value);

            return answer.ToString();
        }

        private int CalculateNonLinearFuelConsumption(int distance)
        {
            var fuel = 0;

            for (int i = distance; i > 0; i--)
            {
                fuel += i;
            }

            return fuel;
        }
    }
}

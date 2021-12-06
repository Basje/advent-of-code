namespace Basje.AdventOfCode.Y2021.D02
{
    public class Day02 : ISolution
    {
        private readonly IEnumerable<Instruction> instructions;

        public Day02(IEnumerable<string> input)
        {
            instructions = input.Select(line =>
            {
                var instruction = line.Split(' ');
                return new Instruction(instruction[0], int.Parse(instruction[1]));
            });
        }

        public string SolvePart1()
        {
            var position = 0;
            var depth = 0;

            foreach (var instruction in instructions)
            {
                switch (instruction.Dimension)
                {
                    case "forward":
                        position += instruction.Distance;
                        break;
                    case "down":
                        depth += instruction.Distance;
                        break;
                    case "up":
                        depth -= instruction.Distance;
                        break;
                };
            }

            var answer = checked(position * depth);

            return answer.ToString();
        }

        public string SolvePart2()
        {
            var position = 0;
            var depth = 0;
            var aim = 0;

            foreach (var instruction in instructions)
            {
                switch (instruction.Dimension)
                {
                    case "forward":
                        position += instruction.Distance;
                        depth += instruction.Distance * aim;
                        break;
                    case "down":
                        aim += instruction.Distance;
                        break;
                    case "up":
                        aim -= instruction.Distance;
                        break;
                };
            }

            var answer = checked(position * depth);

            return answer.ToString();
        }
    }
}

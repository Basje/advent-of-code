namespace Basje.AdventOfCode.Y2021.D10
{
    public class Day10 : ISolution
    {
        private readonly IEnumerable<string> navigationSubsystem;
        private readonly IDictionary<char, char> pairs = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' },
            { '>', '<' },
        };
        private readonly IDictionary<char, int> characterValues = new Dictionary<char, int>()
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 },
        };

        public Day10(IEnumerable<string> input)
        {
            navigationSubsystem = input;
        }

        public string SolvePart1()
        {
            var errorCharacters = new List<char>();

            foreach (var line in navigationSubsystem)
            {
                var chunckCharacters = new Stack<char>();

                foreach (var character in line)
                {
                    if (pairs.ContainsKey(character))
                    {
                        var currentChunkCharacter = chunckCharacters.Pop();

                        if (!pairs[character].Equals(currentChunkCharacter))
                        {
                            errorCharacters.Add(character);
                            break;
                        }
                    }
                    else
                    {
                        chunckCharacters.Push(character);
                    }
                }
            }

            var syntaxErrorScore = 0;

            foreach (var character in errorCharacters)
            {
                syntaxErrorScore += characterValues[character];
            }            

            return syntaxErrorScore.ToString();
        }

        public string SolvePart2()
        {
            return string.Empty;
        }
    }
}

using Basje.AdventOfCode.Y2023.Input;
using Basje.AdventOfCode.Y2023.Toolbox;

using System.Text.RegularExpressions;

namespace Basje.AdventOfCode.Y2023.D08
{
    public class Day08 : Solution<Map>
    {
        protected override Map ParseInput(string input)
        {
            var data = input
                .PerBlock()
                .IgnoreEmptyLines();

            var maps = data
                .Last()
                .PerLine()
                .IgnoreEmptyLines()
                .Select(line => Regex.Matches(line, "[0-9A-Z]{3}"))
                .Select(captures => new Node() { Name = captures[0].Value, Left = captures[1].Value, Right = captures[2].Value });

            return new Map() { Instructions = data.First(), Nodes = maps };
        }

        protected override object SolvePart1(Map map)
        {
            var nodes = map.Nodes.ToDictionary(entry => entry.Name);
            var currentNode = "AAA";
            var instructionIndex = 0;
            var stepsTaken = 0;

            while (currentNode != "ZZZ") 
            {
                currentNode = map.Instructions[instructionIndex] switch {
                    'L' => nodes[currentNode].Left,
                    'R' => nodes[currentNode].Right,
                }; 
                
                stepsTaken++;
                instructionIndex = stepsTaken % (map.Instructions.Length);
            }

            return stepsTaken;
        }

        protected override object SolvePart2(Map map)
        {
            var nodes = map.Nodes.ToDictionary(entry => entry.Name);
            var startNodes = map.Nodes.Where(node => node.Name[2] == 'A');
            var stepsPerNode = new Dictionary<string, long>();

            foreach (var startNode in startNodes)
            {
                var currentNode = startNode.Name;
                var instructionIndex = 0;
                var stepsTaken = 0;

                while (currentNode[2] != 'Z')
                {
                    currentNode = map.Instructions[instructionIndex] switch
                    {
                        'L' => nodes[currentNode].Left,
                        'R' => nodes[currentNode].Right,
                    };

                    stepsTaken++;
                    instructionIndex = stepsTaken % (map.Instructions.Length);
                }

                stepsPerNode.Add(startNode.Name, stepsTaken);
            }

            return stepsPerNode.Values.LeastCommonMultiple();
        }
    }
}

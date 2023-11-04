using System.Text;
using System.Text.RegularExpressions;

namespace Basje.AdventOfCode.Y2022.D05;

public class Day05 : ISolution
{
    private readonly List<Stack<char>> crates1;
    private readonly List<Stack<char>> crates2;
    private readonly IEnumerable<(int number, int from, int to)> steps;

    public Day05(string input)
    {
        // Split input into stacks and steps
        var inputs = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        // Parse input, create two copies of the crate stacks because part 1 will
        // change the state and prevent part 2 from working properly.
        crates1 = ParseStacksInput(inputs.First());
        crates2 = ParseStacksInput(inputs.First());
        steps = ParseStepsInput(inputs.Last());
    }

    private static List<Stack<char>> ParseStacksInput(string input)
    {
        // Split stacks into separate lines
        var stacks = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        // Calculate te number of stacks
        var numberOfStacks = stacks.Last().Length / 4 + 1;
        // Keep track of the stacks of crates
        var crates = new List<Stack<char>>();
        // Initialize a stack for every stack (and one extra because we start counting at 1)
        for (int currentStack = 0; currentStack <= numberOfStacks; currentStack++)
        {
            crates.Add(new());
        }
        // Work from the bottom towards the top of the stacks
        for (int level = stacks.Length - 2; level >= 0; level--)
        {
            // Look into the columns for marks and put the marks onto the correct stacks
            for (int column = 1, position = 1; column < stacks.Last().Length - 1; column += 4, position++)
            {
                if (stacks[level][column] == ' ') continue;
                crates[position].Push(stacks[level][column]);
            }
        }
        return crates;
    }

    private static IEnumerable<(int number, int from, int to)> ParseStepsInput(string input)
    {
        // Split steps into separate lines
        var steps = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        // Keep track of the parsed step instructions
        var instructions = new List<(int number, int from, int to)>();
        // Parse the steps using this pattern
        var instructionPattern = new Regex(@"^move (?<number>\d+) from (?<from>\d+) to (?<to>\d+)$");
        
        foreach (var step in steps)
        {
            // Parse step using the pattern
            var match = instructionPattern.Match(step);
            // Add result as triple to the list of step instructions
            instructions.Add((
                number: int.Parse(match.Groups["number"].Value),
                from: int.Parse(match.Groups["from"].Value),
                to: int.Parse(match.Groups["to"].Value)
            ));
        }        

        return instructions;
    }

    public object SolvePart1()
    {
        foreach (var (number, from, to) in steps)
        {
            // Move crates one by one to another stack
            for (int count = 1; count <= number; count++)
            {
                crates1[to].Push(crates1[from].Pop());
            }
        }
        var answer = new StringBuilder();
        // Determine the top crates for all stacks
        foreach (var stack in crates1)
        {
            if (stack.Count == 0) continue;
            answer.Append(stack.Peek());
        }
        return answer.ToString();
    }

    public object SolvePart2()
    {
        foreach (var (number, from, to) in steps)
        {
            var workload = new Stack<char>();
            // Move crates one by one to separate workload stack
            for (int count = 1; count <= number; count++)
            {
                workload.Push(crates2[from].Pop());
            }
            // Move crates one by one to destination stack
            while (workload.Count > 0)
            {
                crates2[to].Push(workload.Pop());
            }
        }
        var answer = new StringBuilder();
        // Determine the top crates for all stacks
        foreach (var stack in crates2)
        {
            if (stack.Count == 0) continue;
            answer.Append(stack.Peek());
        }
        return answer.ToString();
    }
}

namespace Basje.AdventOfCode.Y2022.D11;

public class Day11 : ISolution
{
    private readonly List<Monkey> monkeys = new();

    public Day11(string input)
    {
        monkeys = input
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(monkey => monkey.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            .Select(monkey => monkey.ParseToMonkey()).ToList();
    }

    public object SolvePart1()
    {
        var monkeys = this.monkeys.ToArray();
        for (int round = 1; round <= 20; round++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.Any())
                {
                    var item = monkey.Items.Dequeue();
                    item = monkey.Operation(item);
                    item /= 3;
                    monkey.InspectedItems += 1;

                    monkeys[monkey.Test(item)].Items.Enqueue(item);
                }
            }
        }

        var topMonkeys = monkeys
            .OrderByDescending(monkey => monkey.InspectedItems)
            .Take(2);

        return topMonkeys.First().InspectedItems * topMonkeys.Last().InspectedItems;
    }

    public object SolvePart2()
    {
        return -1;
    }
}

public record class Monkey
{
    public required int Number { get; init; }
    public required Func<int, int> Operation { get; init; }
    public required Func<int, int> Test { get; init; }
    public required Queue<int> Items { get; init; }

    public int InspectedItems = 0;
}

public static class Extensions
{
    public static Monkey ParseToMonkey(this IEnumerable<string> input)
    {
        var data = input.ToList();
        var number = int.Parse(data[0][7].ToString());
        var items = data[1][18..].Split(", ").Select(int.Parse);
        var operation = data[2][23];
        var right = data[2][25..];
        var test = int.Parse(data[3][21..]);
        var trueMonkey = int.Parse(data[4][29..]);
        var falseMonkey = int.Parse(data[5][30..]);

        return new()
        {
            Number = number,
            Items = new Queue<int>(items),
            Operation = old => {
                var change = right switch
                {
                    "old" => old,
                    _ => int.Parse(right),
                };
                return operation switch
                {
                    '+' => old + change,
                    '*' => old * change,
                    _ => throw new Exception(),
                };
            },
            Test = item => (item % test == 0) ? trueMonkey : falseMonkey,
        };

    }
}

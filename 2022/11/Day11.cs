using System.Diagnostics;

namespace Basje.AdventOfCode.Y2022.D11;

public class Day11 : ISolution
{
    private readonly List<Monkey> monkeys;
    private readonly List<Monkey> monkeys2;


    public Day11(string input)
    {
        monkeys = input
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(monkey => monkey.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            .Select(monkey => monkey.ParseToMonkey())
            .ToList();

        monkeys2 = input
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(monkey => monkey.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            .Select(monkey => monkey.ParseToMonkey())
            .ToList();
    }

    public object SolvePart1()
    {
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
        var monkeys = monkeys2;
        var worryManagerNumber = 1;

        foreach (var monkey in monkeys)
        {
            worryManagerNumber *= monkey.TestNumber;
        }

        for (int round = 1; round <= 10_000; round++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.Any())
                {
                    var item = monkey.Items.Dequeue();
                    item = monkey.Operation(item);
                    item %= worryManagerNumber;
                    monkey.InspectedItems += 1;

                    monkeys[monkey.Test(item)].Items.Enqueue(item);
                }
            }
        }

        var topMonkeys = monkeys
            .OrderByDescending(monkey => monkey.InspectedItems)
            .Take(2);

        var x = topMonkeys.First().InspectedItems;
        var y = topMonkeys.Last().InspectedItems;

        return checked (x * y);
    }
}

[DebuggerDisplay("Monkey {Number}, {InspectedItems} inspected items")]
public record class Monkey
{
    public required int Number { get; init; }
    public required Func<long, long> Operation { get; init; }
    public required Func<long, int> Test { get; init; }
    public required int TestNumber { get; init; }
    public required Queue<long> Items { get; init; }

    public long InspectedItems = 0;
}

public static class Extensions
{
    public static Monkey ParseToMonkey(this IEnumerable<string> input)
    {
        var data = input.ToList();
        var number = int.Parse(data[0][7].ToString());
        var items = data[1][18..].Split(", ").Select(long.Parse);
        var operation = data[2][23];
        var right = data[2][25..];
        var test = int.Parse(data[3][21..]);
        var trueMonkey = int.Parse(data[4][29..]);
        var falseMonkey = int.Parse(data[5][30..]);

        return new()
        {
            Number = number,
            Items = new Queue<long>(items),
            Operation = old => {
                var change = right switch
                {
                    "old" => old,
                    _ => int.Parse(right),
                };
                return operation switch
                {
                    '+' => checked (old + change),
                    '*' => checked (old * change),
                    _ => throw new Exception(),
                };
            },
            Test = item => (item % test == 0) ? trueMonkey : falseMonkey,
            TestNumber = test,
        };

    }
}

using Basje.AdventOfCode.Y2016;
using Basje.AdventOfCode.Y2016.Input;
using System.Reflection;

// Use reflection to get all non-abstract implementations of puzzle solutions.
var solutions = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(type => type is { IsClass: true, IsAbstract: false })
    .Where(type => type.GetInterfaces().Contains(typeof(ISolution)))
    .OrderBy(type => type.Name)
    .ToList();

foreach (var solution in solutions)
{
    var instance = (ISolution)Activator.CreateInstance(solution);
    
    if (instance is null) continue;

    var day = int.Parse(solution.Name.Replace("Day", ""));
    var input = Input.Year(2023).Day(day).ReadText();

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{solution.Name.ToUpper()}.1");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(instance.SolvePart1(input));
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{solution.Name.ToUpper()}.2");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(instance.SolvePart2(input));
    Console.WriteLine();
}

Console.ReadKey();
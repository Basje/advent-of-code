using Basje.AdventOfCode.Y2023;
using Basje.AdventOfCode.Y2023.Input;
using System.Reflection;

// Use reflection to get all non-abstract implementations of puzzle solutions.
var solutions = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(type => type is { IsClass: true, IsAbstract: false })
    .Where(type => type.GetInterfaces().Contains(typeof(ISolution)))
    .OrderBy(type => type.Name)
    .ToList();

foreach (var type in solutions)
{
    var instance = Activator.CreateInstance(type);
    
    if (instance is not ISolution solution) continue;

    var day = int.Parse(type.Name.Replace("Day", ""));
    var input = Input.Year(2023).Day(day).ReadText();

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{type.Name.ToUpper()}.1");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(solution.SolvePart1(input));
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{type.Name.ToUpper()}.2");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(solution.SolvePart2(input));
    Console.WriteLine();
}

Console.ReadKey();
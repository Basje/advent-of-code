using Basje.AdventOfCode.Y2022;
using Basje.AdventOfCode.Y2022.Input;
using System.Reflection;

var solutions = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(type => type.IsClass)
    .Where(type => type.GetInterfaces().Contains(typeof(ISolution)))
    .OrderBy(type => type.Name)
    .ToList();

foreach (var solution in solutions)
{
    var day = int.Parse(solution.Name.Replace("Day", ""));
    var instance = (ISolution?)Activator.CreateInstance(solution, args: Input.Year(2022).Day(day).ReadText());

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{solution.Name.ToUpper()}.1");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(instance?.SolvePart1());
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{solution.Name.ToUpper()}.2");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(instance?.SolvePart2());
    Console.WriteLine();
}

Console.ReadKey();
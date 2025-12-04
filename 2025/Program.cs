using System.Diagnostics;
using System.Reflection;
using Basje.AdventOfCode.Y2025;
using Basje.AdventOfCode.Y2025.Input;

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
    var input = Input.Year(2025).Day(day).ReadText();
    
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    var answer1 = solution.SolvePart1(input);
    stopWatch.Stop();
    var elapsedTime = stopWatch.Elapsed;


    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{type.Name.ToUpper()}.1");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(answer1);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{elapsedTime.Microseconds/1000f:N3} ms");
    Console.WriteLine();

    stopWatch.Reset();
    stopWatch.Start();
    var answer2 = solution.SolvePart2(input);
    stopWatch.Stop();
    elapsedTime = stopWatch.Elapsed;

    
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{type.Name.ToUpper()}.2");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(answer2);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"{elapsedTime.TotalMicroseconds/1000f:N3} ms");
    Console.WriteLine();
}

Console.ReadKey();
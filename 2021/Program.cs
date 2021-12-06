using Basje.AdventOfCode.Y2021.D01;
using Basje.AdventOfCode.Y2021.D02;
using Basje.AdventOfCode.Y2021.D03;
using Basje.AdventOfCode.Y2021.D04;
using Basje.AdventOfCode.Y2021.Input;

var day01 = new Day01(Input.Year(2021).Day(1).ReadLines());

Console.WriteLine("DAY 1");
Console.WriteLine($"1: {day01.SolvePart1()}");
Console.WriteLine($"2: {day01.SolvePart2()}");
Console.WriteLine();

var day02 = new Day02(Input.Year(2021).Day(2).ReadLines());

Console.WriteLine("DAY 2");
Console.WriteLine($"1: {day02.SolvePart1()}");
Console.WriteLine($"2: {day02.SolvePart2()}");
Console.WriteLine();

var day03 = new Day03(Input.Year(2021).Day(3).ReadLines());

Console.WriteLine("DAY 3");
Console.WriteLine($"1: {day03.SolvePart1()}");
Console.WriteLine($"2: {day03.SolvePart2()}");
Console.WriteLine();

var day04 = new Day04(Input.Year(2021).Day(4).ReadText());

Console.WriteLine("DAY 4");
Console.WriteLine($"1: {day04.SolvePart1()}");
Console.WriteLine($"2: {day04.SolvePart2()}");
Console.WriteLine();

Console.ReadKey();



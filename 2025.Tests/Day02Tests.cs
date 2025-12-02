using Basje.AdventOfCode.Y2025.D02;

namespace Basje.AdventOfCode.Y2025.Tests;

public static class Day02Tests
{
    [Fact]
    public static void Part1()
    {
        var solution = new Day02();
        const string input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        
        var answer = solution.SolvePart1(input);
        
        answer.ShouldBe(1227775554);
    }
    
    [Fact]
    public static void Part2()
    {
        var solution = new Day02();
        const string input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        
        var answer = solution.SolvePart2(input);
        
        answer.ShouldBe(4174379265);
    }
}

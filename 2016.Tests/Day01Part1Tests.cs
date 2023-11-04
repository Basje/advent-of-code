using Basje.AdventOfCode.Y2016.D01;
using FluentAssertions;

namespace Tests;

public class Day01Part1Tests
{
    [Fact]
    public void Example1()
    {
        var solution = new Day01();
        var answer = solution.SolvePart1("R2, L3");
        answer.Should().Be(5);
    }
    
    [Fact]
    public void Example2()
    {
        var solution = new Day01();
        var answer = solution.SolvePart1("R2, R2, R2");
        answer.Should().Be(2);
    }
    
    [Fact]
    public void Example3()
    {
        var solution = new Day01();
        var answer = solution.SolvePart1("R5, L5, R5, R3");
        answer.Should().Be(12);
    }
    
    [Fact]
    public void Answer()
    {
        var solution = new Day01();
        var answer = solution.SolvePart1("R5, R4, R2, L3, R1, R1, L4, L5, R3, L1, L1, R4, L2, R1, R4, R4, L2, L2, R4, L4, R1, R3, L3, L1, L2, R1, R5, L5, L1, L1, R3, R5, L1, R4, L5, R5, R1, L185, R4, L1, R51, R3, L2, R78, R1, L4, R188, R1, L5, R5, R2, R3, L5, R3, R4, L1, R2, R2, L4, L4, L5, R5, R4, L4, R2, L5, R2, L1, L4, R4, L4, R2, L3, L4, R2, L3, R3, R2, L2, L3, R4, R3, R1, L4, L2, L5, R4, R4, L1, R1, L5, L1, R3, R1, L2, R1, R1, R3, L4, L1, L3, R2, R4, R2, L2, R1, L5, R3, L3, R3, L1, R4, L3, L3, R4, L2, L1, L3, R2, R3, L2, L1, R4, L3, L5, L2, L4, R1, L4, L4, R3, R5, L4, L1, L1, R4, L2, R5, R1, R1, R2, R1, R5, L1, L3, L5, R2");
        answer.Should().Be(231);
    }
}
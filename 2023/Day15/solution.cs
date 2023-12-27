
using System;
using System.Linq;
using adventofcode;

namespace aoc2023;

public class solutionDay15 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("Day 15, Part 1");

        solutionBase solutionBase = new solutionBase();
        var input = solutionBase.getInputString($"2023/Day15/input").Split(',').ToArray();

        var sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var currentValue = 0;
            var currentSequenz = input[i].ToArray();

            for (int j = 0; j < currentSequenz.Length; j++)
            {
                var currentChar = currentSequenz[j];
                var currentAscii = (int)currentChar;
                currentValue += currentAscii;
                currentValue *= 17;
                currentValue %= 256;

                Console.WriteLine($"currentChar: {currentChar} currentAscii: {currentAscii} currentValue: {currentValue}");
                //Console.WriteLine($"currentChar: {currentChar} currentAscii: {currentAscii}");
            }
            Console.WriteLine($"currentValue: {currentValue}");
            sum += currentValue;            
        }
        Console.WriteLine($"sum: {sum}");
    }

    public void SolvePart2()
    {
        Console.WriteLine("Day 15, Part 2");
    }
}
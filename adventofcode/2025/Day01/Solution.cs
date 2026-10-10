using System;
using System.IO;

namespace adventofcode.Year2025.Day01;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        var inputFilePath = GetInputFilePath("input");
        // var inputFilePath = GetInputFilePath();

        string[] lines = File.ReadAllLines(inputFilePath);

        int actual = 50;
        int hitZero = 0;

        foreach (var item in lines)
        {
            char direction = item[0];
            string steps = item.Substring(1, item.Length-1);
            int moves = int.Parse(steps);
            int clicks = moves % 100;

            //Console.WriteLine($"{item} = direction {direction}, steps {steps}, moves {moves}, clicks {clicks}");

            switch (direction)
            {
                case 'R':
                    actual = (actual + clicks) % 100 ;
                    break;
                case 'L':
                    if (actual - clicks < 0)
                    {
                        actual = 100 + actual - clicks;
                    }
                    else
                    {
                        actual = actual - clicks;
                    }
                    break;
                default:
                    break;
            }
            
            if (actual == 0)
                hitZero++;
        }

        Console.WriteLine($"hitZero: {hitZero}");
    }

    public void SolvePart2()
    {
        var inputFilePath = GetInputFilePath("input");
        // var inputFilePath = GetInputFilePath();

        string[] lines = File.ReadAllLines(inputFilePath);

        int actual = 50;
        int hitZero = 0;

        foreach (var item in lines)
        {
            char direction = item[0];
            string steps = item.Substring(1, item.Length-1);
            int moves = int.Parse(steps);
            int clicks = moves % 100;

            //Console.WriteLine($"{item} = direction {direction}, steps {steps}, moves {moves}, clicks {clicks}");

            switch (direction)
            {
                case 'R':
                    actual = (actual + clicks) % 100 ;
                    break;
                case 'L':
                    if (actual - clicks < 0)
                    {
                        actual = 100 + actual - clicks;
                    }
                    else
                    {
                        actual = actual - clicks;
                    }
                    break;
                default:
                    break;
            }
            
            if (actual == 0)
                hitZero++;
        }

        Console.WriteLine($"part 2 hitZero: {hitZero}");
    }
}

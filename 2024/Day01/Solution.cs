using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode.Year2024.Day01;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("part 1");

        //var inputFilePath = GetInputFilePath("test");
        var inputFilePath = GetInputFilePath();
        Console.WriteLine(inputFilePath);

        // Read input file
        string[] lines = File.ReadAllLines(inputFilePath);

        List<long> leftNumbers = new();
        List<long> rightNumbers = new();

        foreach (var line in lines)
        {
            Console.WriteLine(line);
            var left = line.Split("   ")[0];
            var right = line.Split("   ")[1];
            leftNumbers.Add(Convert.ToInt64(left));
            rightNumbers.Add(Convert.ToInt64(right));
        }

        leftNumbers.Sort();
        rightNumbers.Sort();

        long sum = 0;

        for (int i = 0; i < leftNumbers.Count; i++)
        {
            //calculate distance between two numbers
            var distance = rightNumbers[i] - leftNumbers[i];
            distance = Math.Abs(distance);

            sum += distance;
            Console.WriteLine($"{leftNumbers[i]} -=- {rightNumbers[i]} => {distance}, sum: {sum}");
        }
    }

    public void SolvePart2()
    {
        throw new NotImplementedException();
    }
}
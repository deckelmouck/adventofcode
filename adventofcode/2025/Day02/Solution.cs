using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode.Year2025.Day02;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        string file = "input";
        #if DEBUG
        file = "test";
        #endif

        var inputFilePath = GetInputFilePath(file);

        List<string> input = File.ReadAllText(inputFilePath).Split(',').ToList();

        List<(long,long)> ranges = new();

        long sum = 0;

        try
        {
            
        foreach (var item in input)
        {
            long from = long.Parse(item.Split('-')[0]);
            long to = long.Parse(item.Split('-')[1]);

            ranges.Add((from,to));

            for (long i = from; i <= to; i++)
            {
                string number = i.ToString();

                if (number.Length % 2 == 0)
                {
                    int half = number.Length / 2;

                    long left = long.Parse(number.Substring(0, half));

                    long right = long.Parse(number.Substring(half));

                    Console.WriteLine($"left: {left} - right: {right}");
                    if (left == right)
                        sum += i;
                }
            }
        }

        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        Console.WriteLine($"sum: {sum}");
    }

    public void SolvePart2()
    {
        throw new NotImplementedException();
    }

}


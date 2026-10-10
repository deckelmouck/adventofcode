
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode.Year2025.Day05;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        string file = "input";
        #if DEBUG
        file = "test";
        #endif

        var inputFilePath = GetInputFilePath(file);
        List<string> input = File.ReadAllLines(inputFilePath).ToList();
        int total = input.Count;

        List<(long,long)> ranges = new();

        for (int i = 0; i < input.IndexOf(""); i++)
        {
            string item = input[i];
            Console.WriteLine($"{item}");
            Console.WriteLine($"{item.Split('-')[0]} - {item.Split("-")[1]}");
            long from = long.Parse(item.Split("-")[0]);
            long to = long.Parse(item.Split("-")[1]);

            ranges.Add((from,to));
            Console.WriteLine($"from: {from} - to: {to}");
        }
        input.RemoveRange(0, ranges.Count + 1);

        Console.WriteLine($"total: {total}");
        Console.WriteLine($"ranges.count: {ranges.Count}");
        Console.WriteLine($"rest input.count: {input.Count}");
        Console.WriteLine($"sum = {ranges.Count + input.Count + 1}");

        int sumFresh = 0;
        
        foreach (var item in input)
        {
            bool isIn = false;
            long ingredient = long.Parse(item);

            foreach ( (long,long) line in ranges)
            {
                if (line.Item1 <= ingredient && ingredient <= line.Item2)
                    isIn = true;

                if (isIn)
                    break;
            }

            if (isIn)
                sumFresh++;
        }
        Console.WriteLine($"fresh item sum: {sumFresh}");
    }

    public void SolvePart2()
    {
        throw new NotImplementedException();
    }
}
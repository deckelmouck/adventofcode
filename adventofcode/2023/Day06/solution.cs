using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode;

namespace aoc2023;

class solutionDay06 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("Part 1");

        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day06/test").ToArray();
        var input = sb.getInputLines(@"2023/Day06/input").ToArray();

        var times = new string[input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length];
        var distances = new string[input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length];

        times = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        distances = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        int record = 1;

        for (int i = 1; i < times.Length; i++)
        {
            var time = Convert.ToInt32(times[i]);
            var distance = Convert.ToInt32(distances[i]);

            Console.WriteLine($"{time} {distance}");
            int wins = 0;

            for(int t = 1; t < time; t++)
            {
                int hold = t;
                int distanceTravelled = hold * (time - hold);

                if (distanceTravelled > distance)
                {
                    wins++;
                }
            }
            Console.WriteLine($"wins: {wins}");
            record *= wins;
        }
        Console.WriteLine($"record: {record}");
    }

    public void SolvePart2()
    {
        Console.WriteLine("Part 2 - under development");

        
        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day06/test").ToArray();
        //todo: refactor this to work with initial input
        var input = sb.getInputLines(@"2023/Day06/inputtwo").ToArray();

        var times = new string[input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length];
        var distances = new string[input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length];

        times = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        distances = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        Int64 record = 1;

        for (int i = 1; i < times.Length; i++)
        {
            var time = Convert.ToInt64(times[i]);
            var distance = Convert.ToInt64(distances[i]);

            Console.WriteLine($"{time} {distance}");
            Int64 wins = 0;

            for(Int64 t = 1; t < time; t++)
            {
                Int64 hold = t;
                Int64 distanceTravelled = hold * (time - hold);

                if (distanceTravelled > distance)
                {
                    wins++;
                }
            }
            Console.WriteLine($"wins: {wins}");
            record *= wins;
        }
        Console.WriteLine($"record: {record}");
    }
}
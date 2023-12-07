using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode;

namespace aoc2023;

class solutionDay05 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("part 1");

        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day05/test").ToArray();
        var input = sb.getInputLines(@"2023/Day05/input").ToArray();

        var firstLine = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var seeds = firstLine.Where(seed => seed.Any(char.IsDigit));
        Dictionary<long,long> seedlist = new();

        foreach(var seed in seeds)
        {
            Console.WriteLine($"seed: {seed} will be calculated");
            var s = Convert.ToInt64(seed);
            var mapped = false;

            for (int i = 2; i < input.Length; i++)
            {
                if(input[i] == "") mapped = false;

                if(!input[i].Contains(':') && input[i] != "" && !mapped)
                {
                    var inputLine = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var destination = Convert.ToInt64(inputLine[0]);
                    var source = Convert.ToInt64(inputLine[1]);
                    var range = Convert.ToInt64(inputLine[2]);

                    if(SeedInRange(s, source, range))
                    {
                        s = destination + (s - source);
                        mapped = true;
                    }

                    Console.WriteLine($"destination: {destination} source: {source} range: {range}");
                }
                Console.WriteLine($"seed: {seed} - {s}");
            }

            seedlist.Add(Convert.ToInt64(seed), s);

        }

        foreach (var seed in seedlist)
        {
            Console.WriteLine($"seed: {seed.Key} - {seed.Value}");
        }

        Console.WriteLine($"min is: {seedlist.Min(s => s.Value)}");
        
        Console.WriteLine($"still not the right result");
    }

    public void SolvePart2()
    {
        Console.WriteLine("under developement");
    }

    public bool SeedInRange(Int64 seed, Int64 source, Int64 range)
    {
        if(seed >= source && seed < (source + range))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
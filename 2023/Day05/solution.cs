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
        var input = sb.getInputLines(@"2023/Day05/testone").ToArray();
        //var input = sb.getInputLines(@"2023/Day05/input").ToArray();

        var firstLine = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var seeds = firstLine.Where(seed => seed.Any(char.IsDigit));
        foreach(var seed in seeds)
        {
            Console.WriteLine(seed);
        }

        //input.Remove(input[0]);

        // List<string> maps = new();

        // foreach (var line in input)
        // {
        //     if(line.Length > 0 && !line.Contains(':'))
        //     {
        //         maps.Add(line);
        //     }
        // }
        
        //inital map
        int[] test = new int[100];
        for (int i = 0; i < test.Length; i++)
        {
            test[i] = i;
        }

        int[] testmap = new int[100];

        for (int a = 2; a < input.Length; a++)
        {
            //Console.WriteLine(input[a].Length);
            if(input[a].Contains(':'))
            {
                Console.WriteLine(input[a]);
                Array.Copy(test, testmap, test.Length);
            }
            else if (input[a].Length == 0)
            {
                Console.WriteLine(input[a]);
                //Array.Copy(testmap, test, test.Length);

                for (int i = 0; i < 100; i++)
                {
                    //Console.WriteLine($"{i}: test {test[i]} - testmap {testmap[i]}");
                    test[i] = testmap[i];
                    testmap[i] = 1;
                    //Console.WriteLine($"{i}: test {test[i]} - testmap {testmap[i]}");
                    //Console.WriteLine($"------------------");
                }
            }
            else
            {
                Console.WriteLine(input[a]);
                
                var item = input[a];
                var destinationRangeStart = Convert.ToInt64(item.Split(' ')[0]);
                var sourceRange = Convert.ToInt64(item.Split(' ')[1]);
                var rangeLength = Convert.ToInt64(item.Split(' ')[2]);

                for (int i = 0; i < rangeLength; i++)
                {
                    testmap[sourceRange + i] = test[destinationRangeStart + i];
                }
            }
        }
        
        //foreach (var item in maps)
        // for(int m = 0; m < maps.Count; m++)
        // {
        //     var item = maps[m];
        //     var destinationRangeStart = Convert.ToInt64(item.Split(' ')[0]);
        //     var sourceRange = Convert.ToInt64(item.Split(' ')[1]);
        //     var rangeLength = Convert.ToInt64(item.Split(' ')[2]);

        //     for (int i = 0; i < rangeLength; i++)
        //     {
        //         testmap[sourceRange + i] = test[destinationRangeStart + i];
        //     }
        // }

        //Console.WriteLine(seeds);
        // for (int i = 0; i < 100; i++)
        // {
        //     Console.WriteLine($"test{i}: {testmap[i]}");
        // }
        Console.WriteLine($"testmap");
        Console.WriteLine($"79: {testmap[79]}");
        Console.WriteLine($"14: {testmap[14]}");
        Console.WriteLine($"55: {testmap[55]}");
        Console.WriteLine($"13: {testmap[13]}");

        
        Console.WriteLine($"still not the right result");
    }

    public void SolvePart2()
    {
        Console.WriteLine("under developement");
    }
}
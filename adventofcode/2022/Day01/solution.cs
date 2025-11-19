using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode;

namespace aoc2022;
public class solutionDay01 : ISolver
{
    public void Solve()
    {
        Console.WriteLine("solve test");
    }

    List<int> snackCarries = new();

    public void SolvePart1()
    {
        Console.WriteLine("try to solve first part");

        solutionBase sb = new();
        var input = sb.getInputLines(@"2022\Day01\input");

        var most = 0;
        var actual = 0;
        List<int> mosts = new();

        foreach (var item in input)
        {
            //Console.WriteLine($"{item}");
            if(item != "")
            {
                actual += Convert.ToInt32(item);
            }
            else
            {
                if(actual > most)
                {
                    most = actual;
                }
                mosts.Add(actual);
                actual = 0;
            }
        }
        Console.WriteLine($"Mosts.Max: {mosts.Max()} - Mosts.Count: {mosts.Count}");
        Console.WriteLine($"Most: {most}");

        snackCarries.AddRange(mosts);
    }

    public void SolvePart2()
    {
        Console.WriteLine("try to solve second part");
        SolvePart1();
        Console.WriteLine($"snackCarries.Count: {snackCarries.Count}");

        List<int> topThree = snackCarries.OrderByDescending(x => x).Take(3).ToList();

        Console.WriteLine($"top three elves carry {topThree.Sum()} calories");
    }


}


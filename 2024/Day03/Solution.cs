using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace adventofcode.Year2024.Day03;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        //var inputFilePath = GetInputFilePath("test");
        var inputFilePath = GetInputFilePath();

        string[] lines = File.ReadAllLines(inputFilePath);

        string regexpattern = @"mul\(\d{1,3},\d{1,3}\)";

        List<string> allmatches = new();

        long totalSum = 0;
        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, regexpattern);

            foreach(Match match in matches)
            {
                allmatches.Add(match.Value);

                string item = match.ToString().Replace("mul(", "").Replace(")", "");

                long x = long.Parse(item.Split(',')[0]);
                long y = long.Parse(item.Split(',')[1]);

                totalSum += x * y;
            }
        }

        Console.WriteLine($"allmatches.count = {allmatches.Count}");
        Console.WriteLine($"total sum is: {totalSum}");
    
    }

    public void SolvePart2()
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        //var inputFilePath = GetInputFilePath("testtwo");
        var inputFilePath = GetInputFilePath();

        string[] lines = File.ReadAllLines(inputFilePath);

        string regexpattern =   @"(?:\w*mul\(\d{1,3},\d{1,3}\))|(?:\b(?:un)?do\(\))|(?:\bdon't\(\))";
        
        List<string> allmatches = new();

        long totalSum = 0;
        bool doit = true;
        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, regexpattern);

            foreach(Match match in matches)
            {
                allmatches.Add(match.Value);

                if(match.ToString().Contains("mul"))
                {
                    if (doit)
                    {
                        string temp = match.Value;

                        if (temp.Contains("mul"))
                        {
                            // Normalize anything ending in "mul" (e.g., xmul, _mul) to "mul"
                            temp = Regex.Replace(temp, @"\w*mul", "mul");
                        }

                        string item = temp.Replace("mul(", "").Replace(")", "");

                        long x = long.Parse(item.Split(',')[0]);
                        long y = long.Parse(item.Split(',')[1]);

                        totalSum += x * y;
                    }
                }
                else
                {
                    if (match.ToString().ToLower().Contains("don't"))
                    {
                        doit = false;
                    }
                    else
                    {
                        doit = true;
                    }
                }

            }
        }

        Console.WriteLine($"total sum is: {totalSum}");    
    }
}

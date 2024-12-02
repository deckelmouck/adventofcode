using System;
using System.IO;

namespace adventofcode.Year2024.Day02;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        //var inputFilePath = GetInputFilePath("test");
        var inputFilePath = GetInputFilePath();
        Console.WriteLine(inputFilePath);

        // Read input file
        string[] lines = File.ReadAllLines(inputFilePath);

        int safeReports = 0;

        foreach (string report in lines)
        {
            string[] levels = report.Split(' ');
            long previousLevel = Convert.ToInt64(levels[0]);
            long nextLevel = Convert.ToInt64(levels[1]);
            bool wayUp = false;
            bool safe = true;

            if(previousLevel < nextLevel)
                wayUp = true;

            // if(previousLevel == nextLevel)
            //     break;

            for (int i = 1; i < levels.Length; i++)
            {
                long actualLevel = Convert.ToInt64(levels[i]);
                long diff = 0;

                if (previousLevel < actualLevel && wayUp)
                {
                    diff = actualLevel - previousLevel;
                    if (diff == 0 || diff > 3)
                    {
                        safe = false;
                        break;
                    }
                }
                else if (previousLevel > actualLevel && !wayUp)
                {
                    diff = previousLevel - actualLevel;
                    if (diff == 0 || diff > 3)
                    {
                        safe = false;
                        break;
                    }
                }
                else
                {
                    safe = false;
                    break;
                }
                previousLevel = actualLevel;
            }

            if(safe)
            {
                safeReports++;
            }
        }

        Console.WriteLine($"Count of safe reports: {safeReports}");
    }

    public void SolvePart2()
    {
        Console.WriteLine("Part 2");
    }
}

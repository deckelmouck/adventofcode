using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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
        //var inputFilePath = GetInputFilePath("test");
        var inputFilePath = GetInputFilePath();
        Console.WriteLine(inputFilePath);

        // Read input file
        string[] lines = File.ReadAllLines(inputFilePath);

        int safeReports = 0;

        List<string> unsafeReports = new();

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
            else
            {
                unsafeReports.Add(report);
            }
        }

        Console.WriteLine($"part 2: first found safe reports {safeReports}");
        Console.WriteLine($"part 2: found unsafe reports {unsafeReports.Count}");

        foreach (string item in unsafeReports)
        {
            string[] originalLevels = item.Split(' ');

            int skipIndex = 0;

            for (int i = 0; i < originalLevels.Length; i++)
            {
                skipIndex = i;

                string[] deleteOneLevel = new string[originalLevels.Length - 1];
                int newIndex = 0;

                for (int d = 0; d < originalLevels.Length; d++)
                {
                    if (d != skipIndex)
                    {
                        deleteOneLevel[newIndex] = originalLevels[d];
                        newIndex++;
                    }
                }

                //old part repeated for finding more safe reports
                //string[] levels = report.Split(' ');
                long previousLevel = Convert.ToInt64(deleteOneLevel[0]);
                long nextLevel = Convert.ToInt64(deleteOneLevel[1]);
                bool wayUp = false;
                bool safe = true;

                if(previousLevel < nextLevel)
                    wayUp = true;

                // if(previousLevel == nextLevel)
                //     break;

                for (int f = 1; f < deleteOneLevel.Length; f++)
                {
                    long actualLevel = Convert.ToInt64(deleteOneLevel[f]);
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
                    break;
                }

                // end of old part
            }



        }


        Console.WriteLine($"Part 2: Count of complete safe reports: {safeReports}");
    }
}

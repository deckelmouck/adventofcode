using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace adventofcode.Year2024.Day05;
public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        //var filePath = GetInputFilePath("test");
        var filePath = GetInputFilePath();

        //string[] lines = File.ReadAllLines(inputFilePath);
        // Add your Part 1 solution logic here

        // Lists to store the page rules and the lines
        List<(int first, int second)> pageRules = new List<(int, int)>();
        List<List<int>> lines = new List<List<int>>();

        // Read the file and separate the rules and lines
        ReadFile(filePath, pageRules, lines);

        // Initialize sum of mid-values
        int sumOfMidValues = 0;

        foreach (var line in lines)
        {
            bool isValid = true;

            foreach (var rule in pageRules)
            {
                int indexFirst = line.IndexOf(rule.first);
                int indexSecond = line.IndexOf(rule.second);

                // If both elements exist and the first isn't before the second, the line is invalid
                if (indexFirst != -1 && indexSecond != -1 && indexFirst >= indexSecond)
                {
                    isValid = false;
                    break;
                }
            }

            // if (isValid)
            // {
            //     matchingLines++;
            // }

            if (isValid)
            {
                // Calculate the mid-value of the line
                int midValue = CalculateMidValue(line);
                sumOfMidValues += midValue;
            }
        }

        //Console.WriteLine($"Number of matching lines: {matchingLines}");
        Console.WriteLine($"Sum of mid-values of matching lines: {sumOfMidValues}");
    }

    // Method to calculate the mid-value of a list
    static int CalculateMidValue(List<int> line)
    {
        int n = line.Count;
        if (n % 2 == 1) // Odd number of elements
        {
            return line[n / 2];
        }
        else // Even number of elements
        {
            return (line[n / 2 - 1] + line[n / 2]) / 2;
        }
    }

    static void ReadFile(string filePath, List<(int first, int second)> pageRules, List<List<int>> lines)
    {
        string[] fileContent = File.ReadAllLines(filePath);
        bool readingRules = true;

        foreach (var line in fileContent)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                readingRules = false;
                continue;
            }

            if (readingRules)
            {
                // Split rule by '|', parse as integers, and add to pageRules list
                var parts = line.Split('|').Select(int.Parse).ToArray();
                pageRules.Add((parts[0], parts[1]));
            }
            else
            {
                // Split line by ',' and parse as a list of integers
                var numbers = line.Split(',').Select(int.Parse).ToList();
                lines.Add(numbers);
            }
        }
    }

    public void SolvePart2()
    {
        Console.WriteLine("not implemented");
    }
}

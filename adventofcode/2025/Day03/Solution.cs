
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode.Year2025.Day03;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        string file = "input";
        // #if DEBUG
        // file = "test";
        // #endif

        int sum = 0;

        var inputFilePath = GetInputFilePath(file);
        List<string> input = File.ReadAllLines(inputFilePath).ToList();

        foreach (var bank in input)
        {
            char maxDigit = '0';
            int maxIndex = -1;

            for (int i = 0; i < bank.Length-1; i++)
            {
                if (bank[i] > maxDigit)
                {
                    maxDigit = bank[i];
                    maxIndex = i;
                }
            }

            char maxDigitTwo = '0';
            int maxIndexTwo = -1;

            for (int i = maxIndex; i < bank.Length; i++)
            {
                if (bank[i] > maxDigitTwo && i != maxIndex)
                {
                    maxDigitTwo = bank[i];
                    maxIndexTwo = i;
                }
            }

            int joltage = 0;
            if (maxIndex < maxIndexTwo)
            {
                joltage = int.Parse($"{maxDigit}{maxDigitTwo}");
            }
            else
            {
                joltage = int.Parse($"{maxDigitTwo}{maxDigit}");
            }

            sum += joltage;
        }

        Console.WriteLine($"sum of joltage: {sum}");
    }

    public void SolvePart2()
    {
        throw new System.NotImplementedException();
    }
}
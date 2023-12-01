using System;
using System.Text;
using System.Text.RegularExpressions;
using adventofcode;

namespace aoc2023;

class solutionDay01 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("part 1");

        solutionBase sb = new();
        var input = sb.getInputLines(@"2023/Day01/input");
        //var input = sb.getInputLines(@"2023/Day01/test");

        int sumCalibrationValues = 0;

        foreach (var item in input)
        {
            

            Console.WriteLine(item);
            StringBuilder result = new StringBuilder();
            foreach (char c in item)
            {
                if (char.IsDigit(c))
                {
                    result.Append(c);
                }
            }

            int calibrationValue = 0;

            if (result.Length == 1)
            {
                result.Append(result);
                calibrationValue = Convert.ToInt32(result.ToString());
            }
            else if (result.Length > 2)
            {
                var val = $"{result[0].ToString()}{result[^1].ToString()}";
                calibrationValue = Convert.ToInt32(val); 
            }
            else
            {
                calibrationValue = Convert.ToInt32(result.ToString());
            }

            sumCalibrationValues += calibrationValue;


            Console.WriteLine(calibrationValue);
        }
        Console.WriteLine(sumCalibrationValues);
    }

    public void SolvePart2()
    {
        Console.WriteLine("part 2");
    }
}

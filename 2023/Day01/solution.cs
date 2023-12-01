using System;
using System.Linq;
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


            // Console.WriteLine(item);
            // StringBuilder result = new StringBuilder();
            // foreach (char c in item)
            // {
            //     if (char.IsDigit(c))
            //     {
            //         result.Append(c);
            //     }
            // }

            // int calibrationValue = 0;

            // if (result.Length == 1)
            // {
            //     result.Append(result);
            //     calibrationValue = Convert.ToInt32(result.ToString());
            // }
            // else if (result.Length > 2)
            // {
            //     var val = $"{result[0].ToString()}{result[^1].ToString()}";
            //     calibrationValue = Convert.ToInt32(val); 
            // }
            // else
            // {
            //     calibrationValue = Convert.ToInt32(result.ToString());
            // }

            int calibrationValue = CalibrationValue(item);

            sumCalibrationValues += calibrationValue;


            Console.WriteLine(calibrationValue);
        }
        Console.WriteLine(sumCalibrationValues);
    }

    public void SolvePart2()
    {
        solutionBase sb = new();
        var input = sb.getInputLines(@"2023/Day01/input");
        //var input = sb.getInputLines(@"2023/Day01/testparttwo");

        int sumCalibrationValues = 0;

        string[] words = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

        foreach (var item in input)
        {
            string corrected = item;
            int actualIteration = 0;
            while (corrected.Length > actualIteration)
            {
                int lengthBefore = corrected.Length;
                corrected = Corrected(corrected, actualIteration);
                if(lengthBefore == corrected.Length)
                {
                    actualIteration++;
                }
                else
                {
                    actualIteration = 0;
                }
            }

            Console.WriteLine(corrected);

            int calibrationValue = CalibrationValue(corrected);

            sumCalibrationValues += calibrationValue;


            Console.WriteLine(calibrationValue);
        }
        Console.WriteLine(sumCalibrationValues);
    }

    int CalibrationValue(string item)
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
        return calibrationValue;
    }

    string Corrected(string item, int startingpoint)
    {
        string[] words = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        string check = "";
        
        if(item.Length >= startingpoint + 3)
        {
            check = item.Substring(startingpoint, 3);

            if (words.Contains(check))
            {
                switch (check)
                {
                    case "one":
                    item = item.Replace(check, "1");
                    break;
                    case "two":
                    item = item.Replace(check, "2");
                    break;
                    case "six":
                    item = item.Replace(check, "6");
                    break;
                    default:
                    break;
                }
                return item;
            }
        }

        if(item.Length >= startingpoint + 4)
        {
            check = item.Substring(startingpoint, 4);

            if (words.Contains(check))
            {
                switch (check)
                {
                    case "four":
                    item = item.Replace(check, "4");
                    break;
                    case "five":
                    item = item.Replace(check, "5");
                    break;
                    case "nine":
                    item = item.Replace(check, "9");
                    break;
                    default:
                    break;
                }
                return item;
            }
        }

        if(item.Length >= startingpoint + 5)
        {
            check = item.Substring(startingpoint, 5);

            if (words.Contains(check))
            {
                switch (check)
                {
                    case "three":
                    item = item.Replace(check, "3");
                    break;
                    case "seven":
                    item = item.Replace(check, "7");
                    break;
                    case "eight":
                    item = item.Replace(check, "8");
                    break;
                    default:
                    break;
                }
                return item;
            }
        }

        return item;
    }

}

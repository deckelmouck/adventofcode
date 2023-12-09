using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode;

namespace aoc2023;

class solutionDay09 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine($"this is part 1");

        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day09/test").ToArray(); 
        var input = sb.getInputLines(@"2023/Day09/input").ToArray(); 

        long solution = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var inputLine = input[i] + " 0";
            //Console.WriteLine(inputLine);

            var line = inputLine.Split(" ");
            //Console.WriteLine(line.Length);

            //hint found - next value of last values each sequence
            List<long> lastValues = new List<long>();

            //initial sequence length
            int sequenceLength = line.Length - 1;

            //for temporary storage of last line
            long[] lastLine = new long[sequenceLength];

            //init with starting sequence
            lastLine = line.Select(x => Convert.ToInt64(x)).ToArray();
            
            //save last value for later
            //lastValues.Add(lastLine[^1]);

            ArrayOutput(lastLine);
            
            for (int l = 0; l <= sequenceLength; l++)
            {
                //reduce sequence length for next iteration
                //sequenceLength--;

                long[] newline = new long[sequenceLength - l];

                //create new sequence
                for (int j = 0; j < newline.Length; j++)
                {
                    long left = Convert.ToInt64(lastLine[j]);
                    long right = Convert.ToInt64(lastLine[j + 1]);

                    long newValue = right - left;

                    newline[j] = newValue;
                }

                //save last value for later
                //lastValues.Add(newline[^1]);

                ArrayOutput(newline);

                

                //put new sequence in temp storage
                lastLine = newline;

                //check if all values are 0
                //var sum = newline.Sum();

                //check if all values are 0
                // if(ArrayFullOfZeros(newline))
                // {
                //     //Console.WriteLine($"line {i} is a solution");
                //     break;
                // }
                if(newline.Length == 1)
                {
                    lastValues.Add(newline[0] * -1);
                    break;
                }
            }
            //lastValues.Add(lastLine[0] * -1);           
            Console.WriteLine($"{lastValues.Sum()}");
            solution += lastValues.Sum();
        }
        Console.WriteLine($"solution is {solution}");
    }

    public void SolvePart2()
    {
        Console.WriteLine($"this is part 2");
    }

    public void ArrayOutput(long[] array)
    {
        foreach (var item in array)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    public bool ArrayFullOfZeros(long[] array)
    {
        foreach (var item in array)
        {
            if(item != 0)
            {
                return false;
            }
        }
        return true;
    }
}
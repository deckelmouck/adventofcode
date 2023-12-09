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
            var line = input[i].Split(" ");
            //Console.WriteLine(line.Length);

            //hint found - next value of last values each sequence
            List<long> lastValues = new List<long>();
            
            //initial sequence length
            int sequenceLength = line.Length;

            //for temporary storage of last line
            long[] lastLine = new long[sequenceLength];

            //init with starting sequence
            lastLine = line.Select(x => Convert.ToInt64(x)).ToArray();

            //save last value for later
            lastValues.Add(lastLine[^1]);

            //ArrayOutput(lastLine);
            
            for (int l = 0; l < sequenceLength; l++)
            {
                long[] newline = new long[sequenceLength - 1];

                //create new sequence
                for (int j = 0; j < newline.Length; j++)
                {
                    long left = Convert.ToInt64(lastLine[j]);
                    long right = Convert.ToInt64(lastLine[j + 1]);

                    long newValue = right - left;

                    // if(left > right)
                    // {
                    //     newValue = left - right;
                    // }
                    // else
                    // {
                    //     newValue = right - left;
                    // }

                    newline[j] = newValue;
                }

                //save last value for later
                lastValues.Add(newline[^1]);

                //ArrayOutput(newline);

                //reduce sequence length for next iteration
                sequenceLength--;

                //put new sequence in temp storage
                lastLine = newline;

                //check if all values are 0
                var sum = newline.Sum();
                if(sum == 0)
                {
                    //Console.WriteLine($"line {i} is a solution");
                    break;
                }
            }
                       
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
}
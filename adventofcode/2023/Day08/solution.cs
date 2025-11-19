using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode;

namespace aoc2023;

class solutionDay08 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine($"this is part 1");

        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day08/testtwo").ToArray();
        var input = sb.getInputLines(@"2023/Day08/input").ToArray();

        Console.WriteLine(input.Length);
        Console.WriteLine(input[0].Length);

        char[] directions = new char[input[0].Length];
        directions = input[0].ToArray();

        Dictionary<string, Node> nodes = new();

        for (int i = 2; i < input.Length; i++)
        {
            var item = input[i];
            Console.WriteLine($"this is '{item}'");

            var nodeName = item.Split('=', StringSplitOptions.TrimEntries)[0];
            var nodeValue = item.Split('=', StringSplitOptions.TrimEntries)[1].Replace("(", "").Replace(")", "");;
            
            var leftpart = nodeValue.Split(',', StringSplitOptions.TrimEntries)[0];
            var rightpart = nodeValue.Split(',', StringSplitOptions.TrimEntries)[1];
            
            Node node = new(leftpart, rightpart);

            nodes.Add(nodeName, node);
        }

        string lookupelement = "AAA";
        string target = "ZZZ";
        int count = 0;

        while (lookupelement != target)
        {
            int i = count % input[0].Length;

            Console.WriteLine($"step {count} - i {i}");

            if(directions[i] == 'L')
            {
                lookupelement = nodes[lookupelement].LKey;
            }
            else if(directions[i] == 'R')
            {
                lookupelement = nodes[lookupelement].RKey;
            }

            count++;
        }

        Console.WriteLine($"found {lookupelement} after {count} steps");
        
    }

    public void SolvePart2()
    {
        Console.WriteLine($"part two");

        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day08/testghosts").ToArray();
        var input = sb.getInputLines(@"2023/Day08/input").ToArray();

        Console.WriteLine(input.Length);
        Console.WriteLine(input[0].Length);

        char[] directions = new char[input[0].Length];
        directions = input[0].ToArray();

        Dictionary<string, Node> nodes = new();

        for (int i = 2; i < input.Length; i++)
        {
            var item = input[i];
            //Console.WriteLine($"this is '{item}'");

            var nodeName = item.Split('=', StringSplitOptions.TrimEntries)[0];
            var nodeValue = item.Split('=', StringSplitOptions.TrimEntries)[1].Replace("(", "").Replace(")", "");;
            
            var leftpart = nodeValue.Split(',', StringSplitOptions.TrimEntries)[0];
            var rightpart = nodeValue.Split(',', StringSplitOptions.TrimEntries)[1];
            
            Node node = new(leftpart, rightpart);

            nodes.Add(nodeName, node);
        }

        foreach (var item in nodes)
        {
            Console.WriteLine($"{item.Key} - {item.Value.LKey} - {item.Value.RKey}");
        }

        List<string> lookupelements = nodes.Where(x => x.Key.EndsWith("A")).Select(x => x.Key).ToList();
        
        Console.WriteLine($"found {lookupelements.Count} starting points");
        //int count = 0;

        foreach (var item in lookupelements)
        {
            Console.WriteLine($"starting point {item}");
        }

        List<long> counts = new();
        
        foreach (var item in lookupelements)
        {
            long steps = Steps2Z(item);
            counts.Add(steps);
            Console.WriteLine($"steps to Z {steps}");
        }

        // calculate the least common multiple of all counts
        long lcm = CalculateLCM(counts.ToArray());

        Console.WriteLine($"LCM of the array is: {lcm}");

        // this is too slow..
        // while (lookupelements.Count > lookupelements.Count(x => x.EndsWith("Z")))
        // {
        //     int i = count % input[0].Length;

        //     //Console.WriteLine($"step {count} - i {i} - direction {directions[i]}");

        //     if(directions[i] == 'L')
        //     {
        //         for (int j = 0; j < lookupelements.Count; j++)
        //         {
        //             lookupelements[j] = nodes[lookupelements[j]].LKey;
        //         }
        //         //lookupelement = nodes[lookupelement].LKey;
        //     }
        //     else if(directions[i] == 'R')
        //     {
        //         for (int j = 0; j < lookupelements.Count; j++)
        //         {
        //             lookupelements[j] = nodes[lookupelements[j]].RKey;
        //         }
        //         //lookupelement = nodes[lookupelement].RKey;
        //     }

        //     // foreach (var item in lookupelements)
        //     // {
        //     //     Console.WriteLine($"actual point {item}");
        //     // }

        //     count++;
        //     //if (count > 20) break;
        //     //if(count % 1000000 == 0) 
        //     //Console.WriteLine($"step {count} - {lookupelements.Count} - {lookupelements.Count(x => x.EndsWith("Z"))}");
        // }

        //Console.WriteLine($"found {lookupelements.Count} with ending Z after {count} steps");

        int Steps2Z(string lookupelement)
        {
            //string lookupelement = input; //"AAA";
            //string target = "ZZZ";
            int count = 0;

            while (!lookupelement.EndsWith("Z"))
            {
                int i = count % input[0].Length;

                //Console.WriteLine($"step {count} - i {i}");

                if(directions[i] == 'L')
                {
                    lookupelement = nodes[lookupelement].LKey;
                }
                else if(directions[i] == 'R')
                {
                    lookupelement = nodes[lookupelement].RKey;
                }

                count++;
            } 

            return count;
        }
            // Function to calculate the GCD using Euclidean algorithm
        static long CalculateGCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Function to calculate the LCM of an array of integers
        static long CalculateLCM(long[] numbers)
        {
            // Validate that the array is not empty
            if (numbers.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            long lcm = numbers[0];

            for (long i = 1; i < numbers.Length; i++)
            {
                // LCM(lcm, numbers[i]) = (lcm * numbers[i]) / GCD(lcm, numbers[i])
                lcm = (lcm * numbers[i]) / CalculateGCD(lcm, numbers[i]);
            }

            return lcm;
        }
    }

    class Node(string lKey, string rKey)
    {
        public string LKey { get; } = lKey;
        public string RKey { get; } = rKey;
    }

    
}
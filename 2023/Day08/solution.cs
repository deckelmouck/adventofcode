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
        //var input = sb.getInputLines(@"2023/Day08/testwo").ToArray();
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
        Console.WriteLine($"under development");
    }

    class Node(string lKey, string rKey)
    {
        public string LKey { get; } = lKey;
        public string RKey { get; } = rKey;
    }
}
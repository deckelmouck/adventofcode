using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using adventofcode;

namespace aoc2023;

public class solutionDay12 : ISolver
{
    public static int DEBUG_LEVEL { get; set; }

    public void SolvePart1()
    {
        Console.WriteLine("Day 12, Part 1");

        solutionBase solutionBase = new solutionBase();
        //var input = solutionBase.getInputLines($"2023/Day12/test");
        //var input = solutionBase.getInputLines($"2023/Day12/testsingle");
        var input = solutionBase.getInputLines($"2023/Day12/input");

        long sum = 0;

        foreach (var line in input)
        {
            Debug.WriteLine(line);
            //Console.WriteLine(line);
        }

        DEBUG_LEVEL = 0;

        foreach (var line in input)
        {
            string allowedCombination = line.Split(' ')[0];
            int[] rule = line.Split(' ')[1].Split(',', StringSplitOptions.TrimEntries).Select(x => int.Parse(x)).ToArray();

            var possibleStrings = GeneratePossibleStrings(allowedCombination);

            Console.WriteLine($"Allowed combination: {possibleStrings.Count}");

            var result = Nonosolve(allowedCombination, rule.ToList());
            sum += result;
            // foreach (var possibleString in possibleStrings)
            // {
            //     Console.WriteLine(possibleString);
            // }
            
            // Console.WriteLine("Matching Strings:");
            // foreach (string possibleString in possibleStrings)
            // {
            //     if (MatchesRule(possibleString, rule))
            //     {
            //         Console.WriteLine(possibleString);
            //     }
            // }
            // var t = MatchesRule(".###.##.#...", rule);
            // var r = MatchesRule(".###.##..#..", rule);
            // var s = MatchesRule(".###...##..#", rule);
        }

        Console.WriteLine($"Sum: {sum}");
    }

    public void SolvePart2()
    {
        Console.WriteLine("Day 12, Part 2");
    }

    public int FindPermutations(string input)
    {
        var text = input.Split(' ')[0].ToArray();
        var arrangements = input.Split(' ')[1].Split(',', StringSplitOptions.TrimEntries).ToArray();

        var count = CountPermutations(input.Split(' ')[0], arrangements.Select(x => int.Parse(x)).ToArray());

        return count;
    }

    private int CountPermutations(string v, int[] ints)
    {
        Console.WriteLine($"CountPermutations({v}, {string.Join(',', ints)})");
        return 0;
    }


    ///// this musst be analysed
    private static long Nonosolve(string line, List<int> blocks, int nLevel = 1)
        {
            if (DEBUG_LEVEL >= nLevel) Console.WriteLine($"{new string(' ', 2 * nLevel)}Nonosolve({line}, {string.Join(',', blocks)})");

            line = line.Trim('.');

            while (line.Contains(".."))
                line = line.Replace("..", ".");

            //Strip from the start
            while (blocks.Count > 0 && line.Length > 0)
            {
                //Replace the start with the first block when it starts with a #.
                if (line.Length > 0 && line[0] == '#')
                {
                    if (line[..blocks[0]].Contains('.') || (line.Length > blocks[0] && line[blocks[0]] == '#')) //we can never replace a . with a #
                        return 0;
                    else if (blocks[0] == line.Length)
                        line = "";
                    else
                        line = line[(blocks[0] + 1)..].TrimStart('.');

                    blocks.RemoveAt(0);
                    continue;
                }

                //Remove the start if the first ??? sequence cannot fit because of working days.
                if (line.Contains('.') && line.IndexOf('.') < blocks[0])
                {
                    if (line[..line.IndexOf('.')].Contains('#')) // we can never replace a # with a .
                        return 0;

                    line = line[line.IndexOf('.')..].TrimStart('.');
                    continue;
                }

                //Remove the first character if the first block would be followed by a broken day (#)
                if (line.Length > blocks[0] && line[blocks[0]] == '#')
                {
                    line = line[1..].TrimStart('.');
                    continue;
                }

                //Remove the start, and the first block, if it fits exactly and is forced to be there.
                if (line.Length > blocks[0] && line[..blocks[0]].Contains('#') && line[blocks[0]] == '.')
                {
                    line = line[blocks[0]..].TrimStart('.');
                    blocks.RemoveAt(0);
                    continue;
                }

                break;
            }

            //Strip from the end
            while (blocks.Count > 0 && line.Length > 0)
            {

                //Replace the end with the last block when it ends with a #.
                if (line.Length > 0 && line[^1] == '#')
                {
                    if (line[^blocks[^1]..].Contains('.') || (line.Length > blocks[^1] && line[^(blocks[^1] + 1)] == '#')) //We can't remove a #, or include a .
                        return 0;
                    else if (blocks[^1] == line.Length)
                        line = "";
                    else
                        line = line[..^(blocks[^1] + 1)].TrimEnd('.');

                    blocks.RemoveAt(blocks.Count - 1);
                    continue;
                }

                //Remove the end if the last ??? sequence cannot fit because of working days.
                if (line.Contains('.') && line.LastIndexOf('.') >= line.Length - blocks[^1])
                {
                    
                    if (line[line.LastIndexOf('.')..].Contains('#')) // we can never replace a # with a .
                        return 0;

                    line = line[..line.LastIndexOf('.')].TrimEnd('.');
                    continue;
                }

                //Remove the last character if the last block would be followed by a broken day (#)
                if (line.Length > blocks[^1] && line[^(blocks[^1] + 1)] == '#')
                {
                    line = line[..^1].TrimEnd('.');
                    continue;
                }

                //Remove the end, and the last block, if it fits exactly and is forced to be there.
                if (line.Length > blocks[^1] && line[^blocks[^1]..].Contains('#') && line[^(blocks[^1] + 1)] == '.')
                {
                    line = line[..^(blocks[^1] + 1)].TrimEnd('.');
                    blocks.RemoveAt(blocks.Count - 1);
                    continue;
                }

                break;
            }

            int nLeeway = line.Length - blocks.Sum(x => x+1) + 1;

            if (nLeeway < 0)
            {
                return 0;
            }

            //Shortcut : Based on total length and holes and stuff, it's nonogram
            if (nLeeway == 0 || blocks.Count == 0)
            {
                //build the minimal string to represent the blocks, with an extra dot since I can't be arsed.
                string comparison = "";
                foreach(var testBlock in blocks)
                {
                    comparison += new string('#', testBlock) + ".";
                }
                comparison = (comparison + new string('.', line.Length))[..line.Length];

                //Compare if there are ./# overlaps
                for (int i=0; i<line.Length; i++)
                {
                    if ((line[i]=='.' && comparison[i]=='#') || (line[i] == '#' && comparison[i] == '.'))
                    {
                        return 0;
                    }
                }
                
                return 1;
            }

            //Only thing left is to bruteforce the remaining ones I guess... or be wise about it, but that's out of reach.
            long nSum = 0;
            if (blocks.Count > 1)
            {
                List<int> newBlocks = blocks.ToList();
                newBlocks.RemoveAt(0);
                int newBlocksLength = newBlocks.Sum(x => x+1);

                for(int i = 0; i <= line.Length - newBlocksLength - blocks[0]; i++)
                {                            
                    if (!line[i..(i + blocks[0])].Contains('.') && line[i + blocks[0]] != '#')
                    {
                        var nRes = Nonosolve(line[(i + blocks[0] + 1)..], newBlocks.ToList(), nLevel + 1);
                        nSum += nRes;
                    }

                    if (line[i] == '#') //We can't ditch a #
                        break;
                }
            }
            else
            {
                for (int i = 0; i <= line.Length - blocks[0]; i++)
                {
                    if (line[..i].Contains('#'))// We've ditched a #, we can stop; 
                        break;

                    if (line[i..(i + blocks[0])].Contains('.')) // we're including a ., we can skip
                        continue;
                    
                    if (line[(i + blocks[0])..].Contains('#')) // we haven't reached the first #
                        continue;

                    nSum ++;
                }
            }

            if (DEBUG_LEVEL >= nLevel) Console.WriteLine($"{new string(' ', 2*nLevel)}{nSum} = {line} {String.Join(",", blocks)}");
            return nSum;
        }


    ////////////////////////////////////////////////////////////////////////////
    static bool MatchesRule(string str, int[] rule)
    {
        int index = 0;

        foreach (int count in rule)
        {
            // Check if the current substring matches the rule
            string substring = str.Substring(index, count);

            if (!IsBlockValid(substring, count))
            {
                return false;
            }

            // Move to the next block
            index += count;

            // If there are more characters in the string, ensure they are '.'
            if (index < str.Length && str[index] != '.')
            {
                return false;
            }

            // Move past the '.' character
            index++;
        }

        return true;
    }

    static bool IsBlockValid(string block, int count)
    {
        // Check if the block contains only '#' characters
        for (int i = 0; i < count; i++)
        {
            if (i >= block.Length || block[i] != '#')
            {
                return false;
            }
        }

        return true;
    }

    static List<string> GeneratePossibleStrings(string targetString)
    {
        List<string> possibleStrings = new List<string>();
        GeneratePossibleStringsRecursive(targetString, 0, new StringBuilder(targetString.Length), possibleStrings);
        return possibleStrings;
    }

    static void GeneratePossibleStringsRecursive(string targetString, int index, StringBuilder currentString, List<string> possibleStrings)
    {
        if (index == targetString.Length)
        {
            // Base case: If the current string is complete, add it to the list
            possibleStrings.Add(currentString.ToString());
            return;
        }

        char currentChar = targetString[index];

        if (currentChar == '?')
        {
            // If the current character is a wildcard, branch for both '#' and '.'
            currentString.Append('#');
            GeneratePossibleStringsRecursive(targetString, index + 1, currentString, possibleStrings);
            currentString.Length--;

            currentString.Append('.');
            GeneratePossibleStringsRecursive(targetString, index + 1, currentString, possibleStrings);
            currentString.Length--;
        }
        else
        {
            // If the current character is not a wildcard, use it as is
            currentString.Append(currentChar);
            GeneratePossibleStringsRecursive(targetString, index + 1, currentString, possibleStrings);
            currentString.Length--;
        }
    }

    ////////////////////////////////////////////////////////////////////////////

    // static string GenerateString(int length, int[] hashCounts)
    // {
    //     StringBuilder resultBuilder = new StringBuilder(length);

    //     foreach (int count in hashCounts)
    //     {
    //         // Add '#' characters
    //         resultBuilder.Append('#', count);

    //         // If there is more to the string, add '.' characters
    //         if (resultBuilder.Length < length)
    //         {
    //             int dotCount = Math.Min(length - resultBuilder.Length, count - 1);
    //             resultBuilder.Append('.', dotCount);
    //         }
    //     }

    //     // If the generated string is shorter than the specified length, add '.' characters
    //     if (resultBuilder.Length < length)
    //     {
    //         resultBuilder.Append('.', length - resultBuilder.Length);
    //     }

    //     return resultBuilder.ToString();
    // }

    // static List<string> GeneratePossibleStrings(string targetString)
    // {
    //     List<string> possibleStrings = new List<string>();
    //     GeneratePossibleStringsRecursive(targetString, 0, new StringBuilder(targetString.Length), possibleStrings);
    //     return possibleStrings;
    // }

    // static void GeneratePossibleStringsRecursive(string targetString, int index, StringBuilder currentString, List<string> possibleStrings)
    // {
    //     if (index == targetString.Length)
    //     {
    //         // Base case: If the current string is complete, add it to the list
    //         possibleStrings.Add(currentString.ToString());
    //         return;
    //     }

    //     char currentChar = targetString[index];

    //     if (currentChar == '?')
    //     {
    //         // If the current character is a wildcard, branch for both '#' and '.'
    //         currentString.Append('#');
    //         GeneratePossibleStringsRecursive(targetString, index + 1, currentString, possibleStrings);
    //         currentString.Length--;

    //         currentString.Append('.');
    //         GeneratePossibleStringsRecursive(targetString, index + 1, currentString, possibleStrings);
    //         currentString.Length--;
    //     }
    //     else
    //     {
    //         // If the current character is not a wildcard, use it as is
    //         currentString.Append(currentChar);
    //         GeneratePossibleStringsRecursive(targetString, index + 1, currentString, possibleStrings);
    //         currentString.Length--;
    //     }
    // }

    // static bool MatchesRule(string str, int[] rule)
    // {
    //     int index = 0;

    //     foreach (int count in rule)
    //     {
    //         // Check if the current substring matches the rule
    //         string substring = str.Substring(index, count);

    //         if (!IsBlockValid(substring, count))
    //         {
    //             return false;
    //         }

    //         // Move to the next block
    //         index += count;

    //         // If there are more characters in the string, ensure they are '.'
    //         if (index < str.Length && str[index] != '.')
    //         {
    //             return false;
    //         }

    //         // Move past the '.' character
    //         index++;
    //     }

    //     return true;
    // }

    // static bool IsBlockValid(string block, int count)
    // {
    //     // Check if the block contains only '#' characters
    //     for (int i = 0; i < count; i++)
    //     {
    //         if (i >= block.Length || block[i] != '#')
    //         {
    //             return false;
    //         }
    //     }

    //     return true;
    // }
}
using System;
using System.Collections.Generic;
using adventofcode;

namespace aoc2023;


class solutionDay07 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine($"part 1");

        solutionBase sb = new();
        var input = sb.getInputLines(@"2023/Day07/test");
        //var input = sb.getInputLines(@"2023/Day07/input").ToArray();

        List<CamelCard> cards = new();

        for (int i = 0; i < input.Count; i++)
        {
            var original = input[i].Split(' ')[0];
            var bid = Convert.ToInt32(input[i].Split(' ')[1]);

            //Console.WriteLine($"{original} - {bid}");
            CamelCard card = new CamelCard(original, bid);

            cards.Add(card);
        }

        foreach (var item in cards)
        {
            Console.WriteLine(item);
        }

    }

    public void SolvePart2()
    {
        Console.WriteLine($"part 2 under development");
    }

    class CamelCard(string original, int bid)
    {
        public string Original { get; } = original;
        public int Bid { get; } = bid;

        public string Sorted()
        {
            var charArray = Original.ToCharArray();
            Array.Sort(charArray);
            string sortedString = new string(charArray).ToString();
            return sortedString;
        }

        public override string ToString()
        {
            return $"CamelCard: {Original}, Bid: {Bid}, Sorted: {Sorted}";
        }
    }
}
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using adventofcode;
using System.IO;


namespace aoc2023;


class solutionDay07 : ISolver
{
    //string[] strength = new string[] {"A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2"};

    public void SolvePart1()
    {
        Console.WriteLine($"part 1");

        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day07/test");
        var input = sb.getInputLines(@"2023/Day07/input");

        List<CamelCard> cards = new();

        for (int i = 0; i < input.Count; i++)
        {
            var original = input[i].Split(' ')[0];
            var bid = Convert.ToInt32(input[i].Split(' ')[1]);

            //Console.WriteLine($"{original} - {bid}");
            CamelCard card = new CamelCard(original, bid);

            cards.Add(card);
        }
        
        long total = 0;
        long rank = 1;

        StreamWriter sw = new("2023/Day07/output");
        using(sw)
        {
            foreach (var item in cards.OrderByDescending(c => c.Handtype()).ThenBy(c => c.Strength(0)).ThenBy(c => c.Strength(1)).ThenBy(c => c.Strength(2)).ThenBy(c => c.Strength(3)).ThenBy(c => c.Strength(4)))
            {
                Console.WriteLine(item);
                total += item.Bid * rank;
                Console.WriteLine($"{item.Bid} * {rank}");

                sw.WriteLine($"{item} - {rank}");

                rank++;
            }
            Console.WriteLine($"Total: {total}");
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
        public int Handtype() 
        {
            var count = Original.Distinct().Count();

            switch (count)
            {
                case 1:
                    //Five of a kind
                    return 0;
                case 2:
                    //Four of a kind or Full House 
                    if(Original.GroupBy(c => c).Any(group => group.Count() == 4))
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                case 3:
                    //three of a kind or two pair
                    if(Original.GroupBy(c => c).Any(group => group.Count() == 3))
                    {
                        return 3;
                    }
                    else
                    {
                        return 4;
                    }
                case 4:
                    //one pair
                    return 5;
                default:
                    //high card
                    return 6;
            }
        }

        public override string ToString()
        {
            return $"{Original} - {Bid} - Type: {Handtype()}";
        }

        public int Strength(int pos)
        {
            char[] strength = new char[] {'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};
            return strength.ToList().IndexOf(Original[pos]);
        }
    }   
}
using System;
using System.Collections.Generic;
using System.Linq;
using adventofcode;

namespace aoc2023;

class solutionDay04 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("part 1");

        solutionBase sb = new();
        var input = sb.getInputLines(@"2023/Day04/test");

        List<Scratchcard> scards = new();

        foreach (var item in input)
        {
            var card = item.Split(':')[0];
            var win = item.Split(':')[1].Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
            var own = item.Split(':')[1].Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();



            scards.Add(new Scratchcard(card, win, own));

        }

        foreach (var card in scards)
        {
            Console.WriteLine($"{card.ToString()}");
        }

    }
    public void SolvePart2()
    {
        Console.WriteLine("part 2");
    }


    internal class Scratchcard
    {
        internal string card;
        internal List<int> winningNumbers;
        internal List<int> ownNumbers;

        internal Scratchcard(string c, List<int> w, List<int> o)
        {
            card = c;
            winningNumbers = w;
            ownNumbers = o;
        }

        internal string ToString()
        {
             return $"Card: {card}, Winning Numbers: {ListToString(winningNumbers)}, Own Numbers: {ListToString(ownNumbers)}";
        }
        private string ListToString(List<int> list)
        {
            return list != null ? string.Join(", ", list) : "null";
        }
    }

}

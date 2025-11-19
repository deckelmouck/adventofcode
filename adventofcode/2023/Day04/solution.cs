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
        //var input = sb.getInputLines(@"2023/Day04/test");
        var input = sb.getInputLines(@"2023/Day04/input");

        List<Scratchcard> scards = new();
        var sum = 0;

        foreach (var item in input)
        {
            var card = item.Split(':')[0];
            var win = item.Split(':')[1].Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
            var own = item.Split(':')[1].Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();

            var items = win.Intersect(own);
            int count = items.Count();

            var value = 0;

            if(count > 0)
            {
                value = 1;
                if(count >= 1)
                {
                    value = (int)Math.Pow(2, count-1);
                }
            }
            
            sum += value;

            var newScratchcard = new Scratchcard(card, win, own);
            scards.Add(newScratchcard);

            //Console.WriteLine($"{card.ToString()} value: {value}");
        }

        // foreach (var card in scards)
        // {
        //     Console.WriteLine($"{card.ToString()}");
        // }
        Console.WriteLine($"sum of values is: {sum}");
    }
    public void SolvePart2()
    {
        Console.WriteLine("part 2");

        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day04/test").ToArray();
        var input = sb.getInputLines(@"2023/Day04/input").ToArray();

        //List<Scratchcard> scards = new();
        //var sum = 0;

        var scratchcards = input.Length;
        int[] scratchcardsCopies = new int[scratchcards];

        //int scratchcardPosition = 0;
        for(int i = 0; i < scratchcardsCopies.Length; i++)
        {
            scratchcardsCopies[i] = 1;
        }

        // foreach (var item in input)
        // {

        for(int scratchcardPosition = 0; scratchcardPosition < scratchcards; scratchcardPosition++)    
        {    //scratchcardsCopies[scratchcardPosition] = 1;

            var item = input[scratchcardPosition];

            var card = item.Split(':')[0];
            var win = item.Split(':')[1].Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
            var own = item.Split(':')[1].Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();

            var items = win.Intersect(own);
            int count = items.Count();

            // var value = 0;

            // if(count > 0)
            // {
            //     value = 1;
            //     if(count >= 1)
            //     {
            //         value = (int)Math.Pow(2, count-1);
            //     }
            // }
            
            // sum += value;
            
            for(int newCopies = 0; newCopies < count; newCopies++)
            {
                scratchcardsCopies[scratchcardPosition + newCopies + 1] += scratchcardsCopies[scratchcardPosition];
            }
            
            
            //scratchcardPosition++;

            //var newScratchcard = new Scratchcard(card, win, own);
            //scards.Add(newScratchcard);

            Console.WriteLine($"position: {scratchcardPosition}");
        }

        // foreach (var card in scards)
        // {
        //     Console.WriteLine($"{card.ToString()}");
        // }
        //int sumtest = 0;
        
        // foreach (var item in scratchcardsCopies)
        // {
        //     sum += item;
        //     Console.WriteLine($"item {item}");
        // }

        //Console.WriteLine($"sumtest value is: {sum}");
        Console.WriteLine($"value is: {scratchcardsCopies.Sum()}");
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

        public override string ToString()
        {
             return $"Card: {card}, Winning Numbers: {ListToString(winningNumbers)}, Own Numbers: {ListToString(ownNumbers)}";
        }
        private string ListToString(List<int> list)
        {
            return list != null ? string.Join(", ", list) : "null";
        }
    }

}

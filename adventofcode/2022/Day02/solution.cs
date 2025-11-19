

using System;
using adventofcode;

namespace aoc2022;

public class solutionDay02 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("to implement");
        solutionBase sb = new();
        var input = sb.getInputLines(@"2022/Day02/input");
        //var input = sb.getInputLines(@"2022/Day02/test");

        var totalScore = 0;

        foreach (var item in input)
        {
            Console.WriteLine(item);
            var temp = RockPaperScissors(item);
            Console.WriteLine(temp);

            totalScore += temp;
            Console.WriteLine(totalScore);
            Console.WriteLine("-------------");
        }

        //a rock, b paper, c scissors //x rock, y paper, z scissors
        //rock = 1, paper = 2, scissors = 3
        //lost = 0, draw = 3, win = 6

        Console.WriteLine($"totalScore: {totalScore}");


    }

    public void SolvePart2()
    {
        //Console.WriteLine("to implement");
    }

    int RockPaperScissors(string game)
    {
        int score = 0;
        switch (game)
        {
            case "A X":
                score = 1 + 3;
                break;
            case "B X":
                score = 1;
                break;
            case "C X":
                score = 1 + 6;
                break;

            case "A Y":
                score = 2 + 6;
                break;
            case "B Y":
                score = 2 + 3;
                break;
            case "C Y":
                score = 2;
                break;
                
            case "A Z":
                score = 3;
                break;
            case "B Z":
                score = 3 + 6;
                break;
            case "C Z":
                score = 3 + 3;
                break;
            default:
                break;
        }
        return score;
    }
}

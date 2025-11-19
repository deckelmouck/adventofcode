using System;
using System.Collections.Generic;

namespace adventofcode.Year2016.Day01;

class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        var inputPath = GetInputFilePath();
        var input = System.IO.File.ReadAllLines(inputPath);
        //string[] input = ["R5, L5, R5, R3"]; //12
        //string[] input = ["R2, R2, R2"]; //2
        //string[] input = ["R2, L3"]; //5
        List<string> instructions = new();

        foreach (var line in input)
        {
            instructions.AddRange(line.Split(", "));
        }
        
        int direction = 0;

        List<int[]> moves = new();

        foreach (string path in instructions)
        {
            char turn = path[0];
            int way = int.Parse(path.Remove(0,1));

            if (turn == 'L')
                direction = direction - 90;
            else
                direction = direction + 90;

            int[] move = [direction, way];
            moves.Add(move);                


            Console.WriteLine($"path: {path}, turn: {turn}, way: {way}, direction: {direction}, test: {direction % 360}");  
        }

        int x = 0;
        int y = 0;

        foreach (var item in moves)
        {
            int dir = item[0];
            int steps = item [1];

            switch (dir%360)
            {
                case 0:
                    y = y + steps;
                    break;
                case 90:
                case -270:
                    x = x + steps;
                    break;
                case 180:
                case -180:
                    y = y - steps;
                    break;
                case 270:
                case -90:
                    x = x - steps;
                    break;
                default:
                    break;
            }
            //Console.WriteLine($"x: {x}, y: {y}, manhatten_sum: {int.Abs(x)+int.Abs(y)}");
        }
        Console.WriteLine($"x: {x}, y: {y}, manhatten_sum: {int.Abs(x)+int.Abs(y)}");
    }

    public void SolvePart2()
    {
        throw new System.NotImplementedException();
    }
}
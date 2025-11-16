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

        int x = 0;
        int y = 0;
        
        foreach (string path in instructions)
        {
            char direction = path[0];
            int way = int.Parse(path.Remove(0,1));

            
        }

        Console.WriteLine($"x = {x}, y = {y}.");
    }

    public void SolvePart2()
    {
        throw new System.NotImplementedException();
    }
}
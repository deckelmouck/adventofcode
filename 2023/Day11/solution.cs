using System;
using System.Collections.Generic;
using adventofcode;

namespace aoc2023;

public class solutionDay11 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine($"part 1");

        solutionBase sb = new();
        //var input = sb.getInputLines(@"2023/Day11/input").ToArray();
        var input = sb.getInputLines(@"2023/Day11/test").ToArray();

        int width = input[0].Length;
        int height = input.Length;

        char[,] grid = new char[width, height];

        for (int y = 0; y < height; y++)
        {
            var line = input[y];
            for (int x = 0; x < width; x++)
            {
                grid[x, y] = line[x];
            }
        }

        List<Galaxy> galaxies = new();

        for (int y = 0; y < height; y++)
        {
            var line = input[y];
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] == '#')
                {
                    Galaxy galaxy = new Galaxy(galaxies.Count, x, y);
                    galaxies.Add(galaxy);
                }
            }
        }

        Console.WriteLine($"Galaxies: {galaxies.Count}");

        List<(Galaxy, Galaxy)> connections = new();
        
        for(int i = 0; i < galaxies.Count; i++)
        {
            for(int j = i + 1; j < galaxies.Count; j++)
            {
                var galaxy1 = galaxies[i];
                var galaxy2 = galaxies[j];

                connections.Add((galaxy1, galaxy2));
            }
        }

        Console.WriteLine($"Connections: {connections.Count}");

        foreach(var connection in connections)
        {
            var galaxy1 = connection.Item1;
            var galaxy2 = connection.Item2;

            //calculate manhatten distance between galaxies
            int distance = Math.Abs(galaxy1.X - galaxy2.X) + Math.Abs(galaxy1.Y - galaxy2.Y);

            Console.WriteLine($"Distance between {galaxy1.Id} and {galaxy2.Id} is {distance}");
        }

    }

    public void SolvePart2()
    {
        Console.WriteLine($"part 2 under development");
    }

    class Galaxy (int id, int x, int y)
    {
        public int Id { get; set; } = id;
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
    }

    
}
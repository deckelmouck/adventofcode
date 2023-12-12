using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using adventofcode;

namespace aoc2023;

public class solutionDay11 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine($"part 1");

        solutionBase sb = new();
        var input = sb.getInputLines(@"2023/Day11/input").ToArray();
        //var input = sb.getInputLines(@"2023/Day11/test").ToArray();

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

        for (long y = 0; y < height; y++)
        {
            var line = input[y];
            for (long x = 0; x < width; x++)
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

        //list all rows without Galaxy
        List<long> rows = new();

        for(long y = 0; y < height; y++)
        {
            bool hasGalaxy = false;
            for(long x = 0; x < width; x++)
            {
                if(grid[x, y] == '#')
                {
                    hasGalaxy = true;
                    break;
                }
            }

            if(!hasGalaxy)
            {
                rows.Add(y);
            }
        }

        //list all columns without Galaxy  
        List<int> columns = new();

        for(int x = 0; x < width; x++)
        {
            bool hasGalaxy = false;
            for(int y = 0; y < height; y++)
            {
                if(grid[x, y] == '#')
                {
                    hasGalaxy = true;
                    break;
                }
            }

            if(!hasGalaxy)
            {
                columns.Add(x);
            }
        }

        Console.WriteLine($"Rows: {rows.Count}");
        Console.WriteLine($"Columns: {columns.Count}");

        //Manhatten distance between galaxies without expansion
        foreach(var connection in connections)
        {
            var galaxy1 = connection.Item1;
            var galaxy2 = connection.Item2;

            //calculate manhatten distance between galaxies
            long distance = Math.Abs(galaxy1.X - galaxy2.X) + Math.Abs(galaxy1.Y - galaxy2.Y);

            //Console.WriteLine($"Distance between {galaxy1.Id} and {galaxy2.Id} is {distance}");
        }

        long expansionLevel = 1;
        long sum = 0;
        BigInteger sum2 = 0;
        //Manhatten distance between galaxies with expansion
        foreach(var connection in connections)
        {
            var galaxy1 = connection.Item1;
            var galaxy2 = connection.Item2;

            long expansionRows = rows.Count(row => row >= galaxy1.Y && row <= galaxy2.Y || row >= galaxy2.Y && row <= galaxy1.Y );
            long expansionColumns = columns.Count(column => column >= galaxy1.X && column <= galaxy2.X || column >= galaxy2.X && column <= galaxy1.X);

            //Console.WriteLine($"Expansion rows: {expansionRows}, galaxy1: {galaxy1.Y}, galaxy2: {galaxy2.Y}");
            //Console.WriteLine($"Expansion columns: {expansionColumns}, galaxy1: {galaxy1.X}, galaxy2: {galaxy2.X}");

            //calculate manhatten distance between galaxies
            long distance = Math.Abs(galaxy1.X - galaxy2.X) + (expansionLevel * expansionColumns) + Math.Abs(galaxy1.Y - galaxy2.Y) + (expansionLevel * expansionRows);
            sum += distance;
            //Console.WriteLine($"Distance between {galaxy1.Id + 1} and {galaxy2.Id + 1} with expansion is {distance} - {expansionRows} - {expansionColumns}");
            
            var expansionLevel2 = 999999;
            BigInteger distance2 = Math.Abs(galaxy1.X - galaxy2.X) + (expansionLevel2 * expansionColumns) + Math.Abs(galaxy1.Y - galaxy2.Y) + (expansionLevel2 * expansionRows);

            Console.WriteLine($"{distance2}");

            sum2 += distance2;
        }
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Sum2: {sum2}");
        // 82000210 is too low
        // haha, forgot to change from test to input :D
    }

    public void SolvePart2()
    {
        Console.WriteLine($"part 2 under development");
    }

    class Galaxy (long id, long x, long y)
    {
        public long Id { get; set; } = id;
        public long X { get; set; } = x;
        public long Y { get; set; } = y;
    }



    
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode.Year2024.Day04;

public class Solution : BaseSolution, ISolver
{
    public void SolvePart1()
    {
        //var inputFilePath = GetInputFilePath("test");
        var inputFilePath = GetInputFilePath();

        string[] lines = File.ReadAllLines(inputFilePath);
        // Add your Part 1 solution logic here

        //2023 day10
        char[,] map = new char[lines.Length, lines[0].Length];
        for (int y = 0; y < lines.Length; y++)
        {
            //Console.WriteLine($"y = {y} ,input_y = {input[y]}");
            var line = lines[y].ToArray();
            for (int x = 0; x < line.Length; x++)
            {
                map[x,y] = line[x];
            }
        }

        List<(int X, int Y)> targetX = new List<(int, int)>();
        //find all X
        for(int y = 0; y < map.GetLength(1); y++)
        {
            for(int x = 0; x < map.GetLength(0); x++)
            {
                if(map[x,y] == 'X')
                {
                    targetX.Add((x,y));
                }
            }
        }

        Console.WriteLine($"there are {targetX.Count} Xs on map");

        // Search for "XMAS" in all directions from each 'X'
        int foundCount = 0;
        foreach (var (startX, startY) in targetX)
        {
            int count = FindXmas(map, startX, startY, "XMAS");
            if (count > 0)
            {
                Console.WriteLine($"Found {count} 'XMAS' starting at ({startX}, {startY})");
            }
            foundCount += count;
        }

        Console.WriteLine($"Total 'XMAS' found: {foundCount}");

    }

    static int FindXmas(char[,] map, int startX, int startY, string word)
    {
        int[,] directions = {
            { 0, 1 },   // Down
            { 0, -1 },  // Up
            { 1, 0 },   // Right
            { -1, 0 },  // Left
            { 1, 1 },   // Diagonal Down-Right
            { 1, -1 },  // Diagonal Up-Right
            { -1, 1 },  // Diagonal Down-Left
            { -1, -1 }  // Diagonal Up-Left
        };

        int wordLength = word.Length;
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        int foundCount = 0;

        // Check each direction
        for (int d = 0; d < directions.GetLength(0); d++)
        {
            int dx = directions[d, 0];
            int dy = directions[d, 1];
            bool match = true;

            for (int i = 0; i < wordLength; i++)
            {
                int newX = startX + i * dx;
                int newY = startY + i * dy;

                // Ensure we are within the bounds of the grid
                if (newX < 0 || newX >= width || newY < 0 || newY >= height || map[newX, newY] != word[i])
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                foundCount++;
            }
        }

        return foundCount;
    }

    public void SolvePart2()
    {
        Console.WriteLine("Part 2");
        //var inputFilePath = GetInputFilePath("test");
        var inputFilePath = GetInputFilePath();

        string[] lines = File.ReadAllLines(inputFilePath);
        // Add your Part 1 solution logic here

        //2023 day10
        char[,] map = new char[lines.Length, lines[0].Length];
        for (int y = 0; y < lines.Length; y++)
        {
            //Console.WriteLine($"y = {y} ,input_y = {input[y]}");
            var line = lines[y].ToArray();
            for (int x = 0; x < line.Length; x++)
            {
                map[x,y] = line[x];
            }
        }

        List<(int X, int Y)> targetA = new List<(int, int)>();
        //find all As
        for(int y = 0; y < map.GetLength(1); y++)
        {
            for(int x = 0; x < map.GetLength(0); x++)
            {
                if(map[x,y] == 'A')
                {
                    targetA.Add((x,y));
                }
            }
        }

        Console.WriteLine($"there are {targetA.Count} As on map");

        // Search for the specific M.S around each 'A'
        int patternFoundCount = 0;
        foreach (var (x, y) in targetA)
        {
            if (CheckPatternAroundA(map, x, y))
            {
                Console.WriteLine($"Pattern found around A at ({x}, {y})");
                patternFoundCount++;
            }
        }

        Console.WriteLine($"Total patterns found: {patternFoundCount}");
    }

    static bool CheckPatternAroundA(char[,] map, int x, int y)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        // Ensure we are within the bounds of the grid for all checks
        if (x - 1 < 0 || x + 1 >= width || y - 1 < 0 || y + 1 >= height)
        {
            return false;
        }

        // Check for forward pattern (M . M / . A . / S . S)
        bool forwardPattern =
            map[x - 1, y - 1] == 'M' && map[x + 1, y - 1] == 'M' &&
            map[x - 1, y + 1] == 'S' && map[x + 1, y + 1] == 'S';

        // Check for backward pattern (S . S / . A . / M . M)
        bool backwardPattern =
            map[x - 1, y - 1] == 'S' && map[x + 1, y - 1] == 'S' &&
            map[x - 1, y + 1] == 'M' && map[x + 1, y + 1] == 'M';

        // Check for vertically mirrored forward pattern (M . S / . A . / M . S)
        bool verticalForwardPattern =
            map[x - 1, y - 1] == 'M' && map[x + 1, y - 1] == 'S' &&
            map[x - 1, y + 1] == 'M' && map[x + 1, y + 1] == 'S';

        // Check for vertically mirrored backward pattern (S . M / . A . / S . M)
        bool verticalBackwardPattern =
            map[x - 1, y - 1] == 'S' && map[x + 1, y - 1] == 'M' &&
            map[x - 1, y + 1] == 'S' && map[x + 1, y + 1] == 'M';

        return forwardPattern || backwardPattern || verticalForwardPattern || verticalBackwardPattern;
    }
}

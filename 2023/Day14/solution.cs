using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using adventofcode;

namespace aoc2023;

class solutionDay14 : ISolver
{
    public char[,] map;
    public int mapWidth;
    public int mapHeight;

    public void SolvePart1()
    {
        Console.WriteLine("day 14 part 1");

        solutionBase solutionBase = new solutionBase();
        //var input = solutionBase.getInputLines("2023/Day14/test").ToArray();
        var input = solutionBase.getInputLines("2023/Day14/input").ToArray();

        // foreach (var line in input)
        // {
        //     Console.WriteLine(line);
        // }

        map = new char[input[0].Length, input.Length];

        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                map[x, y] = input[y][x];
            }
        }

        // for (int y = 0; y < input.Length; y++)
        // {
        //     for (int x = 0; x < input[y].Length; x++)
        //     {
        //         Console.Write(map[x, y]);
        //     }
        //     Console.WriteLine();
        // }

        List<(int, int)> rocks = new List<(int, int)>();
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                if (map[x, y] == 'O')
                {
                    rocks.Add((x, y));
                }
            }
        }
        Console.WriteLine($"found {rocks.Count} rocks");

        foreach (var rock in rocks)
        {
            MoveRockNorth(rock.Item1, rock.Item2);
        }

        Console.WriteLine("moved rocks:");

        // for (int y = 0; y < input.Length; y++)
        // {
        //     for (int x = 0; x < input[y].Length; x++)
        //     {
        //         Console.Write(map[x, y]);
        //     }
        //     Console.WriteLine();
        // }

        long sum = 0;

        for (int y = 0; y < input.Length; y++)
        {
            long rowSum = 0;
            for (int x = 0; x < input[y].Length; x++)
            {
                if (map[x, y] == 'O')
                {
                    rowSum++;
                }
            }
            sum += rowSum * (input.Length - y);
        }


        Console.WriteLine($"sum: {sum}");
    }

    public void SolvePart2()
    {
        Console.WriteLine("day 14 part 2");

        solutionBase solutionBase = new solutionBase();
        //var input = solutionBase.getInputLines("2023/Day14/test").ToArray();
        var input = solutionBase.getInputLines("2023/Day14/input").ToArray();

        map = new char[input[0].Length, input.Length];
        mapWidth = input[0].Length;
        mapHeight = input.Length;

        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                map[x, y] = input[y][x];
            }
        }

        //PrintMap("initial");

        // for (int i = 0; i < 1000000000; i++)
        // {
        //     Cycle();

        //     //101410000
        //     //1000000000

        //     // if (i % 10000 == 0)
        //     // {
        //     //     Console.WriteLine($"cycle {i}");
        //     // }
        // }

        
        int cycleIterations = 1000000000;

        //var cloneMap = map.Clone();

        var existingMaps = new List<string>();

        //var test = CharArrayToString(map);
        //Console.WriteLine(test);

        while(!existingMaps.Contains(CharArrayToString(map)) && cycleIterations > 0)
        {
            //Console.WriteLine($"cycle {cycleIterations} - existingMaps: {existingMaps.Count}");
            existingMaps.Add(CharArrayToString(map));
            Cycle();
            //cloneMap = map.Clone();
            cycleIterations--;
        }

        var cycleLength = existingMaps.Count - existingMaps.IndexOf(CharArrayToString(map));
        cycleIterations = cycleIterations % cycleLength;

        while(cycleIterations > 0)
        {
            Cycle();
            cycleIterations--;
        }

        //PrintMap("final");

        
        var sum = SumMap();

        Console.WriteLine($"sum: {sum}");


    }

    public void PrintMap(string message = "")
    {
        Console.WriteLine($"{message} map:");
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                Console.Write(map[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("end map");
    }

    public long SumMap()
    {
        long sum = 0;

        for (int y = 0; y < mapHeight; y++)
        {
            long rowSum = 0;
            for (int x = 0; x < mapWidth; x++)
            {
                if (map[x, y] == 'O')
                {
                    rowSum++;
                }
            }
            sum += rowSum * (mapHeight - y);
        }
        return sum;
    }

    public void Cycle()
    {
        //Console.WriteLine("cycling...");
        var rocks4North = GetRocks();

        foreach (var rock in rocks4North)
        {
            MoveRockNorth(rock.Item1, rock.Item2);
        }
        //PrintMap("north");
        var rocks4West = GetRocks();

        foreach (var rock in rocks4West.OrderBy(r => r.Item2))
        {
            MoveRockWest(rock.Item1, rock.Item2);
        }
        //PrintMap("west");
        
        var rocks4South = GetRocks();

        foreach (var rock in rocks4South.OrderByDescending(r => r.Item2))
        {
            MoveRockSouth(rock.Item1, rock.Item2);
        }
        //PrintMap("south");
        
        var rocks4East = GetRocks();

        foreach (var rock in rocks4East.OrderByDescending(r => r.Item1).OrderByDescending(r => r.Item2)) 
        {
            MoveRockEast(rock.Item1, rock.Item2);
        }
        //PrintMap("east");
        
    }

    public List<(int, int)> GetRocks()
    {
        List<(int, int)> rocks = new List<(int, int)>();
        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                if (map[x, y] == 'O')
                {
                    rocks.Add((x, y));
                }
            }
        }

        return rocks;
    }

    public void MoveRockNorth(int x, int y)
    {
        if (y == 0)
        {
            return;
        }

        if (map[x, y - 1] == '.')
        {
            map[x, y - 1] = 'O';
            map[x, y] = '.';

            MoveRockNorth(x, y - 1);
        }
    }

    public void MoveRockSouth(int x, int y)
    {
        if (y == map.GetLength(1) - 1)
        {
            return;
        }

        if (map[x, y + 1] == '.')
        {
            map[x, y + 1] = 'O';
            map[x, y] = '.';

            MoveRockSouth(x, y + 1);
        }
    }

    public void MoveRockWest(int x, int y)
    {
        if (x == 0)
        {
            return;
        }

        if (map[x - 1, y] == '.')
        {
            map[x - 1, y] = 'O';
            map[x, y] = '.';

            MoveRockWest(x - 1, y);
        }
    }

    public void MoveRockEast(int x, int y)
    {
        if (x == map.GetLength(0) - 1)
        {
            return;
        }

        if (map[x + 1, y] == '.')
        {
            map[x + 1, y] = 'O';
            map[x, y] = '.';

            MoveRockEast(x + 1, y);
        }
    }

    static string CharArrayToString(char[,] charArray)
    {
        int rows = charArray.GetLength(0);
        int cols = charArray.GetLength(1);

        // Initialize a StringBuilder to efficiently concatenate strings
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        // Iterate through the array and append each character to the StringBuilder
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sb.Append(charArray[i, j]);
            }
        }

        // Convert StringBuilder to a string
        string result = sb.ToString();

        return result;
    }
}
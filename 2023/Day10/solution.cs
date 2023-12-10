using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using adventofcode;

namespace aoc2023;

public class solutionDay10 : ISolver
{
    List<Pipe> _visitedPipes = new List<Pipe>();


    public void SolvePart1()
    {
        Console.WriteLine($"part 1:");

        solutionBase sb = new solutionBase();
        //var input = sb.getInputLines(@"2023/Day10/testone").ToArray();
        //var input = sb.getInputLines(@"2023/Day10/testtwo").ToArray();
        var input = sb.getInputLines(@"2023/Day10/input").ToArray();

        char[,] map = new char[input.Length, input[0].Length];
        for (int y = 0; y < input.Length; y++)
        {
            //Console.WriteLine($"y = {y} ,input_y = {input[y]}");
            var line = input[y].ToArray();
            for (int x = 0; x < line.Length; x++)
            {
                map[x,y] = line[x];
            }
        }

        //for testing
        // for(int y = 0; y < map.GetLength(1); y++)
        // {
        //     for(int x = 0; x < map.GetLength(0); x++)
        //     {
        //         Console.Write(map[x,y]);
        //     }
        //     Console.WriteLine();
        // }

        //locate the S as starting point
        //find the two connected points
        //go both two ways and count the steps
        //repeat until both ways are meeting each other

        //find the S
        int sx = 0;
        int sy = 0;
        for(int y = 0; y < map.GetLength(1); y++)
        {
            for(int x = 0; x < map.GetLength(0); x++)
            {
                if(map[x,y] == 'S')
                {
                    sx = x;
                    sy = y;
                }
            }
        }

        Console.WriteLine($"S is at {sx},{sy}");

        //find the two connected points
        //list all points around the S
        //check if there are two points that connect as next step to the starting point

        List<Pipe> visitedPipes = new();

        Pipe startPipe = new Pipe('S', sx, sy);
        visitedPipes.Add(startPipe);

        Pipe currentPipe = startPipe;
        Pipe nextPipe = startPipe;
        Pipe beforePipe = startPipe;

        int steps = 0;
        bool foundStart = false;
        Console.WriteLine($"start at {startPipe}");
        //find the next pipe

        while(!foundStart)
        {
            //Console.WriteLine($"current pipe: {currentPipe}");

            foreach (var item in currentPipe.GetNeighboor(beforePipe))
            {
                //Console.WriteLine($"neighboor: {item}");
                var neighboorPipe = new Pipe(map[item.Item1, item.Item2], item.Item1, item.Item2);
                //Console.WriteLine($"check neighboor pipe: {neighboorPipe}");

                if(neighboorPipe != beforePipe)
                {
                    if (PipesAreConnected(currentPipe, neighboorPipe))
                    {
                        if(neighboorPipe.pipeChar == 'S' && steps > 3)
                        {
                            //Console.WriteLine($"found start again at {currentPipe.x},{currentPipe.y} after {steps} steps");
                            foundStart = true;
                        }
                        else if (neighboorPipe.pipeChar != 'S')
                        {
                            //Console.WriteLine($"found connected pipe: {neighboorPipe}");
                            visitedPipes.Add(neighboorPipe);
                            beforePipe = currentPipe;
                            currentPipe = neighboorPipe;
                            steps++;
                            break;
                        }
                    }
                }
            }
        }

        _visitedPipes = visitedPipes;

        Console.WriteLine($"found start again at {currentPipe.x},{currentPipe.y} after {steps} steps");
        var result = (steps + 1) / 2;
        Console.WriteLine($"result: {result}");

        // foreach (var item in currentPipe.GetNeighboors())
        // {
        //     Console.WriteLine($"neighboor: {item}");
        //     var neighboorPipe = new Pipe(map[item.Item1, item.Item2], item.Item1, item.Item2);
            
        //     if(currentPipe.PipesAreConnected(currentPipe, neighboorPipe))
        //     {
        //         Console.WriteLine($"found connected pipe: {neighboorPipe}");
        //         visitedPipes.Add(neighboorPipe);
        //         currentPipe = neighboorPipe;
        //         steps++;
        //         break;
        //     }

        // }

        // for(int y = 0; y < map.GetLength(1); y++)
        // {
        //     for(int x = 0; x < map.GetLength(0); x++)
        //     {
        //         if(map[x,y] != 'S' && map[x,y] != ' ' && map[x,y] != '.')
        //         {
        //             nextPipe = new Pipe(map[x,y], x, y);
        //             Console.WriteLine($"check next: {nextPipe}");
        //             if(currentPipe.PipesAreConnected(currentPipe, nextPipe))
        //             {
        //                 visitedPipes.Add(nextPipe);
        //                 currentPipe = nextPipe;
        //                 steps++;
        //                 break;
        //             }
        //         }
        //         else if(map[x,y] == 'S' && steps > 2)
        //         {
        //             Console.WriteLine($"found start again at {x},{y} after {steps} steps");
        //         }
        //     }
        // }


    }

    public void SolvePart2()
    {
        Console.WriteLine($"part 2 under development");

        solutionBase sb = new solutionBase();
        //var input = sb.getInputLines(@"2023/Day10/testone").ToArray();
        //var input = sb.getInputLines(@"2023/Day10/testtwo").ToArray();
        var input = sb.getInputLines(@"2023/Day10/input").ToArray();

        char[,] map = new char[input.Length, input[0].Length];
        for (int y = 0; y < input.Length; y++)
        {
            //Console.WriteLine($"y = {y} ,input_y = {input[y]}");
            var line = input[y].ToArray();
            for (int x = 0; x < line.Length; x++)
            {
                var dot = _visitedPipes.Contains(new Pipe('.', x, y));
                if(dot)
                {
                    map[x,y] = '.';
                }
                else
                {
                    map[x,y] = line[x];
                }
            }
        }



        List<string> mapLines = new List<string>();
        for(int y = 0; y < map.GetLength(1); y++)
        {
            string line = "";
            for(int x = 0; x < map.GetLength(0); x++)
            {
                line += map[x,y];
            }
            mapLines.Add(Regex.Replace(Regex.Replace(line.ToString(), "F-*7|L-*J", string.Empty), "F-*J|L-*7", "|"));

            Console.WriteLine(line);
            Console.WriteLine(mapLines.Last());
        }

        int count = 0;

        foreach (var l in mapLines)
        {
            int parity = 0;
            foreach(var c in l)
            {
                if (c == '|') parity++;
                if (c == '.' && parity % 2 == 1) count++;
            }
        }

        Console.WriteLine($"count is: {count}");

        //312 is too low
    }

    public enum Direction
    {
        North,
        South,
        East,
        West,
        None,
        Start
    }

    public class Pipe
    {
        public readonly int x;
        public readonly int y;
        public readonly char pipeChar;

        public List<Direction> Directions { get; private set; }

        public Pipe(char c, int x, int y)
        {            
            Directions = new List<Direction>();

            switch (c)
            {
                case '|':
                    Directions.Add(Direction.North);
                    Directions.Add(Direction.South);
                    break;
                case '-':
                    Directions.Add(Direction.East);
                    Directions.Add(Direction.West);
                    break;
                case 'L':
                    Directions.Add(Direction.North);
                    Directions.Add(Direction.East);
                    break;
                case 'J':
                    Directions.Add(Direction.North);
                    Directions.Add(Direction.West);
                    break;
                case '7':
                    Directions.Add(Direction.South);
                    Directions.Add(Direction.West);
                    break;
                case 'F':
                    Directions.Add(Direction.South);
                    Directions.Add(Direction.East);
                    break;
                case 'S': //start
                    Directions.Add(Direction.North);
                    Directions.Add(Direction.South);
                    Directions.Add(Direction.East);
                    Directions.Add(Direction.West);
                    break;
                default:
                    Directions.Add(Direction.None);
                    break;
            }

            this.x = x;
            this.y = y;
            this.pipeChar = c;
        }

        

        public List<(int,int)> GetNeighboors()
        {
            List<(int,int)> neighboors = new List<(int,int)>();

            if(Directions.Contains(Direction.North))
            {
                neighboors.Add((x, y - 1));
            }
            if(Directions.Contains(Direction.South))
            {
                neighboors.Add((x, y + 1));
            }
            if(Directions.Contains(Direction.East))
            {
                neighboors.Add((x + 1, y));
            }
            if(Directions.Contains(Direction.West))
            {
                neighboors.Add((x - 1, y));
            }

            return neighboors;
        }
        public List<(int,int)> GetNeighboor(Pipe pipeFrom)
        {
            List<(int,int)> neighboors = new List<(int,int)>();

            if(Directions.Contains(Direction.North))
            {
                neighboors.Add((x, y - 1));
            }
            if(Directions.Contains(Direction.South))
            {
                neighboors.Add((x, y + 1));
            }
            if(Directions.Contains(Direction.East))
            {
                neighboors.Add((x + 1, y));
            }
            if(Directions.Contains(Direction.West))
            {
                neighboors.Add((x - 1, y));
            }
            neighboors.Remove((pipeFrom.x, pipeFrom.y));

            return neighboors;
        }
        
        public override string ToString()
        {
            return $"Pipe '{pipeChar}' at {x},{y} with {Directions.Count} directions";
        }
    }

    public bool PipesAreConnected(Pipe pipeFrom, Pipe pipeTo)
    {
        //check if the pipes are connected
        if(pipeFrom.Directions.Contains(Direction.North) && pipeTo.Directions.Contains(Direction.South) && pipeFrom.y > pipeTo.y)
        {
            return true;
        }
        if(pipeFrom.Directions.Contains(Direction.South) && pipeTo.Directions.Contains(Direction.North) && pipeFrom.y < pipeTo.y)
        {
            return true;
        }
        if(pipeFrom.Directions.Contains(Direction.East) && pipeTo.Directions.Contains(Direction.West) && pipeFrom.x < pipeTo.x)
        {
            return true;
        }
        if(pipeFrom.Directions.Contains(Direction.West) && pipeTo.Directions.Contains(Direction.East) && pipeFrom.x > pipeTo.x)
        {
            return true;
        }

        return false;
    }
}
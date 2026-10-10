using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using adventofcode;

namespace aoc2023;

public class solutionDay16 : ISolver
{
    public static char[,] Map { get; set; }
    public static int WidthX { get; set; }
    public static int HeightY { get; set; }

    public static HashSet<Beam> Beams { get; set; } = new HashSet<Beam>();
    public static HashSet<VisitedPlace> VisitedPlaces { get; set; } = new HashSet<VisitedPlace>();

    public void SolvePart1()
    {
        Console.WriteLine("Day 16, Part 1");

        solutionBase solutionBase = new solutionBase();
        var input = solutionBase.getInputLines($"2023/Day16/test").ToArray();
        //var input = solutionBase.getInputLines($"2023/Day16/inputClean").ToArray();

        WidthX = input[0].Length;
        HeightY = input.Length;
        Map = new char[WidthX, HeightY];

        for (int y = 0; y < HeightY; y++)
        {
            for (int x = 0; x < WidthX; x++)
            {
                Map[x, y] = input[y][x];
            }
        }

        //PrintMap();

        var beam = new Beam(0, 0, Direction.Right);
        beam.AddBeam2Lists();

        while (Beams.Any(b => b.Moving))
        {
            var beamsToMove = Beams.Where(b => b.Moving).ToList();
            foreach (var b in beamsToMove)
            {
                b.Move();
            }
        }

        foreach (var vp in VisitedPlaces)
        {
            Map[vp.X, vp.Y] = '#';
        }

        PrintMap();

        Console.WriteLine($"Result visitedPlaces: {VisitedPlaces.Count}");

        HashSet<Point> hash = new HashSet<Point>();
        foreach (var vp in VisitedPlaces)
        {
            hash.Add(new Point(vp.X, vp.Y));
        }

        Console.WriteLine($"Result points: {hash.Count}");

    }

    public void SolvePart2()
    {
        Console.WriteLine("Day 16, Part 2");
    }

    public class Beam()
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }
        public bool Moving { get; set; } = true;

        public Beam(int x, int y, Direction direction) : this()
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Y++;
                    break;
                case Direction.Down:
                    Y--;
                    break;
                case Direction.Left:
                    X--;
                    break;
                case Direction.Right:
                    X++;
                    break;
            }

            if(X < 0 || X >= WidthX || Y < 0 || Y >= HeightY)
            {
                Moving = false;
                return;
            }

            var nextPlace = Map[X, Y];

            if (VisitedPlaces.Any(vp => vp.X == X && vp.Y == Y && vp.Direction == Direction))
            {
                Moving = false;
                return;
            }

            if (nextPlace == '|' && (Direction == Direction.Left || Direction == Direction.Right))
            {
                Moving = false;
                var newBeamUp = new Beam(X, Y, Direction.Up);
                var newBeamDown = new Beam(X, Y, Direction.Down);
                newBeamUp.AddBeam2Lists();
                newBeamDown.AddBeam2Lists();
            }
            else if (nextPlace == '-' && (Direction == Direction.Up || Direction == Direction.Down))
            {
                Moving = false;
                var newBeamLeft = new Beam(X, Y, Direction.Left);
                var newBeamRight = new Beam(X, Y, Direction.Right);
                newBeamLeft.AddBeam2Lists();
                newBeamRight.AddBeam2Lists();
            }
            else if (nextPlace == '/')
            {
                if (Direction == Direction.Up)
                {
                    Direction = Direction.Left;
                }
                else if (Direction == Direction.Down)
                {
                    Direction = Direction.Right;
                }
                else if (Direction == Direction.Left)
                {
                    Direction = Direction.Up;
                }
                else if (Direction == Direction.Right)
                {
                    Direction = Direction.Down;
                }
            }
            else if (nextPlace == '\\')
            {
                if (Direction == Direction.Up)
                {
                    Direction = Direction.Right;
                }
                else if (Direction == Direction.Down)
                {
                    Direction = Direction.Left;
                }
                else if (Direction == Direction.Left)
                {
                    Direction = Direction.Down;
                }
                else if (Direction == Direction.Right)
                {
                    Direction = Direction.Up;
                }
            }
            VisitedPlaces.Add(new VisitedPlace(this.X, this.Y, this.Direction));
        }

        public void AddBeam2Lists()
        {
            Beams.Add(this);
            VisitedPlaces.Add(new VisitedPlace(this.X, this.Y, this.Direction));
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class VisitedPlace(int x, int y, Direction direction)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public Direction Direction { get; } = direction;
    }

    public static void PrintMap()
    {
        for (int y = 0; y < HeightY; y++)
        {
            for (int x = 0; x < WidthX; x++)
            {
                Console.Write(Map[x, y]);
            }
            Console.WriteLine();
        }
    }
}
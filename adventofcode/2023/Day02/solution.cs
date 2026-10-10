using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using adventofcode;

namespace aoc2023;

class solutionDay02 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("part1");

        solutionBase sb = new();
        var input = sb.getInputLines(@"2023/Day02/input");
        //var input = sb.getInputLines(@"2023/Day02/testpartone");

        List<Game> games = new();

        foreach (var item in input)
        {
            string gamenumber = item.Split(':')[0].Replace("Game ", "");
            Console.WriteLine(gamenumber);

            int gno = Convert.ToInt32(gamenumber);

            string plays = item.Split(':')[1];

            List<Cubes> playlist = new();

            foreach (var set in plays.Split(';'))
            {
                int red = 0;
                int green = 0;
                int blue = 0;
                
                foreach (var c in set.Split(','))
                {
                    if(c.Contains("red"))
                    {
                        red = GetIntOutOfString(c);
                    }
                    else if(c.Contains("green"))
                    {
                        green = GetIntOutOfString(c);
                    }
                    else if(c.Contains("blue"))
                    {
                        blue = GetIntOutOfString(c);
                    }
                }

                Cubes cubesSet = new Cubes(red, green, blue);
                playlist.Add(cubesSet);
            }

            Game game = new Game(gno, playlist);
            games.Add(game);
        }

        Console.WriteLine($"there are {games.Count} games in input");

        //possible games with 12 red, 13 green and 14 blue cubes

        List<Game> possibleGames = new();

        foreach (var item in games)
        {
            int notPossible = 0;
            foreach (var set in item.listCubes)
            {
                if(set.red > 12 | set.green > 13 | set.blue > 14)
                {
                    notPossible++;
                }
            }

            if(notPossible == 0)
            {
                possibleGames.Add(item);
            }
        }

        Console.WriteLine($"there are {possibleGames.Count} games possible");

        int sumIds = possibleGames.Sum(x => x.game);

        Console.WriteLine($"sum of game ids is: {sumIds}");

    }

    public void SolvePart2()
    {
        Console.WriteLine("part2");

        solutionBase sb = new();
        var input = sb.getInputLines(@"2023/Day02/input");
        //var input = sb.getInputLines(@"2023/Day02/testpartone");

        List<Game> games = new();

        foreach (var item in input)
        {
            string gamenumber = item.Split(':')[0].Replace("Game ", "");
            Console.WriteLine(gamenumber);

            int gno = Convert.ToInt32(gamenumber);

            string plays = item.Split(':')[1];

            List<Cubes> playlist = new();

            foreach (var set in plays.Split(';'))
            {
                int red = 0;
                int green = 0;
                int blue = 0;
                
                foreach (var c in set.Split(','))
                {
                    if(c.Contains("red"))
                    {
                        red = GetIntOutOfString(c);
                    }
                    else if(c.Contains("green"))
                    {
                        green = GetIntOutOfString(c);
                    }
                    else if(c.Contains("blue"))
                    {
                        blue = GetIntOutOfString(c);
                    }
                }

                Cubes cubesSet = new Cubes(red, green, blue);
                playlist.Add(cubesSet);
            }

            Game game = new Game(gno, playlist);
            games.Add(game);
        }

        Console.WriteLine($"there are {games.Count} games in input");

        int sum = games.Sum(x => x.Power());
        Console.WriteLine($"the sum of all powers in: {sum} ");
    }

    int GetIntOutOfString(string input)
    {
        Match match = Regex.Match(input, @"\d+");

        if (match.Success && int.TryParse(match.Value, out int number))
        {
            return number;
        }
        return 0;
    }


    class Game
    {
        internal int game;
        internal List<Cubes> listCubes;

        internal Game (int g, List<Cubes> lc)
        {
            game = g;
            listCubes = lc;
        }

        internal int Power()
        {
            int maxRed = 0;
            int maxGreen = 0;
            int maxBlue = 0;

            maxRed = listCubes.Max(x => x.red);
            maxGreen = listCubes.Max(x => x.green);
            maxBlue = listCubes.Max(x => x.blue);


            return maxBlue * maxGreen * maxRed;
        }
    }

    class Cubes
    {
        internal int red;
        internal int green;
        internal int blue;

        internal Cubes(int r, int g, int b)
        {
            red = r;
            green = g;
            blue = b;
        }
    }
}

using System;
using System.Xml.Serialization;
using adventofcode;

namespace aoc2023;

class solutionDay03 : ISolver
{
    public void SolvePart1()
    {
        Console.WriteLine("part1");

        solutionBase sb = new();
        var input = sb.getInputLines(@"2023/Day03/input").ToArray();

        var xMax = input[0].Length;
        var yMax = input.Length;

        var map = new char[xMax, yMax];

        for (int y = 0; y < yMax; y++)
        {
            for (int x = 0; x < xMax; x++)
            {
                map[y,x] = input[x][y];
                //Console.Write(map[y,x]);

            }            
            //Console.WriteLine("BR");
        } 

        var totalSum = 0;
        var currentValue = 0;
        var hasSymbolAround = false;

        for (int x = 0; x < xMax; x++)
        {
            void EndCurrent()
            {
                if(currentValue != 0 && hasSymbolAround)
                {
                    totalSum += currentValue;
                }
                currentValue = 0;
                hasSymbolAround = false;
            }


            for (int y = 0; y < yMax; y++)
            {
                var actualChar = map[y, x];
                if(char.IsDigit(actualChar))
                {
                    var number = actualChar - '0';
                    currentValue = currentValue * 10 + number;

                    foreach (var around in Helper.pointsWithDiagonals)
                    {
                        var aroundX = x + around.X;
                        var aroundY = y + around.Y;

                        if (aroundX < 0 || aroundX >= xMax || aroundY < 0 || aroundY >= yMax)
                        {
                            continue;
                        }

                        var neighboor = map[aroundY, aroundX]; //got it here :/
                        if (!char.IsDigit(neighboor) && neighboor != '.')
                        {
                            hasSymbolAround = true;
                        }
                    }
                }
                else
                {
                    EndCurrent();
                }
            }
            EndCurrent();
        }
        
        Console.WriteLine($"totalsum: {totalSum}"); 
    }

    public void SolvePart2()
    {
        Console.WriteLine("part2");
    }
}

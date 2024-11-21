using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace adventofcode;

public static class Helper
{
    public static Point[] pointsWithDiagonals {get; } = 
    [
        (0, 1), 
        (1, 0), 
        (0, -1), 
        (-1, 0), 
        (1, 1), 
        (-1, 1), 
        (1, -1), 
        (-1, -1)
    ];

    public static string GetFilePath(int year, int day, string input = "input.txt")
    {
        string filepath = Path.Combine(Environment.CurrentDirectory, year.ToString("D4"), $"Day{day.ToString("D2")}", input);
        Debug.WriteLine(filepath);
        return filepath;
    }
}
using System;
using System.Drawing;

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

}
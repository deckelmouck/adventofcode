using adventofcode;
using adventofcode.Year2024.Day01;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        //var app = new Application();
        //var args = new string[] { "2024 01 01" };

        // Act
        //app.Run(args);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public void Test2()
    {
        //solution from 2024 day 01
        // Arrange
        var app = new adventofcode.Year2024.Day01.Solution();
        long output = app.SolvePart1Out();

        // Act
        long expected = 2113135;

        // Assert
        Assert.Equal(expected, output);
    }
}

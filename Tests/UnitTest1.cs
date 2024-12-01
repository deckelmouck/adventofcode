using adventofcode;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var app = new Application();
        var args = new string[] { "2024 01 01" };

        // Act
        app.Run(args);

        // Assert
        Assert.True(true);
    }
}

using adventofcode.Year2016.Day01;

namespace adventofcode.tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

    }
    
    [Theory]
    [InlineData("R5, L5, R5, R3", 12)]
    [InlineData("R2, R2, R2", 2)]
    [InlineData("R2, L3", 5)]
    public void Test1601(string input, int expected)
    {
        Solution sol = new Solution();
        int ret = sol.Part1(input);
        Assert.Equal(ret, expected);
    }
}

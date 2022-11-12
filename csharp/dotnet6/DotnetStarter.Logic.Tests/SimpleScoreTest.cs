using Xunit;

namespace DotnetStarter.Logic.Tests;

public class SimpleScoreTest
{
    [Fact]
    public void OneRollZeroScore()
    {
        var pins = 0;
        Assert.Equal(0,Score(pins));
    }
    
    [Fact]
    public void OneRollEightScore()
    {
        var pins = 8;
        Assert.Equal(8,Score(pins));
    }

    private static int Score(int pins)
    {
        return pins;
    }
}
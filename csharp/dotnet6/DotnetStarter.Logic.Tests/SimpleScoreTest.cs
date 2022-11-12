using Xunit;

namespace DotnetStarter.Logic.Tests;

public class SimpleScoreTest
{
    [Fact]
    public void OneRollZeroScore()
    {
        var pins = 0;
        Assert.Equal(score(pins),0);
    }
    
    [Fact]
    public void OneRollEightScore()
    {
        var pins = 8;
        Assert.Equal(score(pins),8);
    }

    private int score(int pins)
    {
        return pins;
    }
}
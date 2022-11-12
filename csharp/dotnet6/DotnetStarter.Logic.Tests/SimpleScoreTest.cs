using Xunit;

namespace DotnetStarter.Logic.Tests;

public class SimpleScoreTest
{
    [Fact]
    public void OneRollZeroScore()
    {
        var pins = 0;
        
        Assert.Equal(0,new Game().Score(pins));
    }
    
    [Fact]
    public void OneRollEightScore()
    {
        var pins = 8;
        Assert.Equal(8,new Game().Score(pins));
    }
}

public class Game
{
    public int Score(int pins)
    {
        return pins;
    }
}
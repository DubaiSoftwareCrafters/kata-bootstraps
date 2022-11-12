using Xunit;

namespace DotnetStarter.Logic.Tests;

public class SimpleScoreTest
{
    [Fact]
    public void OneRollZeroScore()
    {
        var pins = 0;

        var game = new Game();
        game.Roll(pins);
        var actual = game.Score(pins);
        Assert.Equal(0,actual);
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
    private int _pins;

    public int Score(int pins)
    {
        Roll(pins);
        return _pins;
    }

    public void Roll(int pins)
    {
        _pins = pins;
    }
}
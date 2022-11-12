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

        var actual = game.Score();
        Assert.Equal(pins, actual);
    }

    [Fact]
    public void OneRollEightScore()
    {
        var pins = 8;
        var game = new Game();

        game.Roll(pins);

        var actual = game.Score();
        Assert.Equal(pins, actual);
    }
}

public class Game
{
    private int _pins;

    public int Score()
    {
        return _pins;
    }

    public void Roll(int pins)
    {
        _pins = pins;
    }
}
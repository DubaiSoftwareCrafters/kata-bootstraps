using Xunit;

namespace DotnetStarter.Logic.Tests;

public class SimpleScoreTest
{
    private Game _game = new();

    [Fact]
    public void OneRollZeroScore()
    {
        var pins = 0;

        _game.Roll(pins);

        Assert.Equal(pins, _game.Score());
    }

    [Fact]
    public void OneRollEightScore()
    {
        var pins = 8;

        _game.Roll(pins);

        Assert.Equal(pins, _game.Score());
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
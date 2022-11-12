using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotnetStarter.Logic.Tests;

public class SimpleScoreTest
{
    private readonly Game _game = new();

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

    [Fact]
    public void TwoRollsSevenScore()
    {
        _game.Roll(2);
        _game.Roll(5);
        
        Assert.Equal(7, _game.Score());
    }
}

public class Game
{
    private readonly List<int> _pinsList = new();

    public int Score()
    {
        int sum = 0;
        for (var rollIndex = 0; rollIndex < _pinsList.Count; rollIndex++)
        {
            if (rollIndex > 1)
            {
                if (IsSpare(rollIndex))
                {
                    sum += _pinsList[rollIndex];
                }    
            }
            sum += _pinsList[rollIndex];
        }

        return sum;
    }

    private bool IsSpare(int rollIndex)
    {
        return _pinsList[rollIndex - 2] + _pinsList[rollIndex - 1] == 10;
    }

    public void Roll(int pins)
    {
        _pinsList.Add(pins);
    }
}
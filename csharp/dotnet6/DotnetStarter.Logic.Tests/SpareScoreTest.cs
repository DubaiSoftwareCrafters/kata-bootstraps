using Xunit;

namespace DotnetStarter.Logic.Tests;

public class SpareScoreTest
{
    private readonly Game _game = new();

    [Fact(Skip = "wip")]
    public void ThreeRolls_Spare_BonusPoints()
    {
        _game.Roll(5);
        _game.Roll(5);
        _game.Roll(3);
        Assert.Equal(16, _game.Score());
    }
}
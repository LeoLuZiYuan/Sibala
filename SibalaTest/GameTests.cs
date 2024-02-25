using FluentAssertions;
using Sibala;

namespace SibalaTest;

[TestFixture]
class GameTests
{
    private Game _game;

    [SetUp]
    public void SetUp()
    {
        _game = new Game();
    }


    [Test]
    public void Both_normal_Point()
    {
        ResultShouldBe("Black:5 3 5 4  White:2 6 2 3",
            "White win. - with normal point: 6 over 3");

        ResultShouldBe("Black:4 1 4 6  White:3 2 5 5",
            "Black win. - with normal point: 6 over 1");

    }

    [Test]
    public void Both_normal_Point_Tie()
    {
        ResultShouldBe("Black: 3 6 5 5  White: 4 4 3 6",
                       "Tie.");
    }

    private void ResultShouldBe(string input, string expected)
    {
        var result = _game.Result(input);
        result.Should().Be(expected);
    }
}
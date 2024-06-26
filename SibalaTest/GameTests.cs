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

        ResultShouldBe("Black: 3 6 5 5  White: 4 4 3 6",
            "Tie.");

        // decide by first point
        ResultShouldBe("Black: 3 4 5 5  White: 4 1 4 6",
            "White win. - with normal point: 6 over 1");

        // special case 2 6 2 6 = 12
        ResultShouldBe("Black: 5 3 5 4  White: 2 6 2 6",
            "White win. - with normal point: 6 over 6");

        ResultShouldBe("Black: 5 3 5 4  White: 2 6 2 6",
            "White win. - with normal point: 6 over 6");
    }

    [Test]
    public void Normal_Point_Win_Others()
    {
        // normal Point win others
        ResultShouldBe("Black: 3 5 5 5  White: 4 1 4 2",
            "White win. - with normal point: 3");
    }

    [Test]
    public void AllOfKind_Win_Others()
    {
        // All of a kind win normal Point
        ResultShouldBe("Black: 5 5 5 5  White: 2 6 2 3",
            "Black win. - with all of a kind: 5");

        ResultShouldBe("Black: 2 6 2 3  White: 5 5 5 5",
            "White win. - with all of a kind: 5");

        ResultShouldBe("Black: 2 2 2 3  White: 5 5 5 5",
            "White win. - with all of a kind: 5");
    }

    [Test]
    public void Both_All_Of_A_Kind()
    {
        ResultShouldBe("Black: 7 7 7 7  White: 2 2 2 2",
            "Black win. - with all of a kind: 7");

        ResultShouldBe("Black: 3 3 3 3  White: 3 3 3 3",
            "Tie.");
    }

    [Test]
    public void Different_Category_With_Tie()
    {
        ResultShouldBe("Black: 3 5 5 5  White: 4 1 3 6",
            "Tie.");
    }



    private void ResultShouldBe(string input, string expected)
    {
        var result = _game.Result(input);
        result.Should().Be(expected);
    }
}
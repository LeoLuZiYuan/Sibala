using FluentAssertions;
using Sibala;

namespace SibalaTest;

[TestFixture]
class GameTests
{
    [Test]
    public void Both_normal_Point()
    {
        var game = new Game();
        var result = game.Result("Black:5 3 5 4  White:2 6 2 3");
        result.Should().Be("White win. - with normal point: 6 over 3");
    }
}
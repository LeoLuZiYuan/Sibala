using FluentAssertions;
using Sibala;

namespace SibalaTest;

[TestFixture]
class ParserTests
{
    [Test]
    public void Parse()
    {
        var parser = new Parser();
        var result = parser.Parse("Black:5 3 5 4  White:2 6 2 3");
        result.Should().BeEquivalentTo(new List<Player>
        {
            new Player{
                Name ="Black",
                Dices = new List<Dice>
                {
                    new Dice{ Output = "5", Value = 5 },
                    new Dice{ Output = "3", Value = 3 },
                    new Dice{ Output = "5", Value = 5 },
                    new Dice{ Output = "4", Value = 4 }
                }
            },
            new Player
            {
                Name ="White",
                Dices = new List<Dice>
                {
                    new Dice{ Output = "2", Value = 2 },
                    new Dice{ Output = "6", Value = 6 },
                    new Dice{ Output = "2", Value = 2 },
                    new Dice{ Output = "3", Value = 3 }
                }
            }
        }, options => options.WithStrictOrdering());
    }
}
using System.Reflection.Metadata;
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
                Name ="Black"
            },
            new Player
            {
                Name ="White"
            }
        }, options => options.WithStrictOrdering());
    }
}
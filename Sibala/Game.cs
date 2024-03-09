using Sibala.Categories;
using Sibala.Compares;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var category1 = GetCategroy(players[0].Dices);
        var category2 = GetCategroy(players[1].Dices);

        if (category1.Type > category2.Type)
        {
            var winnerPlayer = players[0].Name;
            var winnerCategory = category1.Name;
            var winnerOutput = category1.WinnerOutput;
            return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
        }

        var normalPointCompare = new NormalPointCompare();
        var compareResult = normalPointCompare.Compare(players[0], players[1]);

        if (compareResult != 0)
        {
            var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
            string winnerOutput = normalPointCompare.WinnerOutput;
            return $"{winnerPlayer} win. - with normal point: {winnerOutput}";
        }

        return "Tie.";
    }

    private static Category GetCategroy(IEnumerable<Dice> Dices)
    {
        var isAllOfKind = Dices
                    .GroupBy(x => x.Value)
                    .Where(x => x.Count() == 4);

        if (isAllOfKind.Any())
        {
            return new Category { Type = CategroyType.AllOfKind, Name = "all of a kind", WinnerOutput = isAllOfKind.First().First().Output };
        }

        return new Category { Type = CategroyType.NormalPoint, Name = "normal point" };
    }
}
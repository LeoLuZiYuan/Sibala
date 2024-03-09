using Sibala.Compares;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var category1 = GetCategroy(players[0]);
        var category2 = GetCategroy(players[1]);

        if (category1.Type > category2.Type)
        {
            var winnerPlayer = players[0].Name;
            var winnerCategory = "all of a kind";
            var winnerOutput = "5";
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

    private static Category GetCategroy(Player player)
    {
        var isAllOfKind = player
                    .Dices
                    .GroupBy(x => x.Value)
                    .Where(x => x.Count() == 4);

        if (isAllOfKind.Any())
        {
            // return CategroyType.AllOfKind;
            return new Category { Type = CategroyType.AllOfKind };
        }

        // return CategroyType.NormalPoint;
        return new Category { Type = CategroyType.NormalPoint };
    }
}

internal class Category
{
    public CategroyType Type { get; set; }
}

public enum CategroyType
{
    NormalPoint = 1,
    AllOfKind = 2,
}
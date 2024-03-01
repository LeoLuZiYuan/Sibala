using Sibala.Compares;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var categoryType1 = GetCategroyType(players[0]);

        if (categoryType1 == Categroy.AllOfKind)
        {
            var winnerPlayer = "Black";
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

    private static Categroy GetCategroyType(Player player)
    {
        var isAllOfKind = player
                    .Dices
                    .GroupBy(x => x.Value)
                    .Where(x => x.Count() == 4);

        if (isAllOfKind.Any())
        {
            return Categroy.AllOfKind;
        }

        return Categroy.NormalPoint;
    }
}

public enum Categroy
{
    NormalPoint = 1,
    AllOfKind = 2,
}
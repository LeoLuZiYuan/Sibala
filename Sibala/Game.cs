using Sibala.Compares;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var categoryType1 = GetCategroyType(players[0]);
        var categoryType2 = GetCategroyType(players[1]);
         
        if (categoryType1 > categoryType2) 
        {
            var winnerPlayer = players[0].Name;
            var winnerCategory = "all of a kind";
            var winnerOutput = "5" ;
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

    private static CategroyType GetCategroyType(Player player)
    {
        var isAllOfKind = player
                    .Dices
                    .GroupBy(x => x.Value)
                    .Where(x => x.Count() == 4);

        if (isAllOfKind.Any())
        {
            return CategroyType.AllOfKind;
        }

        return CategroyType.NormalPoint;
    }
}

public enum CategroyType
{
    NormalPoint = 1,
    AllOfKind = 2,
}
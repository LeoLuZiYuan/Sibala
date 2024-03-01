using Sibala.Compares;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);


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
}
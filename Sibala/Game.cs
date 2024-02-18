namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        // Black:5 3 5 4  White:2 6 2 3
        var players = new Parser().Parse(input);

        var winnerPlayer = players[1].Name;
        var groupBy = players[1].Dices
                                    .OrderByDescending(x => x.Value)
                                    .GroupBy(x => x.Value).ToList();
        var winnerOutput = $"{groupBy[0].First().Output} over {groupBy[1].First().Output}";

        return $"{winnerPlayer} win. - with normal point: {winnerOutput}";
    }
} 
namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        // Black:5 3 5 4  White:2 6 2 3
        var players = new Parser().Parse(input);

        var winnerPlayer = players[1].Name;

        // group dices and select count < 2 value
        var nomalPoint = players[1].Dices
                                .GroupBy(x => x.Value)
                                .Where(x => x.Count() < 2)
                                .Select(x => x.First())
                                .OrderByDescending(x => x.Value).ToList();

        var winnerOutput = $"{nomalPoint[0].Output} over {nomalPoint[1].Output}";

        return $"{winnerPlayer} win. - with normal point: {winnerOutput}";
    }
} 
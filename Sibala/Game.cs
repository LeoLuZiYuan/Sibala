namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var nomalPoint1 = players[0].GetNormalPoint();
        var nomalPoint2 = players[1].GetNormalPoint();

        var compareResult = NormalPointCompare(nomalPoint1, nomalPoint2, out var winnerOutput);

        if (compareResult != 0)
        {
            var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
            return $"{winnerPlayer} win. - with normal point: {winnerOutput}";
        }

        return "Tie.";
    }

    private static int NormalPointCompare(List<Dice> nomalPoint1, List<Dice> nomalPoint2, out string? winnerOutput)
    {
        var pointValue1 = nomalPoint1[0].Value + nomalPoint1[1].Value;
        var pointValue2 = nomalPoint2[0].Value + nomalPoint2[1].Value;

        var compareResult = pointValue1 - pointValue2;
        winnerOutput = null;
        if (compareResult != 0)
        {
            winnerOutput = compareResult > 0
                ? $"{nomalPoint1[0].Output} over {nomalPoint1[1].Output}"
                : $"{nomalPoint2[0].Output} over {nomalPoint2[1].Output}";
        }

        return compareResult;
    }
}
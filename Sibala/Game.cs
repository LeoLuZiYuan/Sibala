using System.Security.Cryptography.X509Certificates;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var nomalPoint1 = GetNormalPoint(players[0]).ToList();
        var pointValue1 = nomalPoint1[0].Value + nomalPoint1[1].Value;


        var nomalPoint2 = GetNormalPoint(players[1]).ToList();
        var pointValue2 = nomalPoint2[0].Value + nomalPoint2[1].Value;

        string winnerPlayer;
        string winnerOutput;
        if (pointValue1 > pointValue2)
        {
            winnerPlayer = players[0].Name;
            winnerOutput = $"{nomalPoint1[0].Output} over {nomalPoint1[1].Output}";
        }
        else
        {
            winnerPlayer = players[1].Name;
            winnerOutput = $"{nomalPoint2[0].Output} over {nomalPoint2[1].Output}";
        }

        return $"{winnerPlayer} win. - with normal point: {winnerOutput}";
    }

    private static IEnumerable<Dice> GetNormalPoint(Player player)
    {
        return player.Dices
            .GroupBy(x => x.Value)
            .Where(x => x.Count() == 1)
            .Select(x => x.First())
            .OrderByDescending(x => x.Value).ToList();
    }
}
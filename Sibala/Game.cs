using System.Security.Cryptography.X509Certificates;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var nomalPoint1 = players[0].GetNormalPoint().ToList();
        var pointValue1 = nomalPoint1[0].Value + nomalPoint1[1].Value;


        var nomalPoint2 = players[1].GetNormalPoint().ToList();
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
}
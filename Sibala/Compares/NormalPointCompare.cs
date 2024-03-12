namespace Sibala.Compares;

public class NormalPointCompare
{
    public string WinnerOutput { get; private set; }
    public string CategoryName => "normal point";

    public int Compare(IEnumerable<Dice> player1, IEnumerable<Dice> player2)
    {
        var nomalPoint1 = GetNormalPoint(player1);
        var nomalPoint2 = GetNormalPoint(player2);  

        var pointValue1 = nomalPoint1[0].Value + nomalPoint1[1].Value;
        var pointValue2 = nomalPoint2[0].Value + nomalPoint2[1].Value;

        var compareResult = pointValue1 - pointValue2;
        if (compareResult != 0)
        {
            WinnerOutput = compareResult > 0
                ? $"{nomalPoint1[0].Output} over {nomalPoint1[1].Output}"
                : $"{nomalPoint2[0].Output} over {nomalPoint2[1].Output}";
        }

        return compareResult;
    }

    public List<Dice> GetNormalPoint(IEnumerable<Dice> diceList)
    {
        return diceList
            .GroupBy(x => x.Value)
            .Where(x => x.Count() == 1)
            .Select(x => x.First())
            .OrderByDescending(x => x.Value).ToList();
    }
}
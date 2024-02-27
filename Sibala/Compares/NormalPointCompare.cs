namespace Sibala.Compares;

public class NormalPointCompare
{
    public string WinnerOutput { get; private set; }

    public int Compare(List<Dice> nomalPoint1, List<Dice> nomalPoint2)
    {
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
}
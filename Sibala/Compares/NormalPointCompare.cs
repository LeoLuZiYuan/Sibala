namespace Sibala.Compares;

public class NormalPointComparer : IDiceHandsComparer
{
    public string WinnerOutput { get; private set; }
    public string WinnerCategory => "normal point";

    public int Compare(DiceHands dices1, DiceHands dices2)
    {
        var normalPoint1 = dices1.GetNormalPointValue();
        var normalPoint2 = dices2.GetNormalPointValue();

        var pointValue1 = normalPoint1[0].Value + normalPoint1[1].Value;
        var pointValue2 = normalPoint2[0].Value + normalPoint2[1].Value;

        var compareResult = pointValue1 - pointValue2;

        if (compareResult != 0)
        {
            WinnerOutput = compareResult > 0
                ? $"{normalPoint1[0].Output} over {normalPoint1[1].Output}"
                : $"{normalPoint2[0].Output} over {normalPoint2[1].Output}";
        }
        else
        {
            compareResult = CompareByValue(normalPoint1, normalPoint2);
        }

        return compareResult;
    }

    private int CompareByValue(List<Dice> normalPoint1, List<Dice> normalPoint2)
    {
        var enumerator1 = normalPoint1.GetEnumerator();
        var enumerator2 = normalPoint2.GetEnumerator();

        int compareResult = 0;
        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            var current1 = enumerator1.Current;
            var current2 = enumerator2.Current;
            compareResult = current1.Value - current2.Value;
            if (compareResult != 0)
            {
                WinnerOutput = compareResult > 0
                        ? $"{normalPoint1[0].Output} over {normalPoint1[1].Output}"
                        : $"{normalPoint2[0].Output} over {normalPoint2[1].Output}";
                break;
            }
        }

        return compareResult;
    }
}
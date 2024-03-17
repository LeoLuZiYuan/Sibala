namespace Sibala.Compares;

public class NormalPointComparer: IDiceHandsComparer
{
    public string WinnerOutput { get; private set; }
    public string WinnerCategory => "normal point";

    public int Compare(DiceHands dices1, DiceHands dices2)
    {
        var nomalPoint1 = dices1.GetNormalPointValue();
        var nomalPoint2 = dices2.GetNormalPointValue();

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
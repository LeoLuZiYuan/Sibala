namespace Sibala.Compares;

internal class NoPointComparer : IDiceHandsComparer
{
    public string WinnerOutput => "NoPoint";
    public string WinnerCategory => "no point";
    public int Compare(DiceHands dices1, DiceHands dices2)
    {
        return 0;
    }
}
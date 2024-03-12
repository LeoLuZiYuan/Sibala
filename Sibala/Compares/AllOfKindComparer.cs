namespace Sibala.Compares;

internal class AllOfKindComparer : IDiceHandsComparer
{
    public string WinnerOutput { get; set; }
    public string WinnerCategory => "all of a kind";
    public int Compare(DiceHands dices1, DiceHands dices2)
    {
        var allOfAkind1 = dices1.GetAllOfAkind();
        var allOfAkind2 = dices2.GetAllOfAkind();

        var compareResult =allOfAkind1.First().First().Value - allOfAkind2.First().First().Value;
        WinnerOutput = compareResult > 0 ? allOfAkind1.First().First().Output : allOfAkind2.First().First().Output;

        return compareResult;
    }
}
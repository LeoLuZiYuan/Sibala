namespace Sibala.Compares;

public interface IDiceHandsCompare
{
    string WinnerOutput { get; }
    string WinnerCategory { get; }
    int Compare(DiceHands dices1, DiceHands dices2);
}
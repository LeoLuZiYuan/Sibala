namespace Sibala.Compares;

public interface IDiceHandsComparer
{
    string WinnerOutput { get; }
    string WinnerCategory { get; }
    int Compare(DiceHands dices1, DiceHands dices2);
}
namespace Sibala.Compares;

public interface IDiceHandsCompare
{
    string WinnerOutput { get; set; }
    string WinnerCategory { get; set; }
    int Compare(DiceHands diceHands1, DiceHands diceHands2);
}
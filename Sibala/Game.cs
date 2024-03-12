using Sibala.Categories;
using Sibala.Compares;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var diceHands1 = players[0].GetDiceHands();
        var diceHands2 = players[1].GetDiceHands();

        var comparer = GetComparer(diceHands1, diceHands2);

        var compareResult = comparer.Compare(diceHands1, diceHands2);
        var winnerOutput = comparer.WinnerOutput;
        var winnerCategory = comparer.WinnerCategory;

        if (compareResult != 0)
        {
            var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
            return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
        }

        return "Tie.";
    }

    private static IDiceHandsComparer GetComparer(DiceHands diceHands1, DiceHands diceHands2)
    {
        if (diceHands1.GetCategroy().Type != diceHands2.GetCategroy().Type)
        {
            return new DifferentCategoryComparer();
        }

        return new NormalPointComparer();
    }
}
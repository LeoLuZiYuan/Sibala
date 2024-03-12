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

        IDiceHandsComparer comparer;
        if (diceHands1.GetCategroy().Type != diceHands2.GetCategroy().Type)
        {
            comparer = new DifferentCategoryComparer();
            // compareResult = comparer.Compare(diceHands1, diceHands2);
            // winnerOutput = comparer.WinnerOutput;
            // winnerCategory = comparer.WinnerCategory;
        }
        else
        {
            comparer = new NormalPointComparer();
            // compareResult = comparer.Compare(diceHands1, diceHands2);
            // winnerOutput = comparer.WinnerOutput;
            // winnerCategory = comparer.WinnerCategory;
        }

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
}
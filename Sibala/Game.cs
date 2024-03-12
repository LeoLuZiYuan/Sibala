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

        int compareResult;
        string winnerCategory;
        string winnerOutput;
        if (diceHands1.GetCategroy().Type != diceHands2.GetCategroy().Type)
        {
            var differentCategoryCompare = new DifferentCategoryCompare();
            compareResult = differentCategoryCompare.Compare(diceHands1, diceHands2);
            winnerOutput = differentCategoryCompare.WinnerOutput;
            winnerCategory = differentCategoryCompare.WinnerCategory;
        }
        else
        {
            var normalPointCompare = new NormalPointCompare();
            compareResult = normalPointCompare.Compare(diceHands1, diceHands2);
            winnerOutput = normalPointCompare.WinnerOutput;
            winnerCategory = normalPointCompare.CategoryName;
        }

        if (compareResult != 0)
        {
            var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
            return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
        }

        return "Tie.";
    }
}
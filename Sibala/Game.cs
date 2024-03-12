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

        var category1 = GetCategroy(diceHands1);
        var category2 = GetCategroy(diceHands2);

        int compareResult;
        string winnerCategory;
        string winnerOutput;
        if (category1.Type != category2.Type)
        {
            var differentCategoryCompare = new DifferentCategoryCompare();
            compareResult = differentCategoryCompare.Compare(category1, category2);
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

    private static Category GetCategroy(IEnumerable<Dice> Dices)
    {
        var isAllOfKind = Dices
                    .GroupBy(x => x.Value)
                    .Where(x => x.Count() == 4);

        if (isAllOfKind.Any())
        {
            return new AllOfAKind { WinnerOutput = isAllOfKind.First().First().Output };
        }

        return new NormalPoint { };
    }
}
using Sibala.Categories;
using Sibala.Compares;

namespace Sibala;

public class Game
{
    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var category1 = GetCategroy(players[0].Dices);
        var category2 = GetCategroy(players[1].Dices);

        int compareResult;
        string winnerCategory;
        string winnerOutput;
        if (category1.Type != category2.Type)
        {
            compareResult = DifferentCategoryCompare(category1, category2, out winnerCategory, out winnerOutput);
        }
        else
        {
            var normalPointCompare = new NormalPointCompare();
            compareResult = normalPointCompare.Compare(players[0], players[1]);

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

    private static int DifferentCategoryCompare(Category category1, Category category2, out string winnerCategory,
        out string winnerOutput)
    {
        var compareResult = category1.Type - category2.Type;
        if (category1.Type > category2.Type)
        {
            winnerCategory = category1.Name;
            winnerOutput = category1.WinnerOutput;
        }
        else
        {
            winnerCategory = category2.Name;
            winnerOutput = category2.WinnerOutput;
        }

        return compareResult;
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
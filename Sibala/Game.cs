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

        int compareResult = 0;
        string winnerPlayer;
        string winnerCategory;
        string winnerOutput;
        if (category1.Type != category2.Type)
        {
            compareResult = category1.Type - category2.Type;
            if (category1.Type > category2.Type)
            {
                winnerPlayer = players[0].Name;
                winnerCategory = category1.Name;
                winnerOutput = category1.WinnerOutput;
            }
            else
            {
                winnerPlayer = players[1].Name;
                winnerCategory = category2.Name;
                winnerOutput = category2.WinnerOutput;
            }
            // return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
        }
        else
        {
            var normalPointCompare = new NormalPointCompare();
            compareResult = normalPointCompare.Compare(players[0], players[1]);

            winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
            winnerOutput = normalPointCompare.WinnerOutput;
            winnerCategory = normalPointCompare.CategoryName;
        }

        if (compareResult != 0)
        {
            // winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
            // winnerOutput = normalPointCompare.WinnerOutput;
            // winnerCategory = normalPointCompare.CategoryName;
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
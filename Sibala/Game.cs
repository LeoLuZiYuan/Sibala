using Sibala.Categories;
using Sibala.Compares;

namespace Sibala;

public class Game
{
    private static Dictionary<CategroyType, IDiceHandsComparer> _sameCategoryLookup = new Dictionary<CategroyType, IDiceHandsComparer>
    {
        {CategroyType.AllOfKind, new AllOfKindComparer()},
        {CategroyType.NormalPoint, new NormalPointComparer()},
        {CategroyType.NoPoint, new NoPointComparer()}
    };

    public string Result(string input)
    {
        var players = new Parser().Parse(input);

        var diceHands1 = players[0].GetDiceHands();
        var diceHands2 = players[1].GetDiceHands();

        var comparer = GetComparer(diceHands1, diceHands2);

        var compareResult = comparer.Compare(diceHands1, diceHands2);

        if (compareResult != 0)
        {
            var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
            var winnerOutput = comparer.WinnerOutput;
            var winnerCategory = comparer.WinnerCategory;
            return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
        }

        return "Tie.";
    }

    private static IDiceHandsComparer GetComparer(DiceHands diceHands1, DiceHands diceHands2)
    {
        var categroyType1 = diceHands1.GetCategory().Type;
        var categroyType2 = diceHands2.GetCategory().Type;

        if (categroyType1 != categroyType2)
        {
            return new DifferentCategoryComparer();
        }

        return _sameCategoryLookup[categroyType1];
    }
}
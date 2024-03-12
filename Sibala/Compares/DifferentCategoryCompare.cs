using Sibala.Categories;

namespace Sibala.Compares;

public class DifferentCategoryCompare : IDiceHandsCompare
{
    public string WinnerOutput { get; private set; }

    public string WinnerCategory { get; private set; }

    public int Compare(DiceHands dices1, DiceHands dices2)
    {
        Category category1 = dices1.GetCategroy();
        Category category2 = dices2.GetCategroy();
        var compareResult = category1.Type - category2.Type;
        if (category1.Type > category2.Type)
        {
            WinnerCategory = category1.Name;
            WinnerOutput = category1.WinnerOutput;
        }
        else
        {
            WinnerCategory = category2.Name;
            WinnerOutput = category2.WinnerOutput;
        }

        return compareResult;
    }
}
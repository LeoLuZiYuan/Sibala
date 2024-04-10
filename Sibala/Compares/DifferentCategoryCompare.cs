using Sibala.Categories;

namespace Sibala.Compares;

public class DifferentCategoryComparer : IDiceHandsComparer
{
    public string WinnerOutput { get; private set; }

    public string WinnerCategory { get; private set; }

    public int Compare(DiceHands dices1, DiceHands dices2)
    {
        var category1 = dices1.GetCategory();
        var category2 = dices2.GetCategory();
        var compareResult = category1.Type - category2.Type;
        
        WinnerCategory = compareResult > 0 ? category1.Name : category2.Name;
        WinnerOutput = compareResult > 0 ? category1.WinnerOutput : category2.WinnerOutput;

        return compareResult;
    }
}
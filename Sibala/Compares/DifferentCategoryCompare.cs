using Sibala.Categories;

namespace Sibala.Compares;

public class DifferentCategoryCompare
{
    public string WinnerOutput { get; set; }

    public string WinnerCategory { get; set; }

    public int Compare(DiceHands diceHands1, DiceHands diceHands2)
    {
        Category category1 = diceHands1.GetCategroy();
        Category category2 = diceHands2.GetCategroy();
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
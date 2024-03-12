using Sibala.Categories;

namespace Sibala.Compares;

public class DifferentCategoryCompare
{
    public string WinnerOutput { get; set; }

    public string WinnerCategory { get; set; }

    public int Compare(Category category1, Category category2)
    {
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
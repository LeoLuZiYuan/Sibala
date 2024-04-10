using Sibala.Categories;

namespace Sibala.CategoryMatcher;

public class AllOfKindMatcher
{
    private readonly NormalPointMatcher _NextCategoryMatcher;

    public AllOfKindMatcher()
    {
        _NextCategoryMatcher = new NormalPointMatcher();
    }

    public Category DecidedCategory(DiceHands diceHands)
    {
        if (IsMatched(diceHands))
        {
            return GetMatchedCategory(diceHands);
        }
        else
        {
            return _NextCategoryMatcher.DecidedCategory(diceHands);
        }
    }

    private  Category GetMatchedCategory(DiceHands diceHands)
    {
        return new AllOfAKind { WinnerOutput = diceHands.GetAllOfAkind().First().First().Output };
    }

    private  bool IsMatched(DiceHands diceHands)
    {
        return diceHands.GetAllOfAkind().Any();
    }
}
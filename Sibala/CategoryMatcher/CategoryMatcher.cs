using Sibala.Categories;

namespace Sibala.CategoryMatcher;

public abstract class CategoryMatcher
{
    private NormalPointMatcher _NextCategoryMatcher;

    protected CategoryMatcher(NormalPointMatcher nextCategoryMatcher)
    {
        _NextCategoryMatcher = nextCategoryMatcher;
    }

    public Category DecidedCategory(DiceHands diceHands)
    {
        if (IsMatched(diceHands))
        {
            return GetMatchedCategory(diceHands);
        }
        else
        {
            return _NextCategoryMatcher != null
                ? _NextCategoryMatcher.DecidedCategory(diceHands)
                : new NoPoint { };
        }
    }

    protected abstract Category GetMatchedCategory(DiceHands diceHands);
    protected abstract bool IsMatched(DiceHands diceHands);
}
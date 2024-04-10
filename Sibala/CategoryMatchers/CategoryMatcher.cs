using Sibala.Categories;

namespace Sibala.CategoryMatchers;

public abstract class CategoryMatcher
{
    private readonly CategoryMatcher _nextCategoryMatcher;

    protected CategoryMatcher(CategoryMatcher nextCategoryMatcher)
    {
        _nextCategoryMatcher = nextCategoryMatcher;
    }

    public Category DecidedCategory(DiceHands diceHands)
    {
        if (IsMatched(diceHands))
        {
            return GetMatchedCategory(diceHands);
        }
        else
        {
            return _nextCategoryMatcher != null
                ? _nextCategoryMatcher.DecidedCategory(diceHands)
                : new NoPoint { };
        }
    }

    protected abstract Category GetMatchedCategory(DiceHands diceHands);
    protected abstract bool IsMatched(DiceHands diceHands);
}
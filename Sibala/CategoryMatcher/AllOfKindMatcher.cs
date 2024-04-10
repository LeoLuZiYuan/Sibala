using Sibala.Categories;

namespace Sibala.CategoryMatcher;

public class AllOfKindMatcher : CategoryMatcher
{
    public AllOfKindMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
    {
    }

    protected override Category GetMatchedCategory(DiceHands diceHands)
    {
        return new AllOfAKind { WinnerOutput = diceHands.GetAllOfAkind().First().First().Output };
    }

    protected override bool IsMatched(DiceHands diceHands)
    {
        return diceHands.GetAllOfAkind().Any();
    }
}
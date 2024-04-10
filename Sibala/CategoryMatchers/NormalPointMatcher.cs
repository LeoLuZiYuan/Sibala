using Sibala.Categories;

namespace Sibala.CategoryMatchers;

public class NormalPointMatcher : CategoryMatcher
{
    public NormalPointMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
    {
    }

    protected override Category GetMatchedCategory(DiceHands diceHands)
    {
        var normalPoint1 = diceHands.GetNormalPointValue()[0].Value;
        var normalPoint2 = diceHands.GetNormalPointValue()[1].Value;
        return new NormalPoint { WinnerOutput = $"{normalPoint1 + normalPoint2}" };
    }

    protected override bool IsMatched(DiceHands diceHands)
    {
        return diceHands.GetNormalPointFirstPair().Any();
    }

}
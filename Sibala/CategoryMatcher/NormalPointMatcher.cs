using Sibala.Categories;

namespace Sibala.CategoryMatcher;

public class NormalPointMatcher : CategoryMatcher
{
    public NormalPointMatcher(NormalPointMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
    {
    }

    // public Category DecidedCategory(DiceHands diceHands)
    // {
    //     if (IsMatched(diceHands))
    //     {
    //         return GetMatchedCategory(diceHands);
    //     }
    //     else
    //     {
    //         return new NoPoint { };
    //     }
    // }

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
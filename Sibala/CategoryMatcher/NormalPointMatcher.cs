using Sibala.Categories;

namespace Sibala.CategoryMatcher;

public class NormalPointMatcher
{
    public NormalPointMatcher()
    {
    }

    public Category DecidedCategory(DiceHands diceHands)
    {
        if (IsMatchedNormalPoint(diceHands))
        {
            var normalPoint1 = diceHands.GetNormalPointValue()[0].Value;
            var normalPoint2 = diceHands.GetNormalPointValue()[1].Value;
            return new NormalPoint { WinnerOutput = $"{normalPoint1 + normalPoint2}" };
        }
        else
        {
            return new NoPoint { };
        }
    }

    private  bool IsMatchedNormalPoint(DiceHands diceHands)
    {
        return diceHands.GetNormalPointFirstPair().Any();
    }
}
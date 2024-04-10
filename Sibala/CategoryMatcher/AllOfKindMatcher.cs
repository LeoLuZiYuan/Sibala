using Sibala.Categories;

namespace Sibala.CategoryMatcher;

public class NormalPointMatcher
{
    public NormalPointMatcher()
    {
    }

    public Category NextMatch(DiceHands diceHands)
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

public class AllOfKindMatcher
{
    private readonly NormalPointMatcher _normalPointMatcher;

    public AllOfKindMatcher()
    {
        _normalPointMatcher = new NormalPointMatcher();
    }

    public Category DecidedCategory(DiceHands diceHands)
    {
        if (IsMatched(diceHands))
        {
            return GetMatchedCategory(diceHands);
        }
        else
        {
            return _normalPointMatcher.NextMatch(diceHands);
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
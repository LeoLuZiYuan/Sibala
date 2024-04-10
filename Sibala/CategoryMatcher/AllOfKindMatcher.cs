using Sibala.Categories;

namespace Sibala.CategoryMatcher;

public class AllOfKindMatcher
{
    public AllOfKindMatcher()
    {
    }

    public Category DecidedCategory(DiceHands diceHands)
    {
        if (IsMatched(diceHands))
        {
            return GetMatchedCategory(diceHands);
        }
        else
        {
            return NextMatch(diceHands);
        }
    }

    private static Category GetMatchedCategory(DiceHands diceHands)
    {
        return new AllOfAKind { WinnerOutput = diceHands.GetAllOfAkind().First().First().Output };
    }

    private static bool IsMatched(DiceHands diceHands)
    {
        return diceHands.GetAllOfAkind().Any();
    }

    private Category NextMatch(DiceHands diceHands)
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

    private static bool IsMatchedNormalPoint(DiceHands diceHands)
    {
        return diceHands.GetNormalPointFirstPair().Any();
    }
}
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Sibala.Categories;

namespace Sibala;

public class AllOfKindMatcher
{
    private DiceHands _diceHands;

    public AllOfKindMatcher(DiceHands diceHands)
    {
        _diceHands = diceHands;
    }

    public Category DecidedCategory()
    {
        if (IsMatchedAllOfKind(_diceHands))
        {
            return new AllOfAKind { WinnerOutput = _diceHands.GetAllOfAkind().First().First().Output };
        }
        else
        {
            return NextMatch(_diceHands);
        }
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

    private static bool IsMatchedAllOfKind(DiceHands diceHands)
    {
        return diceHands.GetAllOfAkind().Any();
    }
}

public class DiceHands : IEnumerable<Dice>
{
    private readonly IEnumerable<Dice> _orderDices;
    private readonly AllOfKindMatcher _allOfKindMatcher;

    public DiceHands(IEnumerable<Dice> orderDices)
    {
        _orderDices = orderDices;
        _allOfKindMatcher = new AllOfKindMatcher(this);
    }

    public AllOfKindMatcher AllOfKindMatcher
    {
        get { return _allOfKindMatcher; }
    }

    public IEnumerator<Dice> GetEnumerator()
    {
        return _orderDices.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Category GetCategory()
    {
        return AllOfKindMatcher.DecidedCategory();
    }

    public IEnumerable<IGrouping<int, Dice>> GetAllOfAkind()
    {
        return this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 4);
    }

    public IEnumerable<IGrouping<int, Dice>> GetNormalPointFirstPair()
    {
        var normalPoint = this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 2);
        return normalPoint;
    }

    /// <summary>
    /// 取得 Normal Point 排除pair的點數
    /// </summary>
    /// <returns></returns>
    public List<Dice> GetNormalPointValue()
    {
        // 6 6 2 2 = 12
        var smallerPair = GetNormalPointFirstPair().Last().First().Value;
        return this.Where(x => x.Value != smallerPair).ToList();
    }
}
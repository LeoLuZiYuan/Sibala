using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Sibala.Categories;

namespace Sibala;

public class DiceHands : IEnumerable<Dice>
{
    private readonly IEnumerable<Dice> _orderDices;

    public DiceHands(IEnumerable<Dice> orderDices)
    {
        _orderDices = orderDices;
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
        return DecidedCategory();
    }

    private Category DecidedCategory()
    {
        if (IsMatchedAllOfKind(this))
        {
            return new AllOfAKind { WinnerOutput = GetAllOfAkind().First().First().Output };
        }
        else
        {
            return NextMatch();
        }
    }

    private Category NextMatch()
    {
        if (IsMatchedNormalPoint(this))
        {
            var normalPoint1 = GetNormalPointValue()[0].Value;
            var normalPoint2 = GetNormalPointValue()[1].Value;
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
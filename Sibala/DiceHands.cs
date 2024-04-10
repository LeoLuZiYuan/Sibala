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

    public Category GetCategroy()
    {
        var isAllOfKind = GetAllOfAkind();

        if (IsMatchedAllOfKind(isAllOfKind))
        {
            return new AllOfAKind { WinnerOutput = isAllOfKind.First().First().Output };
        }
        else
        {
            var isNormalPoint = GetNormalPointFirstPair();
            if (IsMatchedNormalPoint(isNormalPoint))
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
    }

    private static bool IsMatchedNormalPoint(IEnumerable<IGrouping<int, Dice>> isNormalPoint)
    {
        return isNormalPoint.Any();
    }

    private static bool IsMatchedAllOfKind(IEnumerable<IGrouping<int, Dice>> isAllOfKind)
    {
        return isAllOfKind.Any();
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
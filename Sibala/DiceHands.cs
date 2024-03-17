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

        if (isAllOfKind.Any())
        {
            return new AllOfAKind { WinnerOutput = isAllOfKind.First().First().Output };
        }

        var isNormalPoint = GetNormalPoint();
        if (isNormalPoint.Any())
        {
            var normalPoint1 = GetNormalPointValue()[0].Value;
            var normalPoint2 = GetNormalPointValue()[1].Value;
            return new NormalPoint { WinnerOutput = $"{normalPoint1 + normalPoint2}" };
        }

        return new NoPoint { };
    }

    public IEnumerable<IGrouping<int, Dice>> GetAllOfAkind()
    {
        return this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 4);
    }

    public IEnumerable<IGrouping<int, Dice>> GetNormalPoint()
    {
        var normalPoint = this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 2);
        return normalPoint;
    }

    public List<Dice> GetNormalPointValue()
    {
        // 6 6 2 2 = 12
        var getSmallPair = GetNormalPoint().Last().First().Value;
        return this.Where(x => x.Value != getSmallPair).ToList();
    }
}
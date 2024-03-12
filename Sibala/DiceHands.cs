using System.Collections;
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
            var normalPoint1 = GetNormalPointValue()[0].First().Output;
            var normalPoint2 = GetNormalPointValue()[1].First().Output;
            return new NormalPoint { WinnerOutput = $"{normalPoint1} over {normalPoint2}" };
        }

        return new NormalPoint { };
    }

    public IEnumerable<IGrouping<int, Dice>> GetAllOfAkind()
    {
        return this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 4);
    }

    public IEnumerable<IGrouping<int, Dice>> GetNormalPoint()
    {
        return this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 2);
    }

    public List<IGrouping<int, Dice>> GetNormalPointValue()
    {
        // 5 3 5 2 = 5
        return this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 1).ToList();
    }
}
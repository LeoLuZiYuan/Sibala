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

        return new NormalPoint { };
    }

    public IEnumerable<IGrouping<int, Dice>> GetAllOfAkind()
    {
        return this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 4);
    }
}
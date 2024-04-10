using System.Collections;
using Sibala.Categories;
using Sibala.CategoryMatchers;

namespace Sibala;

public class DiceHands : IEnumerable<Dice>
{
    private readonly IEnumerable<Dice> _orderDices;
    private readonly CategoryMatcher _categoryMatcher;

    public DiceHands(IEnumerable<Dice> orderDices)
    {
        _orderDices = orderDices;
        _categoryMatcher = new AllOfKindMatcher(
                                new NormalPointMatcher(null));
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
        return _categoryMatcher.DecidedCategory(this);
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
    /// ���o Normal Point �ư�pair���I��
    /// </summary>
    /// <returns></returns>
    public List<Dice> GetNormalPointValue()
    {
        // 6 6 2 2 = 12
        var smallerPair = GetNormalPointFirstPair().Last().First().Value;
        return this.Where(x => x.Value != smallerPair).ToList();
    }
}
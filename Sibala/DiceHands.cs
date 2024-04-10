using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Sibala.Categories;
using Sibala.CategoryMatcher;

namespace Sibala;

public class DiceHands : IEnumerable<Dice>
{
    private readonly IEnumerable<Dice> _orderDices;
    private readonly AllOfKindMatcher _allOfKindMatcher;

    public DiceHands(IEnumerable<Dice> orderDices)
    {
        _orderDices = orderDices;
        _allOfKindMatcher = new AllOfKindMatcher();
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
        return _allOfKindMatcher.DecidedCategory(this);
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
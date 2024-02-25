namespace Sibala;

public class Player
{
    public string Name { get; set; }
    public List<Dice> Dices { get; set; }

    public IEnumerable<Dice> GetNormalPoint()
    {
        return Dices
            .GroupBy(x => x.Value)
            .Where(x => x.Count() == 1)
            .Select(x => x.First())
            .OrderByDescending(x => x.Value).ToList();
    }
}
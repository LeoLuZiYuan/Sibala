namespace Sibala;

public class Player
{
    public string Name { get; set; }
    public List<Dice> Dices { get; set; }

    public IEnumerable<Dice> GetDiceHands()
    {
        return new DiceHands(Dices.OrderByDescending(x => x.Value).ToList());
    }
}
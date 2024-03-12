namespace Sibala;

public class Player
{
    public string Name { get; set; }
    public List<Dice> Dices { get; set; }

    public DiceHands GetDiceHands()
    {
        return new DiceHands(Dices.OrderByDescending(x => x.Value).ToList());
    }
}
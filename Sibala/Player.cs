namespace Sibala;

public class Player
{
    public string Name { get; set; }
    public List<Dice> Dices { get; set; }

    public List<Dice> GetDiceHands()
    {
        return Dices.OrderByDescending(x => x.Value).ToList();
    }
}
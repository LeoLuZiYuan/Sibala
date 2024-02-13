namespace Sibala;

public class Parser
{
    public List<Player> Parse(string input)
    {
        var section = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);

        return new List<Player>
        {
            GetPlayer(section, 0),
            GetPlayer(section, 1)
        };
    }

    private Player GetPlayer(string[] section, int index)
    {
        var player = section[index].Split(":", StringSplitOptions.RemoveEmptyEntries).First();

        var dices = section[index].Split(":", StringSplitOptions.RemoveEmptyEntries)[1]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => new Dice { Output = x, Value = int.Parse(x) }).ToList();

        return new Player
        {
            Name = player,
            Dices = dices
        };
    }
}
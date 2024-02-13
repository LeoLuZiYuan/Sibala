using System.Numerics;

namespace Sibala;

public class Parser
{
    public IList<Player> Parse(string input)
    {
        //Black:5 3 5 4  White:2 6 2 3
        var section = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);
        var player1 = section[0].Split(":", StringSplitOptions.RemoveEmptyEntries).First();
        var player2 = section[1].Split(":", StringSplitOptions.RemoveEmptyEntries).First();

        return new List<Player>  
        {
            new Player
            {
                Name = player1
            },
            new Player
            {
                Name = player2
            }
        };
    }
}
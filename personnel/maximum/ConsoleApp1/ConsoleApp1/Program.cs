// 4 players
List<Player> players = new List<Player>()
{
    new Player("Joe", 32),
    new Player("Jack", 30),
    new Player("William", 37),
    new Player("Averell", 25)
};

// Initialize search

//Immutable
if (players[0].Age > players[1].Age && players[0].Age > players[2].Age && players[0].Age > players[3].Age)
{
    Player elder = players[0];
    Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");
}
else if (players[1].Age > players[0].Age && players[1].Age > players[2].Age && players[1].Age > players[3].Age)
{
    Player elder = players[1];
    Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");
}
else if (players[2].Age > players[1].Age && players[2].Age > players[0].Age && players[2].Age > players[3].Age)
{
    Player elder = players[2];
    Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");
} else
{
    Player elder = players[3];
    Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");
}

/* Mutable
foreach (Player p in players)
{
    if (p.Age > biggestAge) // memorize new elder
    {
        elder = p;
        biggestAge = p.Age; // for future loops
    }
}*/



Console.ReadKey();

public class Player
{
    private readonly string _name;
    private readonly int _age;

    public Player(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public string Name => _name;

    public int Age => _age;
}
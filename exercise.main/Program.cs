// See https://aka.ms/new-console-template for more information
using exercise.main.Poker;

Console.WriteLine("Press enter to continue the poker simulation");

Console.ReadLine();

bool goOn = true;

while (goOn)
{
    PokerGame pokerGame = new PokerGame(); // Texas hold'em

    Player player3 = new Player("Hans"); //two players join automatically, we add a third.

    pokerGame.JoinGame(player3);

    Console.Write("The players ");
    foreach (Player p in pokerGame.Players)
    {
        if (!pokerGame.Players.First().Equals(p))
        {
            Console.Write(", ");
        }
        if (pokerGame.Players.Last().Equals(p))
        {
            Console.WriteLine("and ");
        }

        Console.Write("+" + p.Name + "+");
    }
    Console.WriteLine(" joined the dealer for a game of poker.");

    Console.ReadLine();

    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("Each player is dealt two cards.");
    foreach (var player in pokerGame.Players) //each player gets two cards to start with
    {
        pokerGame.DealPlayer(player);
        pokerGame.DealPlayer(player);
    }

    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("The table recieves three cards.");
    Console.ReadLine();

    pokerGame.DealTable();
    pokerGame.DealTable();
    pokerGame.DealTable();

    Console.WriteLine();

    Random random = new Random();
    List<Tuple<Player, List<Card>>> results = new List<Tuple<Player, List<Card>>>();

    int randomNumber = random.Next(6);
    if (randomNumber == 0)
    {
        results = pokerGame.GetResults();
        var worstHand = results.Last();
        pokerGame.Players.Remove(worstHand.Item1);
        Console.WriteLine($"{worstHand.Item1.Name} folds (bad hand?).");
        Console.ReadLine();
    }
    Console.WriteLine("The table recieves another card");
    Console.ReadLine();
    pokerGame.DealTable();

    randomNumber = random.Next(4);
    if (randomNumber == 0)
    {

        results = pokerGame.GetResults();
        var worstHand = results.Last();
        pokerGame.Players.Remove(worstHand.Item1);
        Console.WriteLine($"{worstHand.Item1.Name} folds (bad hand?).");
        Console.ReadLine();
    }
    Console.WriteLine("The table recieves another card");
    Console.ReadLine();
    pokerGame.DealTable();

    randomNumber = random.Next(2);
    if (randomNumber == 0)
    {

        results = pokerGame.GetResults();
        var worstHand = results.Last();
        pokerGame.Players.Remove(worstHand.Item1);
        Console.WriteLine($"{worstHand.Item1.Name} folds (bad hand?).");
        Console.ReadLine();
    }
    Console.WriteLine("The table recieves another card");
    Console.ReadLine();
    pokerGame.DealTable();

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Show your hands players");
    Console.ReadLine();
    Console.WriteLine();

    results = pokerGame.GetResults();

    int numOfDupes = results.First().Item2.Count;
    Dictionary<int, string> handType = new Dictionary<int, string>()
    {
        {1, "high card"},
        {2, "two of a kind" },
        {3, "three of a kind" },
        {4, "four of a kind"}
    };

    Console.WriteLine(results[0].Item1.Name + $" won the round with {handType[numOfDupes]}");
    foreach (Card c in results[0].Item2)
    {
        Console.WriteLine($"[{c.Value} of {c.Suit}] ");
    }

    results.RemoveAt(0);

    Console.WriteLine("Against ");

    if (results.Count == 0)
    {
        Console.WriteLine("*crickets*");
    }

    foreach (Tuple<Player, List<Card>> t in results)
    {
        numOfDupes = t.Item2.Count;
        Console.WriteLine(t.Item1.Name + $"'s {handType[numOfDupes]} ");
        foreach (Card c in t.Item2)
        {
            Console.WriteLine($"[{c.Value} of {c.Suit}] ");
        }
    }

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Press enter to start a new simulation, or q to quit");



    string? input = Console.ReadLine();

    if ( input == "q" )
    {
        goOn = false;
    }
}


// See https://aka.ms/new-console-template for more information
using exercise.main.Poker;

PokerGame pokerGame = new PokerGame(); // Texas hold'em

Player player3 = new Player("Hans"); //two players join automatically, we add a third.

pokerGame.JoinGame(player3);


foreach (var player in pokerGame.Players) //each player gets two cards to start with
{
    pokerGame.DealPlayer(player);
    pokerGame.DealPlayer(player);
}

for (int i = 0; i < 4; i++) //add 5 cards to the table
{
    pokerGame.DealTable();
}

var results = pokerGame.GetResults();

int numOfDupes = results[0].Item2.Count;
Dictionary<int, string> handType = new Dictionary<int, string>()
{
    {1, "high card"},
    {2, "pair" },
    {3, "trifecta" },
    {4, "quadlecta"}
};

Console.WriteLine(results[0].Item1.Name + $" won the round with the {handType[numOfDupes]}");
foreach(Card c in results[0].Item2)
{
    Console.WriteLine($"{c.Value} of {c.Suit} ");
}

results.RemoveAt(0);

Console.WriteLine("Against ");
foreach (Tuple<Player, List<Card>> t in results)
{
    numOfDupes = t.Item2.Count;
    Console.WriteLine(t.Item1.Name + $"'s {handType[numOfDupes]} ");
    foreach (Card c in t.Item2)
    {
        Console.WriteLine($"{c.Value} of {c.Suit} ");
    }
}



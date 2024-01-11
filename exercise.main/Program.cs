using exercise.main;

PokerGame pokerGame = new PokerGame();
List<Card> deck = new List<Card>();
Deck.refreshDeck(deck);
Console.WriteLine("Welcome to Poker! Press 'ENTER' to start.");
if (Console.ReadKey().Key.ToString() == "Enter")
{
    Console.WriteLine("How many players are playing?");
    int.TryParse(Console.ReadLine(), out int playeramount);
    for (int i = 0; i < playeramount; i++)
    {
        Player player = new Player();
        pokerGame.RegisterPlayer(player, i);
        if (Console.ReadKey().Key.ToString() == "Enter")
        {

        }
    }
        pokerGame.PlayerTurn(deck);

}
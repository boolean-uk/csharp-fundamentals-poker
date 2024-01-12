// See https://aka.ms/new-console-template for more information
using exercise.main.Game;

while (true) { 
    Console.WriteLine("STARTING POKER GAME");

    Deck deck = new Deck();
    deck.Shuffle();

    PokerGame game = new PokerGame();
    game.setTable();

    game.playGame();

    Console.WriteLine("If you wish to play again write 'yes'. Write anything else to stop wasting your money.");
    string input = Console.ReadLine();
    if (! (input == "yes")) 
    {
        break;
    }
    Console.Clear();
}
Console.WriteLine("Thanks for playing, goodbye.");
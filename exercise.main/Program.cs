
using exercise.main;

Console.WriteLine("Enter the name of Player 1: ");
string player1 = Console.ReadLine();
Console.WriteLine("Enter the name of Player 2: ");
string player2 = Console.ReadLine();
Console.WriteLine();
PokerGame game = new PokerGame(player1, player2);

while (true)
{
    game.startGame();
    Console.WriteLine();
    Console.WriteLine("Play again? (anything/n)");
    if (Console.ReadLine() == "n")
    {
        break;
    }

    Console.Clear();
}

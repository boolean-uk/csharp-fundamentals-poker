// See https://aka.ms/new-console-template for more information

using exercise.main;

Console.WriteLine("Enter player 1 name: ");
string player1Name = Console.ReadLine();

Console.WriteLine("Enter player 2 name: ");
string player2Name = Console.ReadLine();

PokerGame pokerGame = new PokerGame(player1Name, player2Name);



bool running = true;
while(running)
{
    Console.WriteLine("Would you like to play a game of texas hold 'em?\nPress ENTER to deal or enter 'no' to exit!");
    string answer = Console.ReadLine();
    if(answer == "no")
    {
        running = false; 
        break;
    }

    pokerGame.RunAGame();
}
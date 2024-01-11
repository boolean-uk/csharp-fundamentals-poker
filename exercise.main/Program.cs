// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Poker time!");

Console.WriteLine("Enter name of Player 1:");
string player1 = Console.ReadLine();
Console.WriteLine("Enter name of Player 2:");
string player2 = Console.ReadLine();

PokerGame game = new PokerGame(player1, player2);

string input = "";
while (input != "q")
{
    Console.WriteLine("Enter command: ");
    input = Console.ReadLine();
    switch (input){
        case "c": game.NextTurn(); break; 
        case "h": Console.WriteLine("Help"); break;
        default: break;
    }
}


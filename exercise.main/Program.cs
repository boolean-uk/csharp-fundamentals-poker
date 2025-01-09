// See https://aka.ms/new-console-template for more information
using exercise.main.UngradedExtension;

Console.WriteLine("Hello, World!");


PokerGame game = new PokerGame("Nigel", "AJ");

game.Start();
game.PrintGameStatus();
game.playTurn();

game.playTurn();

Console.WriteLine("Game over");

game.PrintGameStatus();



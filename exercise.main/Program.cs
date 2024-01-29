// See https://aka.ms/new-console-template for more information
using exercise.main.Objects;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// --INTRO--
Console.Write("Welcome ");
Console.Beep(100, 800);
Console.Write("to ");
Console.Beep(120, 800);
Console.Write("the ");
Console.Beep(140, 800);
Console.Write("best ");
Console.Beep(160, 800);
Console.Write("Poker Game!\n\n");
Console.Beep(200, 200);
Console.Beep(200, 200);


// --START GAME--
PokerGame pokerGame = new PokerGame();

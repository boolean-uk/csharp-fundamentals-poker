// See https://aka.ms/new-console-template for more information
using exercise.main.Objects;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int[] listOfItems = new[] { 4, 2, 3, 1, 6, 4, 3 };
var duplicates = listOfItems
    .GroupBy(i => i)
    .Where(g => g.Count() > 1)
    .Select(g => g.Key);
foreach (var d in duplicates)
    Console.WriteLine(d); // 4,3


// Intro
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


// Start game
PokerGame pokerGame = new PokerGame();

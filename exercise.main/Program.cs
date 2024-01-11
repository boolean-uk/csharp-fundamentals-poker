// See https://aka.ms/new-console-template for more information
using exercise.main;
using exercise.main.Poker;
WinningHands winningHands = new();
List<Card> cards = new()
{
    new Card("K", "Spades"),
    new Card("K", "Hearts"),
    new Card("K", "Spades")
};
Console.WriteLine(winningHands.IterateWinConditions(cards));
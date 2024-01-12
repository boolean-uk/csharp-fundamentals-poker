// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");


Deck deck = new Deck();
Player player1 = new Player("Oneal");

deck.Shuffle();

player1.AddCard(deck.Deal());
player1.AddCard(deck.Deal());

Console.WriteLine(player1._name + " has the hand: ");
foreach(Card c in player1.ShowHand())
{
   Console.WriteLine(c._suit + " " + c._value);
}

player1.RemoveCards();

foreach (Card c in player1.ShowHand())
{
    Console.WriteLine(c._suit + " " + c._value);
}

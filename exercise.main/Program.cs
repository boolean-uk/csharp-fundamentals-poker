// See https://aka.ms/new-console-template for more information
using exercise.main;

Core core = new Core();
foreach (var card in core.Deck)
{
    Console.WriteLine(card.getAbbreviation());
}
Console.WriteLine($"Amount of cards: {core.Deck.Count}");

Random random = new Random();

//Card card1 = core.drawCard();
//Card card2 = core.drawCard();


//Console.WriteLine($"Card 1 {card1.getAbbreviation()}");
//Console.WriteLine($"Card 2: {card2.getAbbreviation()}");

Console.WriteLine($"Amount of cards: {core.Deck.Count}");
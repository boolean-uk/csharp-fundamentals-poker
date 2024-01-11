// See https://aka.ms/new-console-template for more information
using exercise.main;
using System.Reflection;

Core core = new Core();
//foreach (var card in core.Deck)
//{
//    Console.WriteLine(card.getAbbreviation());
//}
//Console.WriteLine($"Amount of cards: {core.Deck.Count}");



List<Tuple<string, string>> hand = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("K", "5"),
            new Tuple<string, string>("2","2")
        };
Tuple<string, string> winner;
bool result = core.winningPair(hand, out winner);

Console.WriteLine(result);
Console.WriteLine(winner.Item1+" "+winner.Item2);
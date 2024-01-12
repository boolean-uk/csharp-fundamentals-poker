// See https://aka.ms/new-console-template for more information
using exercise.main;
using exercise.main.PokerGame;

Console.WriteLine("Hello, World!");



List<Card> cards = new List<Card>()
{
    new Card("4", "heart"),
    new Card("10", "spade"),
    new Card("8", "heart"),
    new Card("2", "spade")
};

PokerGame p = new PokerGame();

/*
List<Tuple<string, string>> hand = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("4", "3"),
            new Tuple<string, string>("6", "6"),
            new Tuple<string, string>("7", "7"),
            new Tuple<string, string>("3","3")
        };
Tuple<string, string> winner;
Core core = new Core();
bool res = core.winningPair(hand, out winner);
Console.WriteLine(res);
*/


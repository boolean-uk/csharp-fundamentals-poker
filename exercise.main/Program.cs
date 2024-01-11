
using exercise.main;

internal class Program
{
    private static void Main(string[] args)
    {
        PlayGame();
    }

    private static void PlayGame()
    {
        PokerGame pokerGame = new PokerGame();
        pokerGame.StartNewGame();
        Console.WriteLine("Starting a new game...");

        Console.WriteLine("Dealing first card to players...");
        pokerGame.Progress();
        printHand(pokerGame.p1.name, pokerGame.p1.GetCards());
        printHand(pokerGame.p2.name, pokerGame.p2.GetCards());

        Console.WriteLine("===============================");

        Console.WriteLine("Dealing second card to players...");
        pokerGame.Progress();
        printHand(pokerGame.p1.name, pokerGame.p1.GetCards());
        printHand(pokerGame.p2.name, pokerGame.p2.GetCards());

        Console.WriteLine("===============================");

        Console.WriteLine("Dealing first three cards to table...");
        pokerGame.Progress();
        printTable(pokerGame.cardsOnTable);

        Console.WriteLine("===============================");

        Console.WriteLine("Dealing fourth card to table...");
        pokerGame.Progress();
        printTable(pokerGame.cardsOnTable);

        Console.WriteLine("===============================");

        Console.WriteLine("Dealing fifth card to table...");
        pokerGame.Progress();
        printTable(pokerGame.cardsOnTable);

        Console.WriteLine("===============================");

        Console.WriteLine("Checking win condition...");
        if (pokerGame.HasWon())
        {
            Console.WriteLine($"{pokerGame.winner.name} wins with cards:");
            printWinningHand(pokerGame.winningCards);
        }
        else
        {
            Console.WriteLine("No winner, starting a new round...\n\n");
            PlayGame();
        }

        Console.WriteLine("===============================");
    }

    private static void printHand(string name, List<Card> cards)
    {
        Console.WriteLine($"{name} hand:");
        foreach (var item in cards)
        {
            Console.WriteLine($"   - {item.value} of {item.suit}");
        }
    }

    private static void printTable(List<Card> cards)
    {
        Console.WriteLine("Table:");
        foreach (var item in cards)
        {
            Console.WriteLine($"   - {item.value} of {item.suit}");
        }
    }

    private static void printWinningHand(List<Card> cards)
    {
        foreach (var item in cards)
        {
            Console.WriteLine($"   - {item.value} of {item.suit}");
        }
    }
}
namespace exercise.main.Poker
{
    public class PokerGame
    {
        public readonly Player player1;
        public readonly Player player2;
        public readonly Deck deck;
        public readonly List<Card> tableCards;

        public PokerGame()
        {
            player1 = new Player("Player 1");
            player2 = new Player("Player 2");
            deck = new Deck();
            tableCards = new List<Card>();
        }

        public void StartGame()
        {
            deck.Shuffle();
            player1.ClearHand();
            player2.ClearHand();
            tableCards.Clear();

            player1.AddCardToHand(deck.Deal());
            player1.AddCardToHand(deck.Deal());
            player2.AddCardToHand(deck.Deal());
            player2.AddCardToHand(deck.Deal());

            tableCards.Add(deck.Deal());
            tableCards.Add(deck.Deal());
            tableCards.Add(deck.Deal());

            tableCards.Add(deck.Deal());
            tableCards.Add(deck.Deal());

            Console.WriteLine("Table cards:");
            foreach(var card in tableCards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
            Console.WriteLine("Player 1 has:");
            foreach(var card in player1.Hand)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
            Console.WriteLine("Player 2 has:");
            foreach(var card in player2.Hand)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }

            // TODO: Compute the winner of the round
            //Tbh i have no idea how to compute the winner, there are too many combinations and hands (onee pair, two pair, full hause etc)
        }
    }
}
namespace exercise.main
{
    public class PokerGame
    {
        public Player p1;
        public Player p2;
        private Deck deck;
        public List<Card> cardsOnTable;
        private int state;
        public Player winner;
        public List<Card> winningCards;

        public PokerGame()
        {
            p1 = new("Player 1");
            p2 = new("Player 2");
        }

        public PokerGame(string player1, string player2)
        {
            p1 = new(player1);
            p2 = new(player2);
        }
        public void StartNewGame()
        {
            p1.ClearHand();
            p2.ClearHand();
            deck = new(GenerateDeck());
            deck.Shuffle();
            state = 0;
            cardsOnTable = new List<Card>();
        }

        public void Progress()
        {
            if (state == 0 || state == 1) //Deal two cards to each player
            {
                p1.GiveCard(deck.Deal());
                p2.GiveCard(deck.Deal());
            }
            else if (state == 2) //Deal first 3 cards to table
            {
                cardsOnTable.Add(deck.Deal());
                cardsOnTable.Add(deck.Deal());
                cardsOnTable.Add(deck.Deal());
            }
            else if (state == 3 || state == 4) //Deal another two cards to table 
            {
                cardsOnTable.Add(deck.Deal());
            }
            state++;
            Thread.Sleep(1500); //Just to make the output more readable

        }

        public bool HasWon()
        {
            List<Card> player1 = [.. p1.GetCards(), .. cardsOnTable];
            List<Card> player2 = [.. p2.GetCards(), .. cardsOnTable];
            List<List<Card>> hands = [player1, player2];
            Core core = new Core();
            Dictionary<Player, List<Card>> strongestHand = new();

            Tuple<List<Card>, int> p1BestHand = getBestHand(player1);
            Tuple<List<Card>, int> p2BestHand = getBestHand(player2);
            if (p1BestHand.Item1.Count == p2BestHand.Item1.Count)
            {
                if (p1BestHand.Item2 == 0)
                {
                    return false;
                }
                if (p1BestHand.Item2 > p2BestHand.Item2)
                {
                    winner = p1;
                    winningCards = p1BestHand.Item1;
                }
                else
                {
                    winner = p2;
                    winningCards = p2BestHand.Item1;
                }
            }
            else if (p1BestHand.Item1.Count > p2BestHand.Item1.Count)
            {
                winner = p1;
                winningCards = p1BestHand.Item1;
            }
            else
            {
                winner = p2;
                winningCards = p2BestHand.Item1;
            }
            return true;
        }

        private Tuple<List<Card>, int> getBestHand(List<Card> hand)
        {
            Core core = new Core();
            Tuple<List<Card>, int> strongestHand = new Tuple<List<Card>, int>(new(), 0);

            for (int i = 0; i < hand.Count; i++)
            {
                for (int j = 0; j < hand.Count; j++)
                {
                    if (i == j) continue;
                    if (hand.Count > 2) //If 3 of a kind is possible
                    {
                        for (int k = 0; k < hand.Count; k++)
                        {
                            if (i == k || j == k) continue;
                            if (hand[i].value == hand[j].value && hand[j].value == hand[k].value)
                            {
                                int value = core.GetValueOfCard(hand[i].value) * 3;
                                if (strongestHand.Item2 == 0 || value > strongestHand.Item2)
                                {
                                    strongestHand = new Tuple<List<Card>, int>([hand[i], hand[j], hand[k]], value);
                                    continue;
                                }
                            }
                        }
                    }
                    if (strongestHand.Item2 == 0 || strongestHand.Item1.Count < 3)
                    {
                        if (hand[i].value == hand[j].value)
                        {
                            int value = core.GetValueOfCard(hand[i].value) * 3;
                            if (strongestHand.Item2 == 0 || value > strongestHand.Item2)
                            {
                                strongestHand = new Tuple<List<Card>, int>([hand[i], hand[j]], value);
                                continue;
                            }
                        }
                    }
                }
            }
            return strongestHand;
        }

        private List<Card> GenerateDeck()
        {
            List<string> values = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            List<string> suits = ["Clubs", "Diamonds", "Hearts", "Spades"];
            List<Card> cards = new List<Card>();
            foreach (string v in values)
            {
                foreach (string s in suits)
                {
                    cards.Add(new Card(v, s));
                }

            }
            return cards;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class PokerGame
    {
        private Player _player1;
        private Player _player2;
        private List<Card> _table;
        private Deck _deck;

        public PokerGame(string player1, string player2)
        {
            _player1 = new Player(player1);
            _player2 = new Player(player2);
            _table = new List<Card>();
            _deck = new Deck();
        }

        public Player Player1 { get { return _player1; } }
        public Player Player2 { get { return _player2; } }
        public List<Card> Table { get { return _table; } }

        public bool gameOver()
        {
            return Table.Count == 5;
        }

        public void addToHand(Player player)
        {
            for (int i = 0; i < 2; i++)
            {
                player.Add(_deck.Deal());
            }
        }

        public void dealToTable()
        {
            Card card = _deck.Deal();
            int counter = 0;
            foreach (Card c in Table)
            {
                if (card.ValueInt > c.ValueInt)
                {
                    counter++;
                }
            }
            _table.Insert(counter, card);
        }

        public void initGame()
        {
            addToHand(_player1);
            addToHand(_player2);

            for (int i = 0; i < 3; i++)
            {
                dealToTable();
            }
        }

        public bool isFlush(List<Card> cards, out Dictionary<string, int> suitCount)
        {
            suitCount = new Dictionary<string, int>();
            foreach (Card card in cards)
            {
                if (suitCount.TryGetValue(card.Suit, out int _))
                {
                    suitCount[card.Suit] += 1;
                }
                else
                {
                    suitCount.Add(card.Suit, 1);
                }
            }

            foreach (int count in suitCount.Values)
            {
                if (count >= 5) return true;
            }

            return false;
        }

        public bool isStraightFlush(List<Card> cards, Dictionary<string, int> suitCount)
        {
            List<int> cardValues = new List<int>();
            foreach (KeyValuePair<string, int> suit in suitCount)
            {
                if (suit.Value >= 5)
                {
                    foreach (Card card in cards)
                    {
                        cardValues.Add(card.ValueInt);
                    }
                }
            }

            cardValues.Order();
            int count = 1;
            for (int i = cardValues.Count - 1; i > 0; i--)
            {
                if (count == 5)
                {
                    break;
                }

                if (cardValues[i] == cardValues[i - 1] + 1)
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
            }

            return count == 5;
        }

        public bool fourOfAKind(List<Card> cards, out Dictionary<int, int> cardCount)
        {
            cardCount = new Dictionary<int, int>();
            foreach (Card card in cards)
            {
                if (cardCount.TryGetValue(card.ValueInt, out int _))
                {
                    cardCount[card.ValueInt] += 1;
                }
                else
                {
                    cardCount.Add(card.ValueInt, 1);
                }
            }

            foreach (int count in cardCount.Values)
            {
                if (count == 4) { return true; }
            }
            return false;
        }

        public bool threeOfAKind(List<Card> cards, Dictionary<int, int> cardCount)
        {
            foreach (int count in cardCount.Values)
            {
                if (count == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public bool fullHouse(List<Card> cards, Dictionary<int, int> cardCount)
        {
            if (threeOfAKind(cards, cardCount)) {
                foreach (int count in cardCount.Values)
                {
                    if (count == 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool straight(List<Card> cards)
        {
            List<int> cardValues = new List<int>();
            foreach(Card card in cards)
            {
                cardValues.Add(card.ValueInt);
            }

            cardValues.Order();
            int count = 1;

            for (int i = cardValues.Count - 1; i > 0; i--)
            {
                if (count == 5)
                {
                    break;
                }
                if (cardValues[i] == cardValues[i-1]+1)
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
            }

            return count == 5;
        }

        public int nrPairs(List<Card> cards, Dictionary<int, int> cardCount)
        {
            int nrPairs = 0;
            foreach (int count in cardCount.Values)
            {
                if (count == 2) {
                    nrPairs++;
                }
            }
            return nrPairs;
        }

        public string calcScore(Player player)
        {
            foreach (Card card in Table)
            {
                player.Hand.Add(card);
            }
            Dictionary<string, int> suitCount;

            bool flush = isFlush(player.Hand, out suitCount);
            if (flush)
            {
                if (isStraightFlush(player.Hand, suitCount))
                {
                    return "STRAIGHT-FLUSH";
                }
            }

            //Check four of a kind
            Dictionary<int, int> cardCount;
            if (fourOfAKind(player.Hand, out cardCount))
            {
                return "FOUR";
            }

            //Check full house
            if (fullHouse(player.Hand, cardCount))
            {
                return "FULL";
            }

            //If it was flush but not straight
            if (flush)
            {
                return "FLUSH";
            }

            //Check straight
            if (straight(player.Hand))
            {
                return "STRAIGHT";
            }

            //Check three of a kind
            if (threeOfAKind(player.Hand, cardCount))
            {
                return "THREE";
            }

            //Check two pairs
            int pairs = nrPairs(player.Hand, cardCount);
            if (pairs == 2)
            {
                return "TWO-PAIRS";
            }
            else if (pairs == 1)
            {
                return "PAIR";
            }
            else
            {
                return "HIGH";
            }
        }


        public string getWinner(string scorePlayer1, string scorePlayer2)
        {
            if (scorePlayer1 == scorePlayer2) { return "TIE"; }

            Dictionary<string, int> scores = new Dictionary<string, int>() {
                {"HIGH", 1}, {"PAIR", 2}, {"TWO-PAIRS", 3}, {"THREE", 4}, {"STRAIGHT", 5}, {"FLUSH", 6}, 
                {"FULL", 7}, {"FOUR", 8}, {"STRAIGHT-FLUSH", 9}
            };

            if (scores[scorePlayer1] > scores[scorePlayer2]) { return "PLAYER1"; }

            return "PLAYER2";
        }

        public string printTable()
        {
            string table  = "";

            foreach (Card card in Table)
            {
                string suit = "";
                if (card.Suit == "hearts") { suit = "H"; }
                else if (card.Suit == "spades") { suit = "S"; }
                else if (card.Suit == "diamonds") { suit = "D"; }
                else if (card.Suit == "clubs") { suit = "C"; }
                table += card.Value.ToString() + "-" + suit + ", ";
            }

            table = table.Trim();
            return table.Trim(',');
        }

        public void startGame()
        {
            initGame();
            Console.WriteLine($"{Player1.Name}'s hand: {Player1.printHand()}");
            Console.WriteLine($"{Player2.Name}'s hand: {Player2.printHand()}");
            Console.WriteLine($"Cards on the table: {printTable()}");
            Console.WriteLine();

            while (!gameOver())
            {
                dealToTable();
                Console.WriteLine($"New card added to table: {Table[Table.Count - 1].printCard()}");
                Console.WriteLine($"Current cards on the table: {printTable()}");
                Console.WriteLine();
            }

            string player1Score = calcScore(Player1);
            string player2Score = calcScore(Player2);

            string outcome = getWinner(player1Score, player2Score);
            string winner = "";
            if (outcome == "PLAYER1")
            {
                winner = Player1.Name;
            } 
            else if (outcome == "PLAYER2")
            {
                winner = Player2.Name;
            }
            else
            {
                winner = "nobody";
            }

            Console.WriteLine($"The winner of the game is {outcome}: {winner}");

            // Add royal flush
            // Print best hand (both if tie)
            // Add tie breaker
            // Add ability to play again and advance to next round
            // Add betting/calling/folding
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
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
        private int _betAmount;

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
        public int BetAmount {  get => _betAmount; set => _betAmount = value; }

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

        public int dealToTable()
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
            return counter;
        }

        public void initGame()
        {
            Player1.Clear();
            Player2.Clear();
            Table.Clear();
            _deck.Shuffle();
            BetAmount = -1;

            addToHand(Player1);
            addToHand(Player2);

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
                if (count >= 5) {
                    return true;
                }
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
                if (count == 3) { return true; }
            }
            return false;
        }

        public bool fullHouse(List<Card> cards, Dictionary<int, int> cardCount)
        {
            if (threeOfAKind(cards, cardCount)) {
                foreach (int count in cardCount.Values)
                {
                    if (count == 2) { return true; }
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
                if (count == 2) { nrPairs++; }
            }
            return nrPairs;
        }

        public Player getWinningCardsSuits(Dictionary<string, int> suitCount, List<Card> hand, int nrSuits)
        {
            Player winning = new Player("winning");
            foreach ((string suit, int count) in suitCount)
            {
                if (count >= nrSuits)
                {
                    foreach (Card card in hand.Where(c => c.Suit == suit))
                    {
                        winning.Add(card);
                    }
                }
            }
            while (winning.Hand.Count > 5)
            {
                winning.Hand.RemoveAt(0);
            }
            return winning;
        }

        public Player getWinningCardsCount(Dictionary<int, int> cardCount, List<Card> hand, int nrCards)
        {
            Player winning = new Player("winning");
            foreach ((int cardValue, int count) in cardCount)
            {
                if (count == nrCards)
                {
                    foreach (Card card in hand.Where(c => c.ValueInt == cardValue))
                    {
                        winning.Add(card);
                    }
                }
            }
            for (int i = hand.Count - 1; i >= 0; i--)
            {
                if (cardCount[hand[i].ValueInt] != nrCards)
                {
                    winning.Add(hand[i]);
                }
                if (winning.Hand.Count == 5)
                {
                    break;
                }
            }
            return winning;
        }

        public string calcScore(List<Card> hand, out Player winner)
        {
            foreach (Card card in Table)
            {
                hand.Add(card);
            }

            Dictionary<string, int> suitCount;

            bool flush = isFlush(hand, out suitCount);
            if (flush)
            {
                if (isStraightFlush(hand, suitCount))
                {
                    winner = getWinningCardsSuits(suitCount, hand, 5);

                    return (winner.Hand[winner.Hand.Count - 1].Value == "A") ? "Royal Flush" : "Straight Flush";
                }
            }

            //Check four of a kind
            Dictionary<int, int> cardCount;
            if (fourOfAKind(hand, out cardCount))
            {
                winner = getWinningCardsCount(cardCount, hand, 4);

                return "Four of a Kind";
            }

            //Check full house
            if (fullHouse(hand, cardCount))
            {
                winner = getWinningCardsCount(cardCount, hand, 3);
                Player winning2 = getWinningCardsCount(cardCount, hand, 2);

                foreach (Card card in winning2.Hand)
                {
                    winner.Add(card);
                }

                while (winner.Hand.Count > 5)
                {
                    winner.Hand.RemoveAt(0);
                }
                return "Full House";
            }

            //If it was flush but not straight
            if (flush)
            {
                winner = getWinningCardsSuits(suitCount, hand, 5);

                return "Flush";
            }

            //Check straight
            if (straight(hand))
            {
                winner = new Player("winner");

                for (int i = hand.Count - 1; i >= 0; i--) {
                    if (i > 0 && hand[i].ValueInt == hand[i-1].ValueInt+1)
                    {
                        winner.Add(hand[i]);
                    }
                    if (winner.Hand.Count == 5)
                    {
                        break;
                    }
                }
                if (winner.Hand.Count == 4)
                {
                    winner.Hand.Add(hand[0]);
                }
                return "Straight";
            }

            //Check three of a kind
            if (threeOfAKind(hand, cardCount))
            {
                winner = getWinningCardsCount(cardCount, hand, 3);

                return "Three of a Kind";
            }

            //Check two pairs
            int pairs = nrPairs(hand, cardCount);
            if (pairs == 2 || pairs ==1)
            {
                winner = getWinningCardsCount(cardCount, hand, 2);

                return (pairs == 2) ? "Two Pairs" : "One Pair";
            }
            else
            {
                winner = new Player("winner");
                for (int i = hand.Count - 1; i >= 0; i--)
                {
                    winner.Add(hand[i]);
                    if (winner.Hand.Count == 5)
                    {
                        break;
                    }
                }
                return "High Card";
            }
        }

        public string getWinner(string scorePlayer1, string scorePlayer2)
        {
            if (scorePlayer1 == scorePlayer2) { return "TIE"; }

            Dictionary<string, int> scores = new Dictionary<string, int>() {
                {"High Card", 1}, {"One Pair", 2}, {"Two Pairs", 3}, {"Three of a Kind", 4}, {"Straight", 5}, {"Flush", 6}, 
                {"Full House", 7}, {"Four of a Kind", 8}, {"Straight Flush", 9}
            };

            return (scores[scorePlayer1] > scores[scorePlayer2]) ? "Player 1" : "Player 2";
        }

        public Dictionary<int, int> getCardCount(List<Card> hand)
        {
            Dictionary<int, int> cardCountsP1 = new Dictionary<int, int>();
            foreach (Card card in hand)
            {
                if (cardCountsP1.ContainsKey(card.ValueInt))
                {
                    cardCountsP1[card.ValueInt] += 1;
                }
                else
                {
                    cardCountsP1.Add(card.ValueInt, 1);
                }
            }
            return cardCountsP1;
        }

        public string highCard(List<Card> hand1, List<Card> hand2)
        {
            for (int i = hand1.Count - 1; i >= 0; i--)
            {
                if (hand1[i].ValueInt != hand2[i].ValueInt)
                {
                    return hand1[i].ValueInt > hand2[i].ValueInt ? "Player 1" : "Player 2";
                }
            }
            return "Tie";
        }

        public string tieBreaker(string score, Player player1, Player player2)
        {
            return highCard(player1.Hand, player2.Hand);
        }

        public string printCards(List<Card> cards)
        {
            string cardString  = "";

            foreach (Card card in cards)
            {
                cardString += card.Value + "-" + card.Suit + ", ";
            }

            cardString = cardString.Trim();
            return cardString.Trim(',');
        }

        public void printWinner()
        {
            Player player1Hand;
            Player player2Hand;
            string player1Score = calcScore(Player1.Hand, out player1Hand);
            string player2Score = calcScore(Player2.Hand, out player2Hand);

            string outcome = getWinner(player1Score, player2Score);
            string winner = "";

            if (outcome == "Tie")
            {
                outcome = tieBreaker(player1Score, player1Hand, player2Hand);
            }

            if (outcome == "Player 1")
            {
                winner = Player1.Name;
            }
            else if (outcome == "Player 2")
            {
                winner = Player2.Name;
            }

            if (Player1.Folded)
            {
                Console.WriteLine($"The winner of the game is {Player2.Name}: {Player1.Name} folded");
                Console.WriteLine();
                Console.WriteLine($"{Player2.Name} had {player2Score} with: {printCards(player2Hand.Hand)}");
                Console.WriteLine($"{Player1.Name}'s had {player1Score} with: {printCards(player1Hand.Hand)}");
                Player1.Folded = false;
            }
            else if (Player2.Folded)
            {
                Console.WriteLine($"The winner of the game is {Player1.Name}: {Player2.Name} folded");
                Console.WriteLine();
                Console.WriteLine($"{Player2.Name} had {player2Score} with: {printCards(player2Hand.Hand)}");
                Console.WriteLine($"{Player1.Name} had {player1Score} with: {printCards(player1Hand.Hand)}");
                Player2.Folded = false;
            }
            else
            {

                Console.WriteLine($"The winner of the game is {outcome}: {winner}");
                Console.WriteLine();
                if (winner == Player1.Name)
                {
                    Console.WriteLine($"Won with {player1Score}: {printCards(player1Hand.Hand)}");
                    Console.WriteLine($"Lost with {player2Score}: {printCards(player2Hand.Hand)}");
                    Player1.Money += BetAmount;
                    Player2.Money -= BetAmount;
                    Console.WriteLine();
                    Console.WriteLine($"{winner} won £{BetAmount}. New total is £{Player1.Money}");
                    Console.WriteLine($"{Player2.Name} lost £{BetAmount}. New total is £{Player2.Money}");
                }
                else if (winner == Player2.Name)
                {
                    Console.WriteLine($"Won with hand {player2Score}: {printCards(player2Hand.Hand)}");
                    Console.WriteLine($"With with hand {player1Score}: {printCards(player1Hand.Hand)}");
                    Player1.Money -= BetAmount;
                    Player2.Money += BetAmount;
                    Console.WriteLine();
                    Console.WriteLine($"{winner} won £{BetAmount}. New total is £{Player2.Money}");
                    Console.WriteLine($"{Player1.Name} lost £{BetAmount}. New total is £{Player1.Money}");
                }
                else
                {
                    Console.WriteLine($"{Player1.Name} had {player2Score}: {printCards(player2Hand.Hand)}");
                    Console.WriteLine($"{Player2.Name} had {player1Score}: {printCards(player1Hand.Hand)}");
                }
            }
        }

        public void bettingRound()
        {
            List<Player> players = new List<Player>() { Player1, Player2 };
            bool bettingOver = false;
            Player player = players.First();

            while(!bettingOver) {
                bool success = false;
                int playerBet = 0;
                Console.WriteLine($"{player.Name} has £{player.Money}");

                while (!success) 
                {
                    Console.WriteLine($"Enter bet amount for {player.Name}: ");
                    success = int.TryParse(Console.ReadLine(), out playerBet);
                    if(!success)
                    {
                        Console.WriteLine("Invalid bet value");
                    }
                    if (success)
                    {
                        if (playerBet < BetAmount)
                        {
                            Console.WriteLine($"Bet is too low, please bet at least £{BetAmount}");
                            success = false;
                            Console.WriteLine();
                        } 
                        else if (playerBet > player.Money)
                        {
                            Console.WriteLine($"{player.Name} does not have enough money!");
                            Console.WriteLine();
                            if (playerBet > player.Money && BetAmount > player.Money)
                            {
                                Console.WriteLine($"{player.Name} has folded this round");
                                BetAmount = 0;
                                player.Folded = true;
                                bettingOver = true;
                            }
                        }
                        else if (playerBet > BetAmount) 
                        {
                            Console.WriteLine($"Minimum bet changed to £{playerBet}");
                            BetAmount = playerBet;
                            Console.WriteLine();
                            player = players.Where(p => p.Name != player.Name).First();
                        }
                        else if (playerBet == BetAmount)
                        {
                            Console.WriteLine();
                            bettingOver = true;
                        }
                    }
                }
            }
        }

        public void startGame()
        {
            initGame();
            Console.Clear();
            Console.WriteLine($"{Player1.Name}'s hand: {printCards(Player1.Hand)}");
            Console.WriteLine($"{Player2.Name}'s hand: {printCards(Player2.Hand)}");
            Console.WriteLine($"Cards on the table: {printCards(Table)}");
            Console.WriteLine();
            bettingRound();

            while (!gameOver())
            {
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Console.Clear();
                int index = dealToTable();
                Console.WriteLine($"New card added to table: {Table[index].Value}-{Table[index].Suit}");
                Console.WriteLine($"Current cards on the table: {printCards(Table)}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any button to continue");
            Console.ReadLine();
            Console.Clear();

            printWinner();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    internal class PokerGame
    {
        private List<Player> _players = new List<Player>();
        private Deck _deck = new Deck();
        private List<Card> _board = new List<Card>();

        public List<Player> Players { get { return _players; } }
        public Deck Deck { get { return _deck; } }
        public List<Card> Board { get { return _board; } }

        public PokerGame(string p1, string p2)
        {
            //add players to player class
            Player player = new Player(p1);
            AddPlayer(player);
            player = new Player(p2);
            AddPlayer(player);

            _deck = new Deck();
        }

        private void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void NextTurn()
        {
            //check board state and act accordingly
            switch (_board.Count)
            {
                case 0: NewBoard(); break;
                case 5: ClearBoard(); NewBoard(); break;
                default: RevealCard(); break;
            }
            BoardState();
        }

        
        private void NewBoard()
        {
            
            foreach (Player player in _players)
            {
                player.Draw(_deck.Deal());
                player.Draw(_deck.Deal());
            }
            _board.Add(_deck.Deal());
            _board.Add(_deck.Deal());
            _board.Add(_deck.Deal());
        }

        //clears board, and hands and shuffles cards back into deck
        private void ClearBoard()
        {
            _board.Clear();
            foreach (Player player in _players)
            {
                player.EmptyHand();
            }
            _deck.RegenerateDeck();
        }

        //add a card to deck
        private void RevealCard()
        {
            _board.Add(_deck.Deal());
        }

        private void BoardState()
        {
            //print the player's card
            foreach (Player player in _players)
            {
                Console.WriteLine($"{player.Name} hand:");
                foreach (Card card in player.Hand)
                {
                    card.PrintCard();
                }
                Console.WriteLine();
            }

            //print the board
            Console.WriteLine("Board:");
            foreach (Card card in _board)
            {
                card.PrintCard();
            }
            Console.WriteLine();

            //print the current winner
            var winningHand = FindWinningHand();
            if (winningHand.Item1 != null)
            {
                if (_board.Count == 5)
                {
                    Console.WriteLine($"Winner is: {winningHand.Item1.Name} with a {winningHand.Item3}");
                }
                else
                {
                    Console.WriteLine($"With the current board state, the winner is: {winningHand.Item1.Name} with a {winningHand.Item3}");
                }
                foreach (Card card in winningHand.Item2)
                {
                    card.PrintCard();
                }
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            
            Console.WriteLine();
        }
        
        //returns the best hand together with its value and owner
        //still doesn't account for draws TODO: Move into player class
        private (Player, List<Card>, int) FindWinningHand()
        {
            Player winner = null;
            List<Card> hand = new List<Card>();
            int handscore = 0; 
            foreach (Player player in _players)
            {
                //Combines player and board cards into one hand
                List<Card> sortedHand = player.Hand.Union(Board).OrderByDescending(c => c.ParseValue()).ToList();
                
                
                int newScore = StraightFlush(sortedHand.ToList());
                if(newScore > handscore) {  handscore = newScore; winner = player; continue; }
                newScore = FourOfAKind(sortedHand.ToList());
                if (newScore > handscore) { handscore = newScore; winner = player; continue; }
                newScore = House(sortedHand.ToList());
                if (newScore > handscore) { handscore = newScore; winner = player; continue; }
                newScore = Flush(sortedHand.ToList());
                if (newScore > handscore) { handscore = newScore; winner = player; continue; }
                newScore = Straight(sortedHand.ToList());
                if (newScore > handscore) { handscore = newScore; winner = player; continue; }
                newScore = ThreeOfAKind(sortedHand.ToList());
                if (newScore > handscore) { handscore = newScore; winner = player; continue; }
                newScore = TwoOfAKind(sortedHand.ToList());
                if (newScore > handscore) { handscore = newScore; winner = player; continue; }
                newScore = HighestCard(sortedHand.ToList());
                if (newScore > handscore) { handscore = newScore; winner = player; continue; }


            }
            return (winner, hand, handscore);
        }


        //checks if 5 cards in a given hand have the same suit 
        private bool IsFlush(List<Card> cards)
        {

            for (int i = 0; i < 4; i++)
            {
                int count = 0;
                string suit = "";
                switch (i) {
                    case 0: suit = "S"; break;
                    case 1: suit = "C"; break;
                    case 2: suit = "H"; break;
                    case 3: suit = "D"; break;
                }
                
                foreach (Card card in cards)
                {
                    if (card.Suit == suit)
                    {
                        count++;
                    }
                }
                if (count >= 5) { return true; }
            }
            return false;
        }

        //Check if list contains 5 cards in decending order and returns it
        private List<Card> FindStraight (List<Card> cards)
        {
            
            int chain = 0;
            for (int i = 0; i < cards.Count-5; i++)
            {
                if (cards[i].ParseValue() == cards[i+1].ParseValue()-1) 
                { 
                    chain++;
                }
                else if (cards[i].ParseValue() != cards[i+1].ParseValue())
                {
                    chain = 0;
                }

                if (chain >= 4)
                {
                    return cards[(i - 5)..i];
                }
                
            }
            cards.Clear();
            return cards;
        }

        //All functions to calculate who has the better hand, they return an int indication the score of given hand
        #region Combination Functions

        
        private int StraightFlush(List<Card> hand)
        {
            if (IsFlush(hand)) 
            {
                List<Card> straight = FindStraight(hand);
                if (straight.Count() != 0)
                {
                    return 10000 + straight.First().ParseValue(); 
                }
            }
            return 0;
        }

        private int FourOfAKind(List<Card> hand)
        {
            
            List<Card> group = hand.GroupBy(c => c.Value).Where(g => g.Count() > 3).SelectMany(g => g).ToList();
            if (group.Count() > 0)
            {
                return 8000 + group.First().ParseValue();
            }

            return 0;
        }

        private int House(List<Card> hand)
        {
            List<Card> triple = hand.GroupBy(c => c.Value).Where(g => g.Count() > 2).SelectMany(g => g).ToList();
            if (triple.Count == 0) { return 0; }
            List<Card> pair = hand.Except(triple).ToList().GroupBy(c => c.Value).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
            if (pair.Count == 0) { return 0; }
            else
            {
                return 7000 + triple.First().ParseValue() * 20 + pair.First().ParseValue();
            }
        }

        private int Flush(List<Card> hand)
        {
            if (IsFlush(hand)) { return 6000; }
            return 0;
        }

        private int Straight(List<Card> hand)
        {
            List<Card> straight = FindStraight(hand);
            if (straight.Count == 0) { return 0; }
            else
            {
                return 5000 + straight.First().ParseValue();
            }
        }

        private int ThreeOfAKind(List<Card> hand)
        {
            List<Card> temp = hand;
            List<Card> triple = temp.GroupBy(c => c.Value).Where(g => g.Count() > 2).SelectMany(g => g).ToList();
            if (triple.Count == 0) { return 0; }
            else 
            {
                return 4000 + triple.First().ParseValue();
            }
        }

        private int TwoPairs(List<Card> hand)
        {
            List<Card> temp = hand;
            List<Card> pair = temp.GroupBy(c => c.Value).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
            if (pair.Count == 4)
            {
                return 3000 + pair.First().ParseValue();
            }
            else { return 0; }
        }


        private int TwoOfAKind(List<Card> hand)
        {
            List<Card> pair = hand.GroupBy(c => c.Value).Where(g => g.Count() > 1).SelectMany(g => g).ToList();
            if (pair.Count == 4)
            {
                return 3000 + pair.First().ParseValue();
            }
            else if (pair.Count == 2)
            {
                return 2000 + pair.First().ParseValue();
            }
            return 0;
        }

        
        private int HighestCard(List<Card> hand)
        {
            return hand.First().ParseValue();
            //return 0;
        }
        

        #endregion
    }
}

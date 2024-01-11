using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class PokerGame
    {
        protected List<Player> _players = new List<Player>();
        protected Player _board = new Player("the board");
        protected Deck _deck = new Deck();
        private bool _hasGameEnded = false;

        public bool HasGameEnded {  get => _hasGameEnded; }
        int _currentPlayerID = 0;
        int _currentRound = 1;
        bool _progressRoundBuffer = false;

        public PokerGame()
        {
            // --INTRODUCTION--
            // Ask for the players names
            string playerName;
            Console.WriteLine("Player 1, enter your name: ");
            playerName = Console.ReadLine();
            _players.Add(new Player(playerName));
            Console.Write("\n");
            Console.Beep(160, 200);

            Console.WriteLine("Player 2, enter your name: ");
            playerName = Console.ReadLine();
            _players.Add(new Player(playerName));
            Console.Beep(200, 200);

            Console.Clear();

            // --SETUP GAME--
            // Create deck
            _deck.Shuffle();
            // Add cards to the board
            for(int i = 0; i < 2; i++)
                _board.DrawCard(_deck.Deal());
            // Give players cards
            foreach(Player p in _players)
            {
                for (int i = 0; i < 2; i++)
                    p.DrawCard(_deck.Deal());
            }

            // --GAME LOOP--
            while (!HasGameEnded)
            {
                _progressRoundBuffer = false;

                PlayTurn(_players[0]);
                Console.Beep(160 , 200);
                PlayTurn(_players[1]);
                Console.Beep(200, 200);

                _board.DrawCard(_deck.Deal());

                Thread.Sleep(100);
                for(int i = 0; i < 3; i++)
                    Console.Beep(100, 80);

                if (_currentRound < 4)
                    _currentRound++;
                else
                {
                    ResolveGame();
                    EndGame();
                }
            }
        }

        private void PlayTurn(Player player)
        {
            Console.Clear();

            Console.WriteLine($"| {player.Name}'s turn - Round {_currentRound} |\n");
            Console.WriteLine($"Cards on the board:");
            _board.ShowCards();
            Console.Write("\n\n");

            Console.WriteLine($"Your hand:");
            player.ShowCards();
            Console.Write("\n\n");
            Console.WriteLine($"Choose to |bet|, |raise| or |stand|");
            Console.Write("Decide to: ");

            // Player Choice 
            string playerChoice = Console.ReadLine();
        }

        private void ResolveGame()
        {

        }

        private int Score(Player player)
        {
            List<Card> totalCards = new List<Card>();
            totalCards.AddRange(_deck.CardsInDeck);
            totalCards.AddRange(player.CardsInHand);

            // COMPARE
            // Royal Flush
            if (RoyalFlush(totalCards))
                return 100;
            // Straight Flush
            if (StraightFlush(totalCards))
                return 100;
            // Four of a Kind
            if (FourOfAKind(totalCards))
                return 100;
            // Full House
            if (FullHouse(totalCards))
                return 100;
            // Flush
            if (Flush(totalCards))
                return 100;
            // Straight
            if (Straight(totalCards))
                return 100;
            // Three of a Kind
            if (ThreeOfAKind(totalCards))
                return 100;
            // Two Pair
            if (TwoOfAPair(totalCards))
                return 20;

            // HighestCard
            return HighestCard(totalCards);
        }

        private int HighestCard(List<Card> totalCards)
        {
            int highestCard = totalCards.First().Value;
            foreach (Card card in totalCards)
            {
                if (card == totalCards.First())
                    continue;

                if(card.Value > highestCard)
                    highestCard = card.Value;
            }

            return highestCard;
        }

        private bool TwoOfAPair(List<Card> totalCards)
        {
            if (totalCards.Count != totalCards.Distinct().Count())
                return true;
            
            return false;
        }

        private bool ThreeOfAKind(List<Card> totalCards)
        {
            throw new NotImplementedException();
        }

        private bool Straight(List<Card> totalCards)
        {
            throw new NotImplementedException();
        }

        private bool Flush(List<Card> totalCards)
        {
            throw new NotImplementedException();
        }

        private bool FullHouse(List<Card> totalCards)
        {
            throw new NotImplementedException();
        }

        private bool FourOfAKind(List<Card> totalCards)
        {
            throw new NotImplementedException();
        }

        private bool StraightFlush(List<Card> totalCards)
        {
            throw new NotImplementedException();
        }


        private bool RoyalFlush(List<Card> totalCards)
        {
            bool breakOut = false;

            List<Card> cardsToComparePrev = new List<Card>();
            List<Card> cardsToCompareCurrent = new List<Card>();
            for (int i = 0; i < 8; i++)
            {
                Card targetCard = new Card(10, i);

                if (cardsToComparePrev.Contains(targetCard))
                    cardsToComparePrev.Add(targetCard);
            }

            //if ()

                for (int i = 0; i < cardsToComparePrev.Count(); i++)
                {
                    Card targetCard = new Card(11, cardsToComparePrev[i].SuitNum);
                    if (totalCards.Contains(targetCard))
                    {
                        cardsToCompareCurrent.Add(targetCard);
                    }
                }
            //tempComparison

            return false;
        }

        public void EndGame()
        {
            _hasGameEnded = true;
            Console.WriteLine("\n| Game ended! | \n");

            Console.Beep(200, 200);
            Console.Beep(200, 200);
        }
    }
}

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
                Console.WriteLine("\nShuffling...\n");
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
            //Console.WriteLine($"Choose to |bet|, |raise| or |stand|");
            Console.WriteLine($"Type to progress:");
            //Console.Write("Decide to: ");

            // TODO Player Choice:
            string playerChoice = Console.ReadLine();
        }

        private void ResolveGame()
        {
            Console.Clear();
            // Go through each player. Check if player has a scoreType higher than the other
            List<Tuple<Player, ScoreType, int>> winningPlayerInfo = new List<Tuple<Player, ScoreType, int>>();

            // Find player with the highest score
            foreach( Player player in _players )
            {
                Tuple<int,ScoreType> playerScore = Score(player);
                Tuple<Player, ScoreType, int> playerInfo = new Tuple<Player, ScoreType, int>(player, playerScore.Item2, playerScore.Item1);

                if (player == _players.First())
                    winningPlayerInfo.Add(playerInfo);


                if (winningPlayerInfo.ElementAt(0).Item2 == Score(player).Item2)
                    winningPlayerInfo.Add(playerInfo);
                else if(winningPlayerInfo.ElementAt(0).Item2 < Score(player).Item2)
                {
                    winningPlayerInfo.Clear();
                    winningPlayerInfo.Add(playerInfo);
                }
            }
            // TODO: Check if ScoreType is the same, compare scoreValue
            if( winningPlayerInfo.Count() > 1 )
            {
                int winningPlayerIndex = 0;
                for (int i = 0; i < winningPlayerInfo.Count(); i++)
                {
                    if (winningPlayerInfo.ElementAt(winningPlayerIndex).Item3 < winningPlayerInfo.ElementAt(i).Item3 ){
                        winningPlayerIndex = i;
                    }
                }
                Console.WriteLine($"Cards on the board:");
                _board.ShowCards();
                Console.Write("\n\n");

                Console.WriteLine($"Your hand:");
                winningPlayerInfo.ElementAt(winningPlayerIndex).Item1.ShowCards();
                Console.Write("\n\n");

                Console.WriteLine($"{winningPlayerInfo.ElementAt(winningPlayerIndex).Item1.Name} wins with a {winningPlayerInfo.ElementAt(winningPlayerIndex).Item2}!");
                return;
            }

            Console.WriteLine($"Cards on the board:");
            _board.ShowCards();
            Console.Write("\n\n");

            Console.WriteLine($"{winningPlayerInfo.ElementAt(0).Item1.Name}'s hand:");
            winningPlayerInfo.ElementAt(0).Item1.ShowCards();
            Console.Write("\n\n");

            // Write ending line
            Console.WriteLine($"{winningPlayerInfo.ElementAt(0).Item1.Name} wins with a {winningPlayerInfo.ElementAt(0).Item2}!");
            return;
        }


        private Tuple<int,ScoreType> Score(Player player)
        {
            List<Card> totalCards = [.. _board.CardsInHand, .. player.CardsInHand];

            // COMPARE
            // Royal Flush
            if (RoyalFlush(totalCards))
                return new Tuple<int,ScoreType>( 100, ScoreType.RoyalFlush);
            // Straight Flush
            if (StraightFlush(totalCards))
                return new Tuple<int, ScoreType>(100, ScoreType.StraightFlush);
            // Four of a Kind
            if (FourOfAKind(totalCards))
                return new Tuple<int, ScoreType>(100, ScoreType.FourOfAKind);
            // Full House
            if (FullHouse(totalCards))
                return new Tuple<int, ScoreType>(100, ScoreType.FullHouse);
            // Flush
            if (Flush(totalCards))
                return new Tuple<int, ScoreType>(100, ScoreType.Flush);
            // Straight
            if (Straight(totalCards))
                return new Tuple<int, ScoreType>(100, ScoreType.Straight);
            // Three of a Kind
            if (ThreeOfAKind(totalCards))
                return new Tuple<int, ScoreType>(100, ScoreType.ThreeOfAKind);
            // Two Pair
            if (TwoPair(totalCards))
                return new Tuple<int, ScoreType>(100, ScoreType.TwoPair);
            // Pair
            if (Pair(totalCards))
                return new Tuple<int, ScoreType>(100, ScoreType.Pair);

            // HighestCard
            return new Tuple<int, ScoreType>(HighestCard(totalCards), ScoreType.HighCard);
        }

        private bool TwoPair(List<Card> totalCards)
        {
            List<Card> duplicates = totalCards
                .GroupBy(num => num)
                .Where(group => group
                .Count() >= 2)
                .Select(group => group.Key).ToList();
            return (duplicates.Count() >= 2) ? true : false;
        }

        enum ScoreType
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        private string GetScoreType(ScoreType scoreType)
        {
            switch (scoreType)
            {
                case ScoreType.HighCard:
                    return "High Card";
                case ScoreType.Pair:
                    return "Pair";
                case ScoreType.TwoPair:
                    return "Pair";
                case ScoreType.ThreeOfAKind:
                    return "Three of a Kind";
                case ScoreType.Straight:
                    return "Straight";
                case ScoreType.Flush:
                    return "Flush";
                case ScoreType.FullHouse:
                    return "Full House";
                case ScoreType.FourOfAKind:
                    return "Four of a Kind";
                case ScoreType.StraightFlush:
                    return "Straight Flush";
                case ScoreType.RoyalFlush:
                    return "Royal Flush";
                default:
                    return "???";
            }
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

        private bool Pair(List<Card> totalCards)
        {
            List<Card> duplicates = totalCards.GroupBy(num => num).Where(group => group.Count() >= 2).Select(group => group.Key).ToList();
            return (duplicates.Count() > 0) ? true : false;
        }

        private bool ThreeOfAKind(List<Card> totalCards)
        {
            List<Card> duplicates = totalCards.GroupBy(num => num).Where(group => group.Count() >= 3).Select(group => group.Key).ToList();
            return (duplicates.Count() > 0) ? true : false;
        }

        private bool Straight(List<Card> totalCards)
        {
            int lastNum = totalCards.ElementAt(0).Value;
            int numCombo = 0;

            totalCards.OrderByDescending(num => num.Value).Reverse().Distinct().ToList();

            for (int i = 1; i < totalCards.Count(); i++)
            {
                if(lastNum == totalCards.ElementAt(i).Value -1)
                    ++numCombo;
                else
                    numCombo = 0;
                
                lastNum = totalCards.ElementAt(i).Value;

                if (numCombo == 5)
                    return true;
            }

            return false;
        }

        private bool Flush(List<Card> totalCards)
        {
            for (int i = 0; i < 8; i++)
            if( totalCards.Count(c => c.SuitID == i) >= 5 )
            {
                return true;
            }
            return false;
        }

        private bool FullHouse(List<Card> totalCards)
        {
            List<Card> duplicates = totalCards.GroupBy(num => num).Where(group => group.Count() >= 2).Select(group => group.Key).ToList();
            // Check if there is more than two sets of cards that has two or more cards
            if(duplicates.Count() >= 2)
            {
                // Check if there is a a set of tree cards
                if (ThreeOfAKind(totalCards))
                    return true;
            }
            return false;
        }

        private bool FourOfAKind(List<Card> totalCards)
        {
            List<Card> duplicates = totalCards.GroupBy(num => num).Where(group => group.Count() >= 4).Select(group => group.Key).ToList();
            return (duplicates.Count() > 0) ? true : false;
        }

        private bool StraightFlush(List<Card> totalCards)
        {
            int lastNum = totalCards.ElementAt(0).Value;
            int numCombo = 0;
            int lastSuitID = totalCards.ElementAt(0).SuitID;

            // Order by value ascending
            totalCards.OrderByDescending(num => num.Value).Reverse();

            for (int i = 1; i < totalCards.Count(); i++)
            {
                // Check if the next number is one higher than the last, and 
                if (lastNum == totalCards.ElementAt(i).Value - 1 &&
                    lastSuitID == totalCards.ElementAt(i).SuitID)
                    
                    ++numCombo;
                else
                    numCombo = 0;

                lastNum = totalCards.ElementAt(i).Value;
                lastSuitID = totalCards.ElementAt(i).SuitID;

                if (numCombo == 5)
                    return true;
            }

            return false;
        }


        private bool RoyalFlush(List<Card> totalCards)
        {
            List<Card> highCards = totalCards.Where(c => c.Value >= 10).Select(c => c).ToList();

            highCards = highCards.OrderByDescending(c => c.SuitID).ThenBy(c => c.Value).ToList();

            // Set the list to only include cards with the same suit that has a count larger than 5. Removes the rest
            for (int s = 0; s < 8; s++)
                if (highCards.Count(c => c.SuitID == s) > 5)
                {
                    highCards = highCards.Where(c => c.SuitID == s).ToList();

                    // Check the high cards if there exists a flush. If so, then we got a Royal Flush
                    if (Straight(highCards))
                        return true;
                    break;
                }

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

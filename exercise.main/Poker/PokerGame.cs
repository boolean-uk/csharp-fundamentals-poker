using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    internal class PokerGame
    {
        public List<Player> players =
        [
            new Player("Alice"),
            new Player("Bob"),
        ];

        private readonly Deck _deck;
        private List<Card> _communityCards;


        public PokerGame() 
        {
            _deck = new Deck();
            _communityCards = [];
        }

        private void DealToCommunityCards(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _communityCards.Add(_deck.Deal());
            }
            Console.WriteLine("The community cards are:");
            DisplayCards(_communityCards);
            DisplayPlayersHand();
            Console.ReadLine();
        }

        private void Init()
        {
            _deck.GenerateCards(52);
            foreach (Player player in players)
            {
                player.ClearHand();
                for (int i = 0; i <= 1; i++)
                {
                    player.AddCardToHand(_deck.Deal());
                }
            }
            DealToCommunityCards(3);
        }

        private void DisplayCards(ICollection<Card> cards)
        {
            foreach (Card card in cards) 
            {
                Console.WriteLine(card.ToString());
            }
        }

        private void DisplayPlayersHand()
        {
            foreach(Player player in players)
            {
                Console.WriteLine($"\n{player.Name} has:");
                DisplayCards(player.GetHand());
            }
        }

        private void Round()
        {
            throw new NotImplementedException();
        }

        public void Game()
        {
            var isPlaying = true;
            Init();
            WinningHands winningHands = new();
            while (isPlaying && !_deck.IsEmpty())
            { 
                DealToCommunityCards(2);
                foreach(Player player in players)
                {
                    var playerCommunityCards = new List<Card>(_communityCards);
                    playerCommunityCards.AddRange(player.GetHand());
                    player.Score = winningHands.IterateWinConditions(playerCommunityCards);
                }
                
                var winner = players.MaxBy(player => player.Score);

                string winText = winner != null ? $"{winner.Name} has won!" : "The round is a draw!";
                Console.WriteLine(winText);
                isPlaying = false;
            };
        }

    }
}

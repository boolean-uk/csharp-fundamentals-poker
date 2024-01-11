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
            _deck = new Deck(52);
            _communityCards = [];
        }

        private void Init()
        {
            foreach (Player player in players)
            {
                for (int i = 0; i <= 1; i++)
                {
                    player.AddCardToHand(_deck.Deal());
                }
            }
            for (int i = 0; i <= 2; i++)
            {
                _communityCards.Add(_deck.Deal());
            }
        }

        //private bool IsWinningHand(List<Card> hand)
        //{
        //    hand.All(c => c.Equals(hand.First()));
        //}

        //private Player GetWinner()
        //{
        //    foreach (Player player in players) 
        //    {
        //        player.GetHand();
        //    };
        //}

        public void Start()
        {
            var isPlaying = true;
            Init();
            Core core = new Core();
            while (isPlaying && !_deck.IsEmpty())
            {
                
            };
        }

    }
}

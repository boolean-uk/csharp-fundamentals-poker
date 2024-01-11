using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngradedPokerAssignment
{
    public class Player
    {
        private string _playerName;
        public List<Card> hand;
        public Player(string playerName)
        {
            _playerName = playerName;
        }

        public void DrawOne(Deck deck)
        {
            hand.Add(deck.Deal());
        }

        public void clearCards()
        {
            hand.Clear();
        }

        public void putBackCard(Deck deck, int cardToRemoveIndex)
        {
            deck.Cards.Add(hand[cardToRemoveIndex]);
            deck.Cards.Distinct();
            hand.Remove(hand[cardToRemoveIndex]);

        }


    }
}

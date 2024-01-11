using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.PokerGame
{
    internal class Card
    {
        public string _cardValue { get; set; }
        public string suit { get; set; }

        public Card(string cardValue, string suit)
        {
            this._cardValue = cardValue;
            this.suit = suit;
        }
    }
}

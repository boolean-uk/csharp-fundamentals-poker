using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class Card
    {
        private string _cardValue;
        private string _suit;

        public string CardValue { get => _cardValue; set => _cardValue = value; }
        public string Suit { get => _suit; set => _suit = value; }
        /*
        public Card(string cardValue, string suit)
        {
            _cardValue = cardValue;
            _suit = suit;
        }
        */
    }
}

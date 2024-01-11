using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card
    {
        private string _value;
        private Suit _suit;
        public string Value { get { return _value; } set { _value = value; } }
        public Suit Suit    { get { return _suit; } set { _suit = value; } }

        public Card(string value, Suit suit)
        {
            _value = value;
            _suit = suit;
        }

        public override string ToString()
        {
            return $"{_value} of {_suit.ToString()}";
        }
    }

    public enum Suit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }
}

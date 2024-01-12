using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    public class Card
    {
        private string _value;
        private string _suit;

        public static Dictionary<string, int> valuePairs = new()
        {
            {"1", 1},
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9},
            {"10", 10},
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14}
        };

        public override string ToString()
        {
            return $"{_value} {_suit}";
        }

        public static List<string> suits = new()
        {
            "Spades", "Hearts", "Diamonds", "Clubs"
        };

        public Card(string value, string suit)
        {
            _value = value;
            _suit = suit;
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Suit
        {
            get { return _suit; }
            set { _value = value; }
        }
    }
}

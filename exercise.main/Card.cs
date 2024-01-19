using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card
    {
        private string _value;
        private string _suit;
        private int _valueInt;

        private Dictionary<string, int> _cardValues = new Dictionary<string, int>()
        {
            {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8},
            {"9", 9}, {"10", 10}, {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
        };

        public Card(string value, string suit)
        {
            _value = value;
            _valueInt = _cardValues[value];
            _suit = suit;
        }

        public string Value { get => _value; }
        public int ValueInt { get => _valueInt; }
        public string Suit { get => _suit; }
    }
}

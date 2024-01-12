using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card
    {
        private string _suit;
        private string _value;
        public Card(string Suit, string Value ) { 
            _value = Value;
            _suit = Suit;
        }
        public string Suit { get { return _suit;  } set { _suit = value; } }
        public string Value { get { return _value; } set { _value = value; } }
    }
}

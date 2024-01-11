using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Card
    {
        public string _value;
        public string _suit; 

        public Card(string Value, string Suit)
        {
            _value = Value;
            _suit = Suit;
        }

        public string Value { get { return _value; } }
        public string Suit { get { return _suit; } }

        
    }


}

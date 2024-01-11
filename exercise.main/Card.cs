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
        private string _suit;
        public Card(string value, string suit)
        {
            _value = value;
            _suit = suit;
        }
        public string Value { get { return _value; } set {  _value = value; } }
        public string Suit { get { return _suit;} set { _suit = value; } }

    }

}
    

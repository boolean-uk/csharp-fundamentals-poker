using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Card
    {
        private string _value;
        private string _suit;

        public string Value { get { return _value; } }
        public string Suit { get { return _suit; } }

        public Card(string value, string suit)
        {
            _value = value;
            _suit = suit;
        }

        public void PrintCard()
        {
            Console.WriteLine($"{_value}{_suit}");
        }
    }
}

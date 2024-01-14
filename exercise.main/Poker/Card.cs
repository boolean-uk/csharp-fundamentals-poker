using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    public class Card
    {
        public string Value { get; }
        public string Suit {  get; }
       public Card(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}

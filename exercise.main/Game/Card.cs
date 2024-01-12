using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Game
{
    public class Card
    {
        string value { get; set; }
        string suit { get; set; }

        public Card(string value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public string getValue() { return value; }

        public string getSuit() { return suit; }
    }
}

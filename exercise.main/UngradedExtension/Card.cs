using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.UngradedExtension
{
    public class Card

    {
        public Suit Suit { get; set; }
        public string Value { get; set; }

        public Card(string value, Suit suit) {
            Suit = suit;
            Value = value;
        }

        public void PrintCard()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            return this.Value + " of " + this.Suit; 
        }
    }

}

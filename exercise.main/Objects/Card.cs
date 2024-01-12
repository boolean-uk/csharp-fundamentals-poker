using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Card
    {
        public int CardValue { get; set; }

        public Suit CardSuit { get; set; }
        public enum Suit
        {
            heart =0,
            spades,
            diamond,
            flower
        };

        public string GetCard() {
            switch (CardValue)
            {
                case 11: return "J " + CardSuit.ToString();
                case 12: return "Q " + CardSuit.ToString();
                case 13: return "K " + CardSuit.ToString();
                case 14: return "A " + CardSuit.ToString();

                default: return CardValue.ToString() + " " + CardSuit.ToString();
            }
            
        }



        public Card(int value, Suit suit)
        {
            CardValue = value;
            CardSuit = suit;
        }
        
    }
}

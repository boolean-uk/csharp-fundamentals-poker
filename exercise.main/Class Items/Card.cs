using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    internal class Card
    {
        private int _value;
        public enum eSuit
        {
            Clubs = 0,
            Diamonds,
            Hearts,
            Spades
        }
        private eSuit _suit;

        int Value { get => _value; }
        eSuit s { get => _suit; }

        public Card(int value, eSuit suit)
        {
            _value = value;
            _suit = suit;
        }

        public string GetCardString() 
        {
            string output = string.Empty; 
            switch (_value)
            {
                case 11:
                    output = "Jack of ";
                    break;
                case 12:
                    output = "Queen of ";
                    break;
                case 13:
                    output = "King of ";
                    break;
                case 14:
                    output = "Ace of ";
                    break;
                default:
                    output = _value.ToString() + " of "; 
                    break;
            }
            return output + _suit.ToString();
        }
    }
}

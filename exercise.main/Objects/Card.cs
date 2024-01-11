using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Card
    {
        string[] _suitsSymbol = new string[8] { "♠", "♥", "♦", "♣", "♤", "♡", "♢", "♧" };
        string[] _valueSymbol = new string[4] { "J", "Q", "K", "A"};

        // Tuple contains value and suit
        Tuple<int, int> _cardInfo;


        public Card(int val, int suit)
        {
            _cardInfo = Tuple.Create(val, suit);
        }


        public string ValueSymbol {
            get
            {
                int value = _cardInfo.Item1;
                //"11j 12q 13k 14A"
                if (value > 14 || value < 2)
                    return "?";

                if(value <= 10)
                    return value.ToString();

                return _valueSymbol[value - 11];
            }
        }
        public int Value { get => _cardInfo.Item1; }
        public string Suit { get => _suitsSymbol[_cardInfo.Item2]; }
        public int SuitNum { get => _cardInfo.Item2; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngradedPokerAssignment
{
    public class Card
    {
        private string _cardName { get; set; }
        private string _cardType { get; set; }

        public Card(string CardName, string CardType) 
        {

            _cardName = CardName;
            _cardType = CardType;

        }
    }
}

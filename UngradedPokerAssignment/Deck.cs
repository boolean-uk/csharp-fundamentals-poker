using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngradedPokerAssignment
{
    public class Deck
    {
        private List<Card> _cards {  get; set; }

        public List<Card> Cards;

        public Deck(List<Card> Cards)
        {
            _cards = Cards;
        }

        public void Shuffle()
        {
            Cards = _cards;
            
            
        }

        public Card Deal()
        {
            if(Cards.Count != 0)
            {
                Card tempCard = Cards.First();
                Cards.Remove(Cards.First());
                return tempCard;
            }
            else
            {
                Shuffle();
                Card tempCard = Cards.First();
                Cards.Remove(Cards.First());
                return tempCard;
            }
        }


    }
}

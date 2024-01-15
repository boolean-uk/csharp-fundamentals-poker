using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Deck
    {

        private List<Card> _cards;

        public Deck(List<Card> cards)
        {
            _cards = cards;
        }

        public List<Card> Cards { get { return _cards; } set { _cards = value; } }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;

            }

        
        }

        public Card Deal()
        {
            Card drawnCard = Cards.First();
            Cards.Remove(Cards.First());
            return drawnCard;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Deck
    {
        public List<Card> Cards = new List<Card>();

        public Deck() {

            Create();

        }

        public void Create()
        {
            for (int i = 0; i < 52; i++)
            {
                //Add cards to our deck, starting with val 2 (ace is 14), by dividing by 13 cards per house, and flooring it to remove decimals
                Cards.Add(new Card(i % 13 + 2, (Card.Suit)Math.Floor((decimal)i / 13)));
            }
        }
        public void Shuffle()
        {
            Cards.Clear();
            Create();
            Random rnd = new Random();
            Cards = Cards.OrderBy(item => rnd.Next()).ToList();
        }

        public Card Deal()
        {
            Card card = Cards.First();
            Cards.Remove(card);
            return card;
        }
        
    }
}

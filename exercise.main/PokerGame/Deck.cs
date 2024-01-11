using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.PokerGame
{
    internal class Deck
    {
        public List<Card> _cards {  get; set; }
        public Deck(List<Card> cards) 
        {
            this._cards = cards;
        }

        public List<Card> Shuffle(List<Card> cards) 
        {
            Random random = new Random();
            for (int i = 0; i < cards.Count()-1; i++) 
            {
                int newPlacement = random.Next(i, cards.Count());
                Card temp = cards[newPlacement];
                cards[newPlacement] = cards[i];
                cards[i] = temp;
            }            
            return cards.ToList();
        }

        public Card Deal() 
        {
            Random random = new Random();
            int index = random.Next(0, _cards.Count);
            Card cardToDeal = _cards[index];
            this._cards.RemoveAt(index);
            return cardToDeal;
        }
   }
}

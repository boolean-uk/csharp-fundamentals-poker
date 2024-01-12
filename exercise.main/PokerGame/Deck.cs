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
        public Deck() 
        {
            this._cards = this.GenerateDeck();
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

        public List<Card> GenerateDeck() 
        {
            string[] suties = new string[] { "heart","spade","something1", "something2"};
            Dictionary<int, string> specialCards = new Dictionary<int, string>()
            {
                {11, "J"},
                {12, "Q"},
                {13, "K"},
            };

            List<Card> cards = new List<Card>();
            for (int i = 0; i < 4; i++) 
            {
                Card newCard = new Card("A", suties[i]);
                cards.Add(newCard);
            }

            for (int i = 2; i <= 13; i++) 
            {
                for (int j = 0; j < 4; j++) 
                {
                    if (specialCards.ContainsKey(i))
                    {
                        Card newCard = new Card(specialCards[i], suties[j]);
                        cards.Add(newCard);
                    }
                    else
                    {
                        Card newCard = new Card(i.ToString(), suties[j]);
                        cards.Add(newCard);
                    }
                }
            }
            return cards;
            
        }
   }
}

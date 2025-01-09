using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.UngradedExtension
{
    public class Deck
    {
        List<Card> cards;

        public Deck() {
            InitializeDeck();        
        }

        public void InitializeDeck()
        {
            CardHandler cardHandler = new CardHandler();
            cards = new List<Card>();
            foreach (var suit in Enum.GetValues<Suit>()) {
                foreach (var value in cardHandler.CardValues)
                {
                    Card newCard = new Card(value.Key, suit);
                    cards.Add(newCard);
                }
            }
            Shuffle();
        }
        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
            }
        }

        public Card Deal()
        {
            Card dealtCard = cards.Last();
            cards.Remove(dealtCard);
            return dealtCard;
        }
    }
}

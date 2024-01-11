using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    internal class Deck
    {
        public List<Card> _deckOfCards = new List<Card> { };
        public Deck() 
        { 
            CreateDeck();
        }

        public void Shuffle()
        {
            _deckOfCards.Clear();
            CreateDeck();
            Random rnd = new Random();
            _deckOfCards = _deckOfCards.OrderBy(item => rnd.Next()).ToList();
        }

        public Card Deal()
        {
            Card dealtCard = _deckOfCards.First();
            _deckOfCards.RemoveAt(0);
            return dealtCard;
        }

        public void CreateDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                _deckOfCards.Add(new Card((i % 13) + 2, (Card.eSuit)Math.Floor((decimal)i / 13)));
            }
        }

    }
}

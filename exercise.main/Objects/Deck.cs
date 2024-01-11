using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Objects;

namespace exercise.main
{
    public class Deck
    {
        private List<Card> _cardsInDeck = new List<Card>();
        private readonly Random _random = new Random();

        public List<Card> CardsInDeck { get { return _cardsInDeck; } }
        
        public Deck() 
        { 
            // Fill deck with cards
            for(int val = 2; val <= 14; val++)
            { 
                for(int suit = 0; suit < 8; suit++)
                {
                    _cardsInDeck.Add(new Card(val, suit));
                }
            }
        }

        public void Shuffle()
        {
            _cardsInDeck = _cardsInDeck.OrderBy(card => _random.Next()).ToList();
        }

        public Card Deal()
        {
            if (_cardsInDeck.Count == 0)
                return new Card(0,0);
            
            // Get card on top of deck
            Card cardToGive = _cardsInDeck.ElementAt(0);
            _cardsInDeck.RemoveAt(0);

            return cardToGive;
        }
        /*public void ShowCards()
        {
            foreach (Card card in _cardsInDeck)
            {

                Console.Write(card.ValueSymbol + card.Suit);

                if (_cardsInDeck.Last() != card)
                {
                    Console.Write(", ");
                }
            }
        }*/
    }
}

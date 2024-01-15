using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Deck
    {
        List<Card> _deck = new List<Card>();

        //Returns the list of cards in deck
        public List<Card> Cards { get { return _deck; } }

        public Deck()
        {
            //populate deck list
            Generate();
            //shuffle deck
            Shuffle();


        }

        public void RegenerateDeck()
        {
            Generate();
            Shuffle();
        }

        //clears deck and generates a new deck of cards
        private void Generate()
        {
            _deck.Clear();
            for (int i = 0; i < 4; i++)
            {
                string suit;
                switch (i)
                {
                    case 0: suit = "S"; break;
                    case 1: suit = "C"; break;
                    case 2: suit = "H"; break;
                    case 3: suit = "D"; break;
                    default: suit = ""; break;
                }
                for (int j = 1; j < 14; j++)
                {
                    switch (j)
                    {
                        case 1: _deck.Add(new Card("A", suit)); break;
                        case 11: _deck.Add(new Card("J", suit)); break;
                        case 12: _deck.Add(new Card("Q", suit)); break;
                        case 13: _deck.Add(new Card("K", suit)); break;
                        default: _deck.Add(new Card(j.ToString(), suit)); break;
                    }
                }
            }
        }


        private void Shuffle()
        {
            //suffles deck
            Random rnd = new Random();
            _deck = _deck.OrderBy(item => rnd.Next()).ToList();
        }

        public Card Deal()
        {
            //Removes a card from the deck and returns it
            Card card = _deck[0];
            _deck.RemoveAt(0);
            return card;
        }


        
    }
}

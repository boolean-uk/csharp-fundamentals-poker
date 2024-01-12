using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deck
    {
        private List<Card> _cards;
        private List<string> _suits = new List<string>() 
        {
            "hearts", "clubs", "diamonds", "spades" 
        };
        private Dictionary<int, string> _cardValues = new Dictionary<int, string>()
        {
            {2 , "2"}, {3 , "3"}, {4 , "4"}, {5 , "5"}, {6 , "6"}, {7 , "7"}, {8 , "8"},
            {9 , "9"}, {10 , "10"}, {11 , "J"}, {12 , "Q"}, {13 , "K"}, {14 , "A"}
        };

        public Deck()
        {
            Shuffle();
        }

        public List<Card> Cards { get { return _cards; } }

        public void Shuffle()
        {
            _cards = new List<Card>();
            foreach (string suit in _suits)
            {
                for (int i = 2; i <= _cardValues.Count+1; i++)
                {
                    Card card = new Card(_cardValues[i], suit);
                    _cards.Add(card);
                }
            }

            Random random = new Random();
            for (int i = _cards.Count-1; i >= 0; i--)
            {
                int k = random.Next(i);
                Card card = _cards[k];
                _cards[k] = _cards[i];
                _cards[i] = card;
            }
        }

        public Card Deal()
        {
            Card card = _cards[_cards.Count-1];
            _cards.RemoveAt(_cards.Count-1);
            return card;
        }
    }
}

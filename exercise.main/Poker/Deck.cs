using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    public class Deck
    {
        private string[] _Values = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        private string[] _Suits = new string[4] { "Hearts", "Diamonds", "Clubs", "Spades" };

        private Stack<Card> _Deck = new Stack<Card>();

        public Deck() 
        {
            foreach(string value in _Values)
            {
                foreach(string suit in _Suits)
                {
                    _Deck.Push(new Card(value, suit));
                }
            }

            ShuffleCards();
        }
        public void ShuffleCards()
        {
            List<Card> cards = new List<Card>(_Deck);
            Random random = new Random();
            int n = cards.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int index = random.Next(i + 1);

                // Swap the cards at i and index
                Card temp = cards[i];
                cards[i] = cards[index];
                cards[index] = temp;
            }

            _Deck.Clear();
            foreach (Card card in cards)
            {
                _Deck.Push(card);
            }

        }

        public Stack<Card> GetCards()
        {
            return _Deck;
        }

        public Card Deal()
        {
            return _Deck.Pop();
        }
    }
}

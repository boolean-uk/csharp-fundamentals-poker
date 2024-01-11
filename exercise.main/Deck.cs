using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class Deck
    {
        List<Card> _cardDeck = new List<Card> ();
        List<string> _suitCount = new List<string>
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };
        List<string> _suits = new List<string> {
            "hearts", "spades", "clubs", "diamonds"
        };
        public Deck() {

           foreach (var suit in _suits) { 
                foreach(var value in  _suitCount)
                {
                   Card newCard = new Card(suit, value);
                   _cardDeck.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            int n = _cardDeck.Count;

            while (n > 1)
            {
                n--;
                int k = rnd.Next(n+1);
                Card card = _cardDeck[k];
                _cardDeck[k] = _cardDeck[n];
                _cardDeck[n] = card;
            }

        }

        public Card Deal()
        {
         
            Card dealtCard = _cardDeck.First();
            _cardDeck.RemoveAt(0);
            return dealtCard;
            
        }


    }
}

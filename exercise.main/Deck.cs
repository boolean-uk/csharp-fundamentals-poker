using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deck
    {
        private List<Card> deck;
        public Deck()
        {
            deck = new List<Card>();
        }
        public List<Card> shuffleDeck(List<Card> deck)
        {
            Random random = new Random();
            int n = deck.Count;

            for (int i = deck.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                Card value = deck[rnd];
                deck[rnd] = deck[i];
                deck[i] = value;
            }
            return deck;
        }
        public List<Card> refreshDeck(List<Card> deck)
        {
            deck.Clear();
            deck.Add(new Card("2", "♥"));
            deck.Add(new Card("3", "♥"));
            deck.Add(new Card("4", "♥"));
            deck.Add(new Card("5", "♥"));
            deck.Add(new Card("6", "♥"));
            deck.Add(new Card("7", "♥"));
            deck.Add(new Card("8", "♥"));
            deck.Add(new Card("9", "♥"));
            deck.Add(new Card("10", "♥"));
            deck.Add(new Card("J", "♥"));
            deck.Add(new Card("Q", "♥"));
            deck.Add(new Card("K", "♥"));
            deck.Add(new Card("A", "♥"));
            deck.Add(new Card("2", "♠"));
            deck.Add(new Card("3", "♠"));
            deck.Add(new Card("4", "♠"));
            deck.Add(new Card("5", "♠"));
            deck.Add(new Card("6", "♠"));
            deck.Add(new Card("7", "♠"));
            deck.Add(new Card("8", "♠"));
            deck.Add(new Card("9", "♠"));
            deck.Add(new Card("10", "♠"));
            deck.Add(new Card("J", "♠"));
            deck.Add(new Card("Q", "♠"));
            deck.Add(new Card("K", "♠"));
            deck.Add(new Card("A", "♠"));
            deck.Add(new Card("2", "♦"));
            deck.Add(new Card("3", "♦"));
            deck.Add(new Card("4", "♦"));
            deck.Add(new Card("5", "♦"));
            deck.Add(new Card("6", "♦"));
            deck.Add(new Card("7", "♦"));
            deck.Add(new Card("8", "♦"));
            deck.Add(new Card("9", "♦"));
            deck.Add(new Card("10", "♦"));
            deck.Add(new Card("J", "♦"));
            deck.Add(new Card("Q", "♦"));
            deck.Add(new Card("K", "♦"));
            deck.Add(new Card("A", "♦"));
            deck.Add(new Card("2", "♣"));
            deck.Add(new Card("3", "♣"));
            deck.Add(new Card("4", "♣"));
            deck.Add(new Card("5", "♣"));
            deck.Add(new Card("6", "♣"));
            deck.Add(new Card("7", "♣"));
            deck.Add(new Card("8", "♣"));
            deck.Add(new Card("9", "♣"));
            deck.Add(new Card("10", "♣"));
            deck.Add(new Card("J", "♣"));
            deck.Add(new Card("Q", "♣"));
            deck.Add(new Card("K", "♣"));
            deck.Add(new Card("A", "♣"));
            return deck;
        }
    }
}

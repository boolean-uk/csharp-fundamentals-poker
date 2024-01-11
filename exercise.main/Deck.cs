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
        public Deck()
        {
        }
        public static List<Card> shuffleDeck(List<Card> deck)
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
        public static List<Card> refreshDeck(List<Card> deck)
        {
            deck.Clear();
            deck.Add(new Card("2", " of Hearts"));
            deck.Add(new Card("3", " of Hearts"));
            deck.Add(new Card("4", " of Hearts"));
            deck.Add(new Card("5", " of Hearts"));
            deck.Add(new Card("6", " of Hearts"));
            deck.Add(new Card("7", " of Hearts"));
            deck.Add(new Card("8", " of Hearts"));
            deck.Add(new Card("9", " of Hearts"));
            deck.Add(new Card("10", " of Hearts"));
            deck.Add(new Card("J", " of Hearts"));
            deck.Add(new Card("Q", " of Hearts"));
            deck.Add(new Card("K", " of Hearts"));
            deck.Add(new Card("A", " of Hearts"));
            deck.Add(new Card("2", " of Spades"));
            deck.Add(new Card("3", " of Spades"));
            deck.Add(new Card("4", " of Spades"));
            deck.Add(new Card("5", " of Spades"));
            deck.Add(new Card("6", " of Spades"));
            deck.Add(new Card("7", " of Spades"));
            deck.Add(new Card("8", " of Spades"));
            deck.Add(new Card("9", " of Spades"));
            deck.Add(new Card("10", " of Spades"));
            deck.Add(new Card("J", " of Spades"));
            deck.Add(new Card("Q", " of Spades"));
            deck.Add(new Card("K", " of Spades"));
            deck.Add(new Card("A", " of Spades"));
            deck.Add(new Card("2", " of Diamonds"));
            deck.Add(new Card("3", " of Diamonds"));
            deck.Add(new Card("4", " of Diamonds"));
            deck.Add(new Card("5", " of Diamonds"));
            deck.Add(new Card("6", " of Diamonds"));
            deck.Add(new Card("7", " of Diamonds"));
            deck.Add(new Card("8", " of Diamonds"));
            deck.Add(new Card("9", " of Diamonds"));
            deck.Add(new Card("10", " of Diamonds"));
            deck.Add(new Card("J", " of Diamonds"));
            deck.Add(new Card("Q", " of Diamonds"));
            deck.Add(new Card("K", " of Diamonds"));
            deck.Add(new Card("A", " of Diamonds"));
            deck.Add(new Card("2", " of Clubs"));
            deck.Add(new Card("3", " of Clubs"));
            deck.Add(new Card("4", " of Clubs"));
            deck.Add(new Card("5", " of Clubs"));
            deck.Add(new Card("6", " of Clubs"));
            deck.Add(new Card("7", " of Clubs"));
            deck.Add(new Card("8", " of Clubs"));
            deck.Add(new Card("9", " of Clubs"));
            deck.Add(new Card("10", " of Clubs"));
            deck.Add(new Card("J", " of Clubs"));
            deck.Add(new Card("Q", " of Clubs"));
            deck.Add(new Card("K", " of Clubs"));
            deck.Add(new Card("A", " of Clubs"));
            return deck;
        }
        public static Card dealCard(List<Card> deck)
        {
            Card card = deck.First();
            deck.RemoveAt(0);
            return card;
        }
            
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deck
    {
        public List<Card> mDeck { get; set; } = new List<Card>();
        public Deck()
        {
            Shuffle();
        }
        public void Shuffle()
        {
            //4 card suits
            for (int i = 0; i < 4; i++)
            {
                char suit;

                switch (i)
                {
                    case (0):
                        suit = 'H';
                        break;
                    case (1):
                        suit = 'D';
                        break;
                    case (2):
                        suit = 'S';
                        break;
                    case (3):
                        suit = 'C';
                        break;
                    default:
                        suit = 'X';
                        break;
                }
                //13 cards each
                for (int j = 2; j < 15; j++)
                {
                    Card card = new Card(suit, j);
                    mDeck.Add(card);

                    //Console.WriteLine($"Suit: {card.mCard.Item1}, Value: {card.mCard.Item2}");
                }

            }

            var rng = new Random();
            mDeck = mDeck.OrderBy(item => rng.Next()).ToList();
        }

        public Card Deal()
        {
            Card card = mDeck.FirstOrDefault();
            mDeck.Remove(card);
            return card;
        }
    }

}

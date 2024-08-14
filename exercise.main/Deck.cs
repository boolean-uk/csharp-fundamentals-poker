using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main
{
    public class Deck
    {
        public List<Card> deck = new List<Card>();


        public void ShuffleDeck()
        {

            Random random = new Random();
            int n = deck.Count;
            while(n > 1)
            {
                n--;
                int j = random.Next(n + 1);
                Card temp = deck[j];
                deck[j] = deck[n];
                deck[n] = temp;
            }
        }



        public void InitializeDeck()
        {
            deck.Clear(); // remove all old cards 

            List<string> color = new List<string>
            {
                "hearts", "spades", "clubs", "diamonds"
            };
            List<string> face = new List<string>
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };


            for (int i = 0; i < face.Count; i++) // for each of the 12 f
            {
                foreach (var col in color)
                {
                    Card card = new Card();
                    card.color = col;
                    card.cardValue = i + 2; // as i goes from 0-12 and value goes from 2-14
                    card.face = face[i];
                    deck.Add(card);

                }
            }
        }

        public Card DealCard()
        {
            Card card = new Card();

            card = deck[0];
            deck.RemoveAt(0);
            return card;
        }
    }

}

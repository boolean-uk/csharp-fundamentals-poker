using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deck
    {
        List<Card> currentDeck = new List<Card>();
        Random random = new Random();

        public Deck()
        {
            Shuffle();
        }


        public Card Deal()
        {
            Card result = currentDeck.First();
            currentDeck.RemoveAt(0);
            return result;
        }
        public void Shuffle()
        {

            List<Card> sortedDeck = SortedDeck();
            List<Card> result = new List<Card>();
            while (sortedDeck.Count > 0)
            {
                int num = random.Next(sortedDeck.Count);
                result.Add(sortedDeck[num]);
                sortedDeck.RemoveAt(num);
            }
            currentDeck = result;
        }



        private List<Card> SortedDeck()
        {
            List<Card> sortedDeck = new List<Card>();
            List<string> values = new List<string>
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (string value in values)
                {
                    sortedDeck.Add(new Card(value, suit));
                }
            }
            return sortedDeck;
        }
    }
}

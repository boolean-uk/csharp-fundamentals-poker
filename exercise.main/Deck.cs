using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deck
    {
        List<Card> deck = new List<Card>();


        public void ShuffleDeck()
        {
            Random random = new Random();
            deck = deck.OrderBy(item => random.Next()).ToList();
        }
        public void InitializeDeck()
        {
            deck.Clear();
            List<string> names = new List<string>()
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };

            List<string> types = new List<string>()
            {
                "Hearts", "Spades", "Diamonds", "Clubs"
            };

            foreach (string name in names)
            {
                foreach (string type in types)
                {
                    deck.Add(new Card(name, type));
                }
            }
        }

        public Card Deal()
        {
            Card result = deck.Last();
            deck.Remove(result);
            return result;
        }
    }
}

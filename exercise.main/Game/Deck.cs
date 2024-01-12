using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Game
{
    public class Deck
    {
        List<Card> _cards = new List<Card>();

        public Deck()
        {
            Shuffle();
        }

        public void Shuffle()
        {
            List<Tuple<string, string>> newCards = new List<Tuple<string, string>>();
            string[] suits = ["spades", "hearts", "clubs", "diamonds"];
            string[] validValues = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
            foreach (string suit in suits)
            {
                foreach (string value in validValues)
                {
                    newCards.Add(new Tuple<string, string>(value, suit));
                }
            }
            Random randomGenerator = new Random();
            IEnumerable<Tuple<string, string>> iterable = newCards.OrderBy(a => randomGenerator.Next());

            _cards.RemoveAll(a => true);
            foreach (Tuple<string, string> tuple in iterable)
            {
                _cards.Add(new Card(tuple.Item1, tuple.Item2));
            }
        }


        public Card Deal()
        {
            // Incase empty
            if (_cards.Count < 1)
            {
                Console.WriteLine("The deck is empty, adding another one");
                Shuffle();
            }
            Card res = _cards.First();
            _cards.RemoveAt(0);
            return res;
        }
    }
}

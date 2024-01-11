using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public void DrawCard(Deck deck)
        {
            Card card = deck.Deal();
            Hand.Add(card);
        }

        public void RemoveCards()
        {
            Hand.Clear();
        }

        public void ReturnCard(Deck deck)
        {
            foreach (var c in Hand)
            {
                deck.mDeck.Add(c);
            }
        }
    }
}

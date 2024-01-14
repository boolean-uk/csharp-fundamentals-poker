using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    public class Player
    {
        public string Name { get; set; }
        private List<Card> Cards { get; set; }
        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
        }
        public Player()
        {
            Name = "John Doe(anon)";
            Cards = new List<Card>();
        }

        public void TakeCard(Card card)
        {
            Cards.Add(card);
        }
        public List<Card> ShowCards()
        {
            return Cards;
        }

        public void ThrowCards()
        {
            Cards.Clear();
        }
    }
}

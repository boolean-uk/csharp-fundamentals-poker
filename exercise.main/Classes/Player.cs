using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    internal class Player
    {
        private string _name;
        private List<Card> _hand = new List<Card>();

        public string Name { get { return _name; } }
        public List<Card> Hand { get { return _hand; } }

        public Player(string name)
        {
            _name = name;
        }

        public void EmptyHand()
        {
            _hand.Clear();
        }

        public void Draw(Card card)
        {
            _hand.Add(card);
        }
    }
}

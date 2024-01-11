using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    internal class Player
    {
        private string _name;
        private List<Card> _hand = new List<Card> { };

        public Player(string name)
        {
            _name = name;
        }

        public void Draw(Card card)
        {
            _hand.Add(card);
        }
        public void ClearCards()
        {
            _hand.Clear();
        }
        public Card[] ReturnCard()
        {
            return _hand.ToArray();
        }

    }
}

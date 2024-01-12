using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        private string _name;
        private List<Card> _hand;

        public void addToHand(Card card)
        {
            Hand.Add(card);
        }

        public void removeFromHand(Card card)
        {
            Hand.Remove(card);
        }

        public void clearHand()
        {
            Hand.Clear();
        }

        public List<Card> showHands()
        {
            return Hand;
        }

        public string Name { get { return _name; } set { _name = value; } } 
        public List<Card> Hand { get { return _hand; } set { _hand = value; } } 
    }
}

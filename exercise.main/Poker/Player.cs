using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    public class Player
    {
        private string _name = "No Name";
        private List<Card> _hand = new();
        public int Score { get; set; }

        public Player(string name)
        {
            _name = name;
        }

        public void AddCardToHand(Card card)
        {
            _hand.Add(card);
        }

        public void ClearHand()
        {
            _hand.Clear();
        }

        public List<Card> GetHand()
        {
            return _hand;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}

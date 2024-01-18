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
        private int _money;
        private bool _folded;
        public Player(string name)
        {
            _name = name;
            _hand = new List<Card>();
            _money = 1000;
            _folded = false;
        }

        public Player(string name, Card card)
        {
            _name = name;
            _hand = new List<Card>() { card };
        }

        public Player(string name, List<Card> hand)
        {
            _name = name;
            _hand = hand;
        }

        public string Name { get { return _name; } }
        public List<Card> Hand { get {  return _hand; } }
        public int Money { get { return _money; } set { _money = value; } }
        public bool Folded {  get { return _folded; } set { _folded = value; } }

        public void Add(Card card)
        {
            int counter = 0;
            foreach (Card c in Hand)
            {
                if(card.ValueInt > c.ValueInt)
                {
                    counter++;
                }
            }
            _hand.Insert(counter, card);
        }

        public void Clear()
        {
            _hand = new List<Card>();
        }
    }
}

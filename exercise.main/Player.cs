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
        public Player(string name)
        {
            _name = name;
            _hand = new List<Card>();
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

        public string printHand()
        {
            string hand = "";

            foreach (Card card in _hand)
            {
                string suit = "";
                if (card.Suit == "hearts") { suit = "H"; }
                else if (card.Suit == "spades") { suit = "S"; }
                else if (card.Suit == "diamonds") { suit = "D"; }
                else if (card.Suit == "clubs") { suit = "C"; }
                hand += card.Value.ToString() + "-" + suit + ", ";
            }

            hand = hand.Trim();
            return hand.Trim(',');
        }

        public void Clear()
        {
            _hand = new List<Card>();
        }
    }
}

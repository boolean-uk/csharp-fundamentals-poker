using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class Table
    {
        private List<Card> _flop = new List<Card>();
        public List<Card> Flop { get { return _flop; } }

        public void Setup(Card one, Card two, Card three)
        {
            _flop.Add(one);
            _flop.Add(two);
            _flop.Add(three);
        }

        public void Draw(Card card)
        {
            _flop.Add(card);
        }
        public override string ToString()
        {
            string result = "Table cards: \n";
            foreach (Card card in _flop)
            {
                result += card.ToString();
                result += "\n";
            }
            return result;
        }
        public void Reset()
        {
            _flop.Clear();
        }
    }
}

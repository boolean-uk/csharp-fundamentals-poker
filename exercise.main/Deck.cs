using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deck
    {
        private List<Card> _cardList = new ();
        public Deck() { }

        public void Shuffle()
        {
            for(int i = CardList.Count - 1; i >= 0; i--)
            {
                Random r = new Random();
                int j = r.Next(0, i);
                Card temp = CardList[i];
                CardList[i] = CardList[j];
                CardList[j] = temp;
            }
        }

        public Card Deal()
        {
            return CardList[-1];
        }

        public List<Card> CardList { get { return _cardList; } set { _cardList = value; } }

    }
}

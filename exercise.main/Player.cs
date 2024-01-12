using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        public string _name;
        List<Card> _cards {  get; set; }

        public Player(string name)
        {
            _name = name;
            _cards = new List<Card>();
        }


        public List<Card> ShowHand() { return _cards; }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }



        public void RemoveCards()
        {

            if (_cards.Count != 0) {
                foreach (Card card in _cards)
                {

                    _cards.Remove(card);

                }
            } 
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.PokerGame
{
    internal class Player
    {
        public string _name { get; set; }
        public List<Card> _cards { get; set; }

        public Player(string name)
        {
            this._name = name;
            
        }

        public void AddCard(Card card)
        {
            this._cards.Add(card);
        }

        public void ClearCards() 
        {
            this._cards.Clear();
        }
    }
}

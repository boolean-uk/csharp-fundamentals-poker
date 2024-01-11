using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        string _playerName;
        List<Card> _playerCards = new List<Card>();

        public Player(string name) 
        {
            _playerName = name;
        }

        public string getPlayerName() 
        {
            return _playerName;
        }

        public void takeCard(Card card) 
        {
            _playerCards.Add(card);
        }

        public void clearCarcs() 
        {
            _playerCards.RemoveAll(x => true);
        }

        public List<Card> playCards() 
        {
            List<Card> res = new List<Card> ();
            _playerCards.ForEach(c => res.Add(c));
            _playerCards.RemoveAll(x => true);
            return res;
        }
    }
}

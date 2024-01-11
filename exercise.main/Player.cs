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

        public Card playCard() 
        {
            Card res = _playerCards.First();
            _playerCards.RemoveAt(0);
            return res;
        }
    }
}

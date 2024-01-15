using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        private string _name;
        private List<Card> _hand = new List<Card>();
        private bool _isPlaying = true;

        public bool IsPlaying { get { return _isPlaying; } }
        public string Name { get { return _name; } }
        public List<Card> Hand { get { return _hand; } }
        public Player(string name)
        {
            _name = name;
        }

        public void GiveUp()
        {
            _isPlaying = false;
            _hand.Clear();
        }

        
        public void Draw(Card card)
        {
            _hand.Add(card);
        }
        public void Clear()
        {
            _hand.Clear();
        }

        public string ShowPlayerHand()
        {
            string cards = "";
            foreach (Card card in _hand)
            {
                cards += card.ToString();
                cards += "\n";
            }
            return $"{_name} has: \n {cards}";
        }
        public void Reset()
        {
            Clear();
            _isPlaying = true;
        }
    }
}

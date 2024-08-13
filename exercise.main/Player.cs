using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        public string name { get; set; } = string.Empty;
        public List<Card> hand = new List<Card>();

        public Player(string name) 
        {
            this.name = name;
        }

        public void AddCard(Card card)
        { 
            hand.Add(card); 
        }

        public void ClearHand()
        {
            hand.Clear(); 
        }
    }
}

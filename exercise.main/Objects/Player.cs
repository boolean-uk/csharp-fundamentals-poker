using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Player
    {
        public Player() {  }
        public string Name { get; set; }
        public List<Card> Hand = new();

        public void Draw(Card card) { Hand.Add(card); }
        public void Clear() { Hand.Clear(); }
        public List <Card> GetHand() { return Hand;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.UngradedExtension
{
    public class Player
    {

        public string Name { get; set; }
        public List<Card> hand { get; set; }
        
        public Player(string name)
        {
            Name = name;
        }

        public void ClearHand()
        {
            hand = new List<Card>();
        }

        public void AddCardToHand(Card card)
        {
            hand.Add(card);
        }

        public List<Card> GetHand()
        {
            return hand;
        }

        public void PrintHand()
        {
            Console.WriteLine(this.Name + " has:");
            hand.ForEach(x => x.PrintCard());
        }
    }
}

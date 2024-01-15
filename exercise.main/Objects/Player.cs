using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Player
    {
        private string _name;
        private List<Card> _hand;

        public Player (string name, List<Card> hand)
        {
            _name = name;
            _hand = hand;

        }

        public string Name { get { return _name; } set { _name = value; } }
        public List<Card> Hand { get {  return _hand; } set { _hand = value; } }

        public void AddCard(Card newCard){
            Hand.Add(newCard);
        }

        public void ClearHand(){
            Hand.Clear();
        }

        public List<Card> currentHand(){
            return Hand;
        }



    }
}

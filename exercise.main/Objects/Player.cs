using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Player
    {
        private string _name = "Unknown";

        private List<Card> _hand = new List<Card>();

        public List<Card> CardsInHand { get { return _hand; } }

        public Player(string name)
        {
            _name = name;
        }

        public void DrawCard(Card card)
        {
            _hand.Add(card);
        }

        public void ShowCards()
        {
            foreach(Card card in _hand)
            {

                Console.Write(card.ValueSymbol + card.Suit);

                if (_hand.Last() != card)
                {
                    Console.Write(", ");
                }
            }
        }

        public string Name { get => _name; }
    }
}

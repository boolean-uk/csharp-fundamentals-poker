using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        public string name;
        public List<Card> cards;

        public Player(string nameOfPlayer)
        {
            this.name = nameOfPlayer;
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Card newCard = new Card();
            this.cards.Add(card);
        }

        public void EmptyHand()
        {
            cards.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        private string name;
        private List<Card> hand;
        private Deck deck;
        public Player(string name, Deck deck) {
            this.name = name;
            this.deck = deck;
            this.hand = new List<Card>();
        }
        /// <summary>
        /// Hit = addig a card
        /// </summary>
        public void Hit() {
            Card deltCard = deck.Deal();

            if (deltCard==null) { //!No more cards
                Console.WriteLine("No more cards in the deck...");
                throw new Exception();
            } else {
                hand.Add(deltCard);
            }
            
        }
        /// <summary>
        /// Remove the hand
        /// </summary>
        public void Clear() {
            hand.Clear();
        }

        //TODO! Figure out the correct return type
        public string GetHand() {
            StringBuilder sb = new StringBuilder();
            foreach (Card card in hand) {
                sb.Append($"{card.value} of {card.suit} \n");
            }

            return sb.ToString();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deck
    {
        //TODO - Implement a `Deck` class that stores a list / dictionary / array of `Card` objects
        //TODO - The `Deck` should have a method to `Shuffle()` / regenerate the deck
        //TODO - The `Deck` should have a method to `Deal()` one card from the deck, removing it from the list of cards in the deck

        //? Dictionary of cards
        private List<Card> cards;

        public Deck() {
            cards = GenerateDeck();
        }

        private List<Card> GenerateDeck() {

            List<Card> deck = new List<Card>();

            // Keep all combinations
            string[] value = { "1","2","3","4","5","6","7","8","9","10","J","Q","K","A" };
            string[] suit = {"spades","hearts","diamonds","clubs"};

            // generate cards in deck
            foreach (string _value in value) {
                
                foreach (string _suit in suit) {
                    string cardName = $"{_value} of {_suit}";
                    deck.Add(new Card(_value, _suit));
                }
            }
            return deck;
        }

        public void Shuffle() {
            Random rd = new Random();
            List<Card> shuffleDeck = cards;

            // Random order
            for (int i = 0; i < shuffleDeck.Count; i++) {
                int tmp = rd.Next(i-1);
                var value = shuffleDeck[tmp];
                shuffleDeck[tmp] = shuffleDeck[i];
                shuffleDeck[i] = value;
            }

            cards = shuffleDeck;
        }

        public Card Deal() {
            
            if (cards.Count == 0) { //!Empty deck
                throw new NullReferenceException();
            }
            Card deltCard = cards[cards.Count-1];
            cards.RemoveAt(cards.Count-1);
            return deltCard;
        }
    }
}
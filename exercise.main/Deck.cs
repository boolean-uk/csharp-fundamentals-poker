using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Deck
    {
        //TODO - Implement a `Deck` class that stores a list / dictionary / array of `Card` objects
        //TODO - The `Deck` should have a method to `Shuffle()` / regenerate the deck
        //TODO - The `Deck` should have a method to `Deal()` one card from the deck, removing it from the list of cards in the deck

        //? Dictionary of cards
        private Dictionary<string, Card> cards;

        private Deck() {
            cards = GenerateDeck();
        }

        private Dictionary<string, Card> GenerateDeck() {

            Dictionary<string, Card> deck = new Dictionary<string, Card>();

            // Keep all combinations
            string[] value = { "1","2","3","4","5","6","7","8","9","10","J","Q","K","A" };
            string[] suit = {"spades","hearts","diamonds","clubs"};

            // generate cards in deck
            foreach (string _value in value) {
                
                foreach (string _suit in suit) {
                    string cardName = $"{_value} of {_suit}";
                    deck.Add(cardName, new Card(_value, _suit));
                }
            }
            return deck;
        }

        public void Shuffle() {
            Random rd = new Random();
            List<KeyValuePair<string, Card>> shuffleDeck = cards.ToList();

            // Random order
            for (int i = 0; i < shuffleDeck.Count; i++) {
                int tmp = rd.Next(i-1);
                var value = shuffleDeck[tmp];
                shuffleDeck[tmp] = shuffleDeck[i];
                shuffleDeck[i] = value;
            }

            cards = new Dictionary<string, Card>(shuffleDeck);
        }

        public void Deal() {

        }
    }
}
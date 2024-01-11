using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card
    {
        public enum Suits
        {
            heart = 0, spade = 1, clubs = 2, diamonds = 3
        }

        private Suits _suit;
        private string _value;

        public Card(string value, Suits suit)
        {
            _value = value;
            _suit = suit;
        }

        public string value { get { return _value; } }
        public Suits suit { get { return _suit; } }
    }

    public class Deck
    {
        private List<Card> _deck = new List<Card>();

        public Deck()
        {
            initializeDeck();
        }

        private void initializeDeck()
        {
            string[] initializeDeck = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            foreach (string value in initializeDeck)
            {
                foreach (Card.Suits type in Enum.GetValues(typeof(Card.Suits)).Cast<Card.Suits>())
                {
                    _deck.Add(new Card(value, type));
                }
            }
        }

        private static Random rng = new Random();
        public void shuffle()
        {
            initializeDeck();

            int n = _deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = _deck[k];
                _deck[k] = _deck[n];
                _deck[n] = value;
            }
        }

        public Card deal()
        {
            if (_deck.Count == 0) throw new IndexOutOfRangeException();
            Card active = _deck[0];
            _deck.RemoveAt(0);
            return active;
        }
    }

    public class Player
    {
        private string _name;
        List<Card> _cards = new List<Card>();

        public Player(string name) { 
            _name = name;
        }

        public void draw(Card card)
        {
            _cards.Add(card);
        }

        public List<Card> viewCards() { return _cards; }
        public string name { get { return _name; } set { _name = value; } }

        public Tuple<Card, Card> getPair()
        {
            List<Card> cards = new List<Card>();

            foreach (Card card in _cards)
            {

            }

            throw new NotImplementedException();
        }
    }

    public class PokerGame
    {

        private Player _player1, _player2;
        private Deck _deck;

        PokerGame() {
            _deck = new Deck();
            _player1 = new Player("John");
            _player2 = new Player("Jane");
        }

        public void dealPlayers()
        {
            _player1.draw(_deck.deal());
            _player2.draw(_deck.deal());
        }

        public void dealTable()
        {
            Card cardToPlayer = _deck.deal();
            _player1.draw(cardToPlayer);
            _player2.draw(cardToPlayer);
        }

        public bool checkWinner()
        {


            return false;
        }
    }
}

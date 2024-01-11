using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {
        //2-14
        Dictionary<string, int> _values = new Dictionary<string, int>();
        //Spades, Hearts, Clubs, Diamonds 
        Dictionary<string, string> _suits = new Dictionary<string, string>();
        //Suit - Value
        List<Card> _deck = new List<Card>();

        public Dictionary<string, int> Values { get { return _values; } set { _values = value; } }
        public Dictionary<string, string> Suits { get { return _suits; } set { _suits = value; } }
        public List<Card> Deck { get { return _deck; } set { _deck = value; } }

        public Core()
        {
            Values = new Dictionary<string, int>();
            Suits = new Dictionary<string, string>();
            Deck = new List<Card>();
            //populateDeck();
        }

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>("10", "10");
            List<Tuple<string, string>> winningHands = new List<Tuple<string, string>>();


            foreach (var hand in hands)
            {
                if (hand.Item1 == hand.Item2)
                {
                    winningHands.Add(hand);
                }
            }
            //Card card1 = drawCard();
            //Card card2 = drawCard();

            if (winningHands.Count > 0)
            {
                result = winningHands[0];
                //Tuple<string, string> result = new Tuple<string, string>(winningHands[0].Item1, winningHands[0].Item2);



            }

            return result.Item1 != string.Empty ? true : false;
        }

        public int GetValueOfCard(string card)
        {
            return 0;
        }









        //Ungraded extension >_<
        public void populateDeck()
        {
            Values.Add("2", 2);
            Values.Add("3", 3);
            Values.Add("4", 4);
            Values.Add("5", 5);
            Values.Add("6", 6);
            Values.Add("7", 7);
            Values.Add("8", 8);
            Values.Add("9", 9);
            Values.Add("10", 10);
            Values.Add("J", 11);
            Values.Add("Q", 12);
            Values.Add("K", 13);
            Values.Add("A", 14);

            Suits.Add("S", "Spades");
            Suits.Add("H", "Hearts");
            Suits.Add("D", "Diamonds");
            Suits.Add("C", "Clubs");

            foreach (var suit in Suits)
            {
                foreach (var value in Values)
                {
                    Card card = new Card(suit.Key, value.Key);
                    Deck.Add(card);
                }
            }
        }

        public Card drawCard()
        {
            Random random = new Random();
            int cardPosition = random.Next(0, Deck.Count);
            Card card = Deck[cardPosition];
            Deck.RemoveAt(cardPosition);
            return card;
        }
    }


    public class Card
    {
        private string _suit;
        private string _value;

        public string Suit { get { return _suit; } set { _suit = value; } }
        public string Value { get { return _value; } set { _value = value; } }


        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }

        public string getAbbreviation()
        {
            return Suit.ToString()+Value.ToString();
        }
    }
}

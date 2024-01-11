using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card(char value, string suit)
    {
        public char Value { get; set; }
        public string Suit { get; set; }

    }
    public class Deck(List<Card> cards)
    {
        public List<Card> cards { get; set; }
    }
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
            int higestScore = 0;
            int newScore = 0;
            foreach (var pair in hand)
            {
                if (pair.Item1 == pair.Item2 && pair.Item2 == pair.Item3)
                {
                    newScore = GetValueOfCard(pair.Item1);
                    if (newScore > higestScore)
                    {
                        higestScore = newScore;
                        result = pair;
                    }
                }

            }
            return result.Item1 != string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            int score = 0;
            bool result = int.TryParse(card, out score);
            if (!result)
            {
                switch (card)
                {
                    case "J":
                        score = 11; break;
                    case "Q":
                        score = 12; break;
                    case "K":
                        score = 13; break;
                    case "A":
                        score = 14; break;
                }
            }
            return score;
        }
    }
}

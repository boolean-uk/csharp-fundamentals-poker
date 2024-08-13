using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            int winningScore = 0;
            foreach (var pair in hand)
            {
                if (pair.Item1 == pair.Item2 && pair.Item1 == pair.Item3)
                {
                    int score = GetValueOfCard(pair.Item1) + GetValueOfCard(pair.Item2) + GetValueOfCard(pair.Item3);
                    if (winningScore < score)
                    {
                        winningScore = score;
                        result = pair;
                    }
                }

            }

            return result.Item1 != string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> cardValue = new Dictionary<string, int>()
            {
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "10", 10 },
                { "J", 11 },
                { "Q", 12 },
                { "K", 13 },
                { "A", 14 }
            };

            if (cardValue.ContainsKey(card))
            {
                return cardValue[card];
            }
            return 0; //No such card exists.           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        public Dictionary<string, int> CardDictionary = new Dictionary<string, int>()
        {
            {"1", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8},
            {"9", 9}, {"10", 10}, {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
        };
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            foreach (Tuple<string, string, string> triple in hand)
            {
                string card1 = triple.Item1;
                string card2 = triple.Item2;
                string card3 = triple.Item3;

                if (card1 == card2 && card2 == card3)
                {
                    if (result.Item1 != string.Empty)
                    {
                        if (GetValueOfCard(card1) < GetValueOfCard(result.Item1))
                            continue;
                    }
                    result = new Tuple<string, string, string>(card1, card2, card3);
                }
            }

            return result.Item1 != string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            return CardDictionary[card];
        }
    }
}

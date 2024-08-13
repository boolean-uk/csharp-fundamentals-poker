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
        Dictionary<string, int> _cards;
        public Extension()
        {
            _cards = new Dictionary<string, int>()
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
        }

        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
            int winnerSum = 0;

            foreach (var h in hand)
            {
                if (h.Item1.Equals(h.Item2) && h.Item1.Equals(h.Item3))
                {
                    int value1 = GetValueOfCard(h.Item1);
                    int value2 = GetValueOfCard(h.Item2);
                    int value3 = GetValueOfCard(h.Item3);
                    int sumValue = value1 + value2 + value3;
                    if (sumValue > winnerSum)
                    {
                        winnerSum = sumValue;
                        result = h;
                    }
                }
            }

            return false;
        }

        public int GetValueOfCard(string card)
        {
            return _cards[card];
        }

    }
}

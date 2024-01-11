using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {

        //TODO: complete the following method, keeping the signature the same
        private Dictionary<string, int> _cards = new Dictionary<string, int>
        {
            ["K"] = 13,
            ["Q"] = 12,
            ["A"] = 14,
            ["J"] = 11
        };

        private Dictionary<int, string> _cardsReversed = new Dictionary<int, string>
        {
            [13] = "K",
            [12] = "Q",
            [14] = "A",
            [11] = "J"
        };


        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {

            result = new Tuple<string, string>(string.Empty, string.Empty);

            List<int> hands = new List<int>();

            foreach (Tuple<string, string> pair in hand)
            {
                int c1 = GetValueOfCard(pair.Item1);
                int c2 = GetValueOfCard(pair.Item2);

                hands.Add(c1);
                hands.Add(c2);

            }

            // no pairs?
            bool pairpresent = false;

            List<int> pairConfirmed = new List<int>();

            for (int i = 0; i < hands.Count - 1; i = i + 2)
            {
                if (hands[i] == hands[i + 1])
                {
                    pairpresent = true;
                    pairConfirmed.Add(hands[i]);
                }
            }

            if (pairpresent == false)
            {
                return result.Item1 != string.Empty ? true : false;
            }


            // there are pairs
            if (pairpresent == true)
            {
                int max = pairConfirmed.Max();

                string s1 = "";

                Console.WriteLine("Inside pair confirmed block!");

                Console.WriteLine(max);

                if (_cards.Values.Contains(max))
                {
                    s1 = _cardsReversed[max];
                }
                else
                {
                    s1 = $"{max}";
                }

                result = new Tuple<string, string>(s1, s1);

                return result.Item1 != string.Empty ? true : false;
            }

            else
            {
                return result.Item1 != string.Empty ? true : false;
            }
        }
        public int GetValueOfCard(string card)
        {
            if (_cards.Keys.Contains(card))
            {
                return _cards[card];
            }
            else
            {
                return int.Parse(card);
            }
        }
    }
}

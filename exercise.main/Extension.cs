using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
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
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            // new Tuple<string, string>("K", "5")
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            List<int> hands = new List<int>();

            foreach (Tuple<string, string, string> pair in hand)
            {
                int c1 = GetValueOfCard(pair.Item1);
                int c2 = GetValueOfCard(pair.Item2);
                int c3 = GetValueOfCard(pair.Item3);

                hands.Add(c1);
                hands.Add(c2);
                hands.Add(c3);

            }

            // no threes?
            bool threesPresent = false;

            List<int> threeConfirmed = new List<int>();

            for (int i = 0; i < hands.Count - 2; i = i + 3)
            {
                if (hands[i] == hands[i + 1] && hands[i] == hands[i + 2])
                {
                    threesPresent = true;
                    threeConfirmed.Add(hands[i]);
                }
            }

            if (threesPresent == false)
            {
                return result.Item1 != string.Empty ? true : false;
            }

            // there are threes
            if (threesPresent == true)
            {
                int max = threeConfirmed.Max();

                string s1 = "";


                if (_cards.Values.Contains(max))
                {
                    s1 = _cardsReversed[max];
                }
                else
                {
                    s1 = $"{max}";
                }

                result = new Tuple<string, string, string>(s1, s1, s1);

                return result.Item1 != string.Empty ? true : false;
            }

            else
            {
                return false;
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

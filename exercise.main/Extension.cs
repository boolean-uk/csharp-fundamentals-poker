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
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = iterateHands(hand);
            return result.Item1 != string.Empty ? true : false ;
        }

        public Tuple<string, string, string> iterateHands(IEnumerable<Tuple<string, string, string>> hand)
        {
            Dictionary<Tuple<string, string, string>, int> pairs = new Dictionary<Tuple<string, string, string>, int>();
            foreach (var item in hand)
            {
                if (decideThrees(item.Item1, item.Item2, item.Item3).Item1)
                {
                    pairs.Add(item, decideThrees(item.Item1, item.Item2, item.Item3).Item2);
                }
            }
            if (pairs.Count == 0)
            {
                return new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
            }
            return pairs.OrderByDescending(i => i.Value).First().Key;

        }

        public Tuple<bool, int> decideThrees(string card1, string card2, string card3)
        {
            int card1Value = GetValueOfCard(card1);
            int card2Value = GetValueOfCard(card2);
            int card3Value = GetValueOfCard(card3);

            return Tuple.Create(card1Value == card2Value && card2Value == card3Value, card1Value + card2Value + card3Value);
        }



        public int GetValueOfCard(string card)
        {
            int value = 0;
            try
            {
                value = Int32.Parse(card);
            }
            catch (FormatException)
            {
                switch (card)
                {
                    case "A":
                        value = 14;
                        break;
                    case "K":
                        value = 13;
                        break;
                    case "Q":
                        value = 12;
                        break;
                    case "J":
                        value = 11;
                        break;
                }
            }
            return value;
        }

    }
}

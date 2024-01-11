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

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            Tuple<string, string> emptyHand = new Tuple<string, string>(string.Empty, string.Empty);

            // Pick out all winning hands, with a sorting of highest on top/first.
            IEnumerable<Tuple<string, string>> winningHands = hand
                .Where(a => (a.Item1 == a.Item2))
                .OrderByDescending(a => GetValueOfCard(a.Item1));
            // Pick the first tuple, if none exists then pick the emptyHand defined earlier.
            result = winningHands.FirstOrDefault(emptyHand);

            return (result.Item1 != string.Empty ? true : false);

        }
        public int GetValueOfCard(string card)
        {
            int value;
            // Switch case to parse the strings into ints
            switch (card) 
            {
                case "J":
                    value = 11;
                    break;
                case "Q":
                    value = 12;
                    break;
                case "K":
                    value = 13;
                    break;
                case "A":
                    value = 14;
                    break;
                default:
                    int.TryParse(card, out int j);
                    value = j;
                    break;
            }
            return  value;           
        }
    }
}

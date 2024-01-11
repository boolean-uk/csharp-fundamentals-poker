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
            //result.Item1 != string.Empty ? true : false; ;

            IEnumerable<Tuple<string, string>> winningHands = hand
                .Where(a => (a.Item1 == a.Item2))
                .OrderByDescending(a => GetValueOfCard(a.Item1));
            Tuple<string, string> bestHand = winningHands.FirstOrDefault(emptyHand);

            result = bestHand;
            return (bestHand.Item1 != string.Empty ? true : false);
            /*
            result = hand
                .Where(a => (a.Item1 == a.Item2))
                .OrderByDescending(a => GetValueOfCard(a.Item1))
                .FirstOrDefault(emptyHand);
            */
            //string var = "hello";
            return (emptyHand.Item1 == string.Empty ? false: true);
        }
        public int GetValueOfCard(string card)
        {
            int value;
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

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
        public static Dictionary<string, int> valuePairs = new()
        {
            {"1", 1},
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9},
            {"10", 10},
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14}
        };

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);

            var winners = hand.Where(x => x.Item1.Equals(x.Item2));
            result = winners.MaxBy(x => GetValueOfCard(x.Item1) + GetValueOfCard(x.Item2)) 
                ?? new Tuple<string, string>(string.Empty, string.Empty);

            if (result.Item1 == string.Empty && result.Item2 == string.Empty)
            {
                return false;
            }

            return result.Item1.Equals(result.Item2);
        }
        public int GetValueOfCard(string card)
        {
            return valuePairs[card];          
        }
    }
}

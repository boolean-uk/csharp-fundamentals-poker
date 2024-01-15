using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            result = new Tuple<string, string>(string.Empty, string.Empty);

            foreach (var matchingPair in hand.Where(p => p.Item1 == p.Item2))
            {
                if (result.Item1 == string.Empty)
                {
                    result = new Tuple<string, string>(matchingPair.Item1, matchingPair.Item2);
                }
                if (this.GetValueOfCard(matchingPair.Item1) >= this.GetValueOfCard(result.Item1))
                {
                    result = new Tuple<string, string>(matchingPair.Item1, matchingPair.Item2);
                }
            }

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            switch (card)
            {
                case "2": return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 7;
                case "8": return 8;
                case "9": return 9;
                case "10": return 10;
                case "J": return 11;
                case "Q": return 12;
                case "K": return 13;
                case "A": return 14;
            }
            return 0;
        }
    }
}

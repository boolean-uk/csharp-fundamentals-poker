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
            result = new Tuple<string, string>(string.Empty, string.Empty);

            HashSet<string> seenValues = new HashSet<string>();

            foreach (var card in hand)
            {
                // Check if the value has already been seen in a different suit
                if (seenValues.Contains(card.Item1) && seenValues.Contains(card.Item2))
                {
                    result = card;
                    return true;
                }

                seenValues.Add(card.Item1);
                seenValues.Add(card.Item2);
            }

            return false;
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
                default: return 0; // Return 0 for unknown cards or handle appropriately
            }
        }

        public bool winningThree(List<Tuple<string, string, string>> hand, out Tuple<string, string, string> winner)
        {
            throw new NotImplementedException();
        }
    }
}

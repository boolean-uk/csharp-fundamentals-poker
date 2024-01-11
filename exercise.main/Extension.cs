using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
            HashSet<string> seenValues = new HashSet<string>();

            foreach (var card in hand)
            {
                if (seenValues.Contains(card.Item1) && seenValues.Contains(card.Item2) && seenValues.Contains(card.Item3))
                {
                    result = card;
                    return true;
                }

                seenValues.Add(card.Item1);
                seenValues.Add(card.Item2);
                seenValues.Add(card.Item3);
            }

            return false;
        }
    }
}

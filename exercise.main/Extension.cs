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
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            var winners = hand.Where(x => x.Item1 == x.Item2 && x.Item1 == x.Item3);
            result = winners.MaxBy(x => Core.valuePairs[x.Item1] + Core.valuePairs[x.Item2] + Core.valuePairs[x.Item3])
                ?? new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            if (result.Item1 == string.Empty && result.Item2 == string.Empty && result.Item3 == string.Empty)
            {
                return false;
            }

            bool isWinningHand = result.Item1 == result.Item2 && result.Item1 == result.Item3;

            return isWinningHand;
        }

    }
}

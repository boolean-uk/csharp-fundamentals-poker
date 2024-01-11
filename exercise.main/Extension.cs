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
            Core core = new Core();
            Tuple<string, string, string> emptyHand = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            // Pick out all winning hands, with a sorting of highest on top/first.
            IEnumerable<Tuple<string, string, string>> winningHands = hand
                .Where(a => ((a.Item1 == a.Item2) && (a.Item2 == a.Item3)))
                .OrderByDescending(a => core.GetValueOfCard(a.Item1));
            // Pick the first tuple, if none exists then pick the emptyHand defined earlier.
            result = winningHands.FirstOrDefault(emptyHand);

            return (result.Item1 != string.Empty ? true : false);

        }


    }
}

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

            int winningHand = 0;

            foreach (var triplet in hand)
            {
                if (triplet.Item1 == triplet.Item2 && triplet.Item1 == triplet.Item3 && GetValueOfCard(triplet.Item1) > winningHand)
                {
                    winningHand = GetValueOfCard(triplet.Item1);
                    result = triplet;
                }
            }
            return winningHand > 0;
        }

        public int GetValueOfCard(string card)
        {
            if (Int32.TryParse(card, out int result)) return result;

            switch (card.ToUpper())
            {
                case "J": { return 11; break; }
                case "Q": { return 12; break; }
                case "K": { return 13; break; }
                case "A": { return 14; break; }
                default: return 0;
            }
        }

    }
}

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

            List<Tuple<string, string, string>> triple = new List<Tuple<string, string, string>>();

            for (int i = 0; i < hand.Count(); i++)
            {
                if (hand.ElementAt(i).Item1 == hand.ElementAt(i).Item2 && hand.ElementAt(i).Item2 == hand.ElementAt(i).Item3)
                    triple.Add(hand.ElementAt(i));
            }

            if (triple.Count() == 0)
                return false;

            if (triple.Count() == 1)
            {
                result = triple.First();
                return true;
            }

            // If there are more triples, to detemine who has the best hand
            string bestPair = triple.First().Item1;

            // Need to turn "bestPair" into a number as well
            if (bestPair == "A")
                bestPair = "14";
            else if (bestPair == "K")
                bestPair = "13";
            else if (bestPair == "Q")
                bestPair = "12";
            else if (bestPair == "J")
                bestPair = "11";

            string comPair;
            int index = 0;

            for (int i = 1; i < triple.Count(); i++)
            {
                // Turning them to numbers before parsing
                if (triple[i].Item1 == "A")
                    comPair = "14";
                else if (triple[i].Item1 == "K")
                    comPair = "13";
                else if (triple[i].Item1 == "Q")
                    comPair = "12";
                else if (triple[i].Item1 == "J")
                    comPair = "11";
                else
                    comPair = triple[i].Item1;

                // Comparing the numbers to get the highest
                if (int.Parse(comPair) > int.Parse(bestPair))
                {
                    bestPair = comPair;
                    index = i;
                }
            }

            // Found the winner
            result = triple[index];
            return true;
        }

    }
}

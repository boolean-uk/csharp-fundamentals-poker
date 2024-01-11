using System;
using System.Collections;
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
            result = new Tuple<string,string>(string.Empty, string.Empty);

            List<Tuple<string, string>> pairs = new List<Tuple<string, string>>();

            for (int i = 0; i < hand.Count(); i++)
            {
                if (hand.ElementAt(i).Item1 == hand.ElementAt(i).Item2)
                    pairs.Add(hand.ElementAt(i));
            }

            if (pairs.Count() == 0)
                return false;

            if (pairs.Count() == 1)
            {
                result = pairs.First();
                return true;
            }

            // If there are more pairs, to detemine who has the best hand
            string bestPair = pairs.First().Item1;

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
            
            for (int i = 1; i < pairs.Count(); i++)
            {
                // Turning them to numbers before parsing
                if (pairs[i].Item1 == "A")
                    comPair = "14";
                else if (pairs[i].Item1 == "K")
                    comPair = "13";
                else if (pairs[i].Item1 == "Q")
                    comPair = "12";
                else if (pairs[i].Item1 == "J")
                    comPair = "11";
                else
                    comPair = pairs[i].Item1;

                // Comparing the numbers to get the highest
                if (int.Parse(comPair) > int.Parse(bestPair))
                {
                    bestPair = comPair;
                    index = i;
                }
            }

            // Found the winner
            result = pairs[index];
            return true;
        }
        public int GetValueOfCard(string card)
        {
            int value = 0;

            switch (card)
            {
                case "A":
                    value = 14;
                    break;

                case "K":
                    value = 13;
                    break;

                case "Q":
                    value = 12;
                    break;

                case "J":
                    value = 11;
                    break;
            }

            if (value == 0)
                value = int.Parse(card);

            return value;
        }
    }
}

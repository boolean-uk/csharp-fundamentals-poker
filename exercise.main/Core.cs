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
        Dictionary<string, int> _values = new Dictionary<string, int>();
        public Dictionary<string, int> Values { get { return _values; } set { _values = value; } }

        public Core()
        {
            populateValues();
        }

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty);

            List<Tuple<string, string>> winningHands = new List<Tuple<string, string>>();

            //Immutable tuples >_>

            foreach (var hand in hands)
            {
                if (hand.Item1 == hand.Item2)
                {
                    winningHands.Add(hand);
                }
            }

            if (winningHands.Count == 1)
            {
                result = winningHands[0];
            }

            if (winningHands.Count > 1)
            {
                //List<int> valuedHands = new List<int>();
                result = winningHands[0];
                for (int i = 0; i < winningHands.Count; i++)
                {
                    if (Values[winningHands[i].Item1] > Values[result.Item1])
                    {
                        result = winningHands[i];
                    }

                }
                
            }





            return result.Item1 != string.Empty ? true : false;


        }
        public int GetValueOfCard(string card)
        {
            return Values[card];
        }

        public void populateValues()
        {
            Values.Add("2", 2);
            Values.Add("3", 3);
            Values.Add("4", 4);
            Values.Add("5", 5);
            Values.Add("6", 6);
            Values.Add("7", 7);
            Values.Add("8", 8);
            Values.Add("9", 9);
            Values.Add("10", 10);
            Values.Add("J", 11);
            Values.Add("Q", 12);
            Values.Add("K", 13);
            Values.Add("A", 14);
        }

    }
}
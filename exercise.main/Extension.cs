using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same

        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> cardValues = new Dictionary<string, int>();
            cardValues.Add("2", 2);
            cardValues.Add("3", 3);
            cardValues.Add("4", 4);
            cardValues.Add("5", 5);
            cardValues.Add("6", 6);
            cardValues.Add("7", 7);
            cardValues.Add("8", 8);
            cardValues.Add("9", 9);
            cardValues.Add("10", 10);
            cardValues.Add("J", 11);
            cardValues.Add("Q", 12);
            cardValues.Add("K", 13);
            cardValues.Add("A", 14);

            if (cardValues.ContainsKey(card))
            {
                return cardValues[card];
            }
            return 0;  //failed case         
        }
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {

            int highestPair = 0;
            string highestFace = string.Empty;
            foreach (var triple in hand)
            {
                if (triple.Item1 == triple.Item2 && triple.Item1 == triple.Item3) //is triple
                {
                    if (GetValueOfCard(triple.Item2) > highestPair)
                    {
                        highestPair = GetValueOfCard(triple.Item2);
                        highestFace = triple.Item2;
                    }
                }
            }






            result = new Tuple<string, string, string>(highestFace, highestFace, highestFace);

            return false;
        }

    }
}

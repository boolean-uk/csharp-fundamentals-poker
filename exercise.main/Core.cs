using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {
       
        // Note:
        // IEnumerable is a class that the List inherits (ie List has all the functionality of IEnumerable)
        // IEnumerable allows you to use a foreach loop on the variable hands (which is a List of tuples)
        
        //TODO: complete the winningPair method, without chaning the method signature
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            int highestPair = 0;
            string highestFace = string.Empty;
            foreach (var pair in hands)
            {
                if (pair.Item1 == pair.Item2) //is pair
                {
                    if (GetValueOfCard(pair.Item2) > highestPair)
                    {
                        highestPair = GetValueOfCard(pair.Item2);
                        highestFace = pair.Item2;
                    }
                }
            }

            result = new Tuple<string,string>(highestFace, highestFace);

            return result.Item1!=string.Empty ? true : false;
        }
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

            if(cardValues.ContainsKey(card))
            {
                return cardValues[card];
            }
            return  0;  //failed case         
        }
    }
}

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
       
        // Note:
        // IEnumerable is a class that the List inherits (ie List has all the functionality of IEnumerable)
        // IEnumerable allows you to use a foreach loop on the variable hands (which is a List of tuples)
        
        //TODO: complete the winningPair method, without chaning the method signature
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);

            // your code here... 

            int currentHighestCardValue = 0;

            foreach (var pair in hands)
            {
                if (pair.Item1 == pair.Item2 && GetValueOfCard(pair.Item1) > currentHighestCardValue)
                {
                    currentHighestCardValue = GetValueOfCard(pair.Item1);
                    result = pair;
                }
            }

            if (currentHighestCardValue != 0)
            {
                return true;
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
                default: return 0;
            }     
        }
    }
}

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
        Dictionary<string, int> cardValue = new Dictionary<string, int>()
        {
            ["J"] = 11,
            ["Q"] = 12,
            ["K"] = 13,
            ["A"] = 14
        };
       
        // Note:
        // IEnumerable is a class that the List inherits (ie List has all the functionality of IEnumerable)
        // IEnumerable allows you to use a foreach loop on the variable hands (which is a List of tuples)
        
        //TODO: complete the winningPair method, without chaning the method signature
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);
            int winnerValue = 0;

            foreach(Tuple<string, string> pair in hands)
            {
                if (pair.Item1.Equals(pair.Item2))
                {
                                   
                    if (GetValueOfCard(pair.Item1) > winnerValue ) 
                    {
                        result = pair;
                        winnerValue = GetValueOfCard(pair.Item1);
                    }
                }
            }

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            if (cardValue.ContainsKey(card))
            {
                return cardValue[card];
            }
            else
            {
                return int.Parse(card);
            }
        }
    }
}

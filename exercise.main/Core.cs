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
            int winningScore = 0;
            foreach (var pair in hands)
            {
                if(pair.Item1 == pair.Item2)
                {
                    int score = GetValueOfCard(pair.Item1) + GetValueOfCard(pair.Item2);
                    if (winningScore < score)
                    {
                        winningScore = score;
                        result = pair;
                    }
                }
                
            }

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> cardValue = new Dictionary<string, int>()
            {
                { "2", 2 },
                { "3", 3 }, 
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "10", 10 },
                { "J", 11 },
                { "Q", 12 },
                { "K", 13 },
                { "A", 14 }
            };

            if(cardValue.ContainsKey(card))
            {
                return cardValue[card];
            }
            return  0; //No such card exists.           
        }
    }
}

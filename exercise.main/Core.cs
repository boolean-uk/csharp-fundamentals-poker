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
        Dictionary<string, int> Values = new Dictionary<string, int>()
        {
            { "1", 1 },
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

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty); ;

            foreach (var tuple in hand)
            {
                if (tuple.Item1 == tuple.Item2)
                {
                    if (result.Item1 == string.Empty)
                    {
                        result = tuple;
                    }
                    else
                    {
                        int score1 = GetValueOfCard(tuple.Item1) + GetValueOfCard(tuple.Item2);
                        int score2 = GetValueOfCard(result.Item1) + GetValueOfCard(result.Item2);

                        result = score1 > score2 ? tuple : result;
                    }
                }
            }
          

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            return  Values.GetValueOrDefault(card);           
        }
    }
}

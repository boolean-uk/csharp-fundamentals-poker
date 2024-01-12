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
       
        
        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);

            foreach (var pair in hand)
            {
                if (pair.Item1 == pair.Item2) {
                    if (GetValueOfCard(pair.Item1) > GetValueOfCard(result.Item1))
                    {
                        result = pair;
                    }
                };
            }




            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            if (string.IsNullOrEmpty(card)) { return 0; }
            if(card == "J") { return 11; }
            if(card == "Q") { return 12; }
            if(card == "K") { return 13; }
            if(card == "A") { return 14; }

            return int.Parse(card);
        }
    }
}

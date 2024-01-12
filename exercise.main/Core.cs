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

            int winningHand = 0;

            foreach (var pair in hand)
            {
                if (pair.Item1 == pair.Item2 && GetValueOfCard(pair.Item1) > winningHand)
                {
                    winningHand = GetValueOfCard(pair.Item1);
                    result = pair;
                }
            }
            return winningHand > 0;
        }
        public int GetValueOfCard(string card)
        {
            if(Int32.TryParse(card, out int result)) return result;
            
            switch (card.ToUpper())
            {
                case "J": { return 11; break; }
                case "Q": { return 12; break; }
                case "K": { return 13; break; }
                case "A": { return 14; break; }
                default: return 0;
            }
        }
    }
}

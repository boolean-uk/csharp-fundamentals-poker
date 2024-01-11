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
       private Dictionary<string, int> _specialCardValues = new Dictionary<string, int>
       {
           {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
       };

        
        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty);
            foreach (Tuple<string,string> hand in hands)
            {
                if (hand.Item1 == hand.Item2)
                {
                    if (GetValueOfCard(hand.Item1) > GetValueOfCard(result.Item1))
                    {
                        result = hand;
                    }
                }
            }
            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            if (card.Length == 0)
            {
                return 0;
            }
            if (_specialCardValues.ContainsKey(card))
            {
                return _specialCardValues[card];
            }
            return int.Parse(card);
        }
    }
}

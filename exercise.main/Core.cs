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
       
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
    {
        int maxValue = -1;
        Tuple<string, string> winningPair = Tuple.Create(string.Empty, string.Empty);

        foreach (var hand in hands)
        {
            
            int value1 = GetValueOfCard(hand.Item1);
            int value2 = GetValueOfCard(hand.Item2);

            
            if (value1 == value2)
            {
                
                if (value1 > maxValue)
                {
                    maxValue = value1;
                    winningPair = hand;
                }
            }
        }

        result = winningPair;

        return winningPair.Item1 != string.Empty;
    }

    public int GetValueOfCard(string card)
    {
        switch (card)
        {
            case "J":
                return 11;
            case "Q":
                return 12;
            case "K":
                return 13;
            case "A":
                return 14;
            default:
                if (int.TryParse(card, out int value))
                    return value;
                return 0; 
        }
    }    
}
}




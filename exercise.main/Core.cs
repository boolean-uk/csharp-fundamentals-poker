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

        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
    {
        Dictionary<int, List<Tuple<string, string>>> valueToCards = new Dictionary<int, List<Tuple<string, string>>>();

        foreach (var cardPair in hands)
        {
            int value1 = GetValueOfCard(cardPair.Item1);
            int value2 = GetValueOfCard(cardPair.Item2);

           
            if (!valueToCards.ContainsKey(value1))
                valueToCards[value1] = new List<Tuple<string, string>>();
            valueToCards[value1].Add(cardPair);
    
            if (value1 != value2)
            {
                if (!valueToCards.ContainsKey(value2))
                    valueToCards[value2] = new List<Tuple<string, string>>();
                valueToCards[value2].Add(cardPair);
            }

            if (value1 == value2)
            {
                if (!valueToCards.ContainsKey(value1))
                    valueToCards[value1] = new List<Tuple<string, string>>();
                valueToCards[value1].Add(cardPair);
            } 
          
        }

        int maxValue = -1;
        Tuple<string, string> winningPair = null;

        foreach (var pair in valueToCards)
        {
            if (pair.Value.Count >= 2 && pair.Key > maxValue)
            {
                maxValue = pair.Key;
                winningPair = pair.Value[0];
            }
        }

        result = winningPair ?? new Tuple<string, string>(string.Empty, string.Empty);

        return winningPair != null;
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




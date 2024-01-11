using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hands, out Tuple<string, string, string> result)
    {
        Dictionary<int, List<Tuple<string, string, string>>> valueToCards = new Dictionary<int, List<Tuple<string, string, string>>>();

        foreach (var hand in hands)
        {
            int value1 = GetValueOfCard(hand.Item1);
            int value2 = GetValueOfCard(hand.Item2);
            int value3 = GetValueOfCard(hand.Item3);

          
            if (!valueToCards.ContainsKey(value1))
                valueToCards[value1] = new List<Tuple<string, string, string>>();
            valueToCards[value1].Add(hand);


            if (value1 != value2)
            {
                if (!valueToCards.ContainsKey(value2))
                    valueToCards[value2] = new List<Tuple<string, string, string>>();
                valueToCards[value2].Add(hand);
            }

          
            if (value2 != value3 && value1 != value3)
            {
                if (!valueToCards.ContainsKey(value3))
                    valueToCards[value3] = new List<Tuple<string, string, string>>();
                valueToCards[value3].Add(hand);
            }
            if (value1 == value2 && value2 == value3)
            {
                if (!valueToCards.ContainsKey(value1))
                    valueToCards[value1] = new List<Tuple<string, string, string>>();
                valueToCards[value1].Add(hand);
            }

        }

        
        int maxValue = -1;
        Tuple<string, string, string> winningHand = null;

        foreach (var pair in valueToCards)
        {
            if (pair.Value.Count >= 3 && pair.Key > maxValue)
            {
                maxValue = pair.Key;
                winningHand = pair.Value[0];
            }
        }

        result = winningHand ?? new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

        return winningHand != null;
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

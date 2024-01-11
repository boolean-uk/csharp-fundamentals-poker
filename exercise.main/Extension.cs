using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {  
        
    // For each hand, get the hand card values
    // check that the hand values are all the same
    // if not the same, ignore this hand
    // if all 3 cards are the same, mark this hand as a triplet 
    // and check if this triplet is of bigger value of a previous triplet
    // if bigger, then save this triplet as the result
    // finally, return true if result is a valid triplet, false if no triplet found
        

        public bool winningThree(IEnumerable<Tuple<string, string, string>> hands, out Tuple<string, string, string> result)
    {
        int maxValue = -1;
        Tuple<string, string, string> winningHand = Tuple.Create(string.Empty, string.Empty, string.Empty);

        foreach (var hand in hands)
        {
            
            int value1 = GetValueOfCard(hand.Item1);
            int value2 = GetValueOfCard(hand.Item2);
            int value3 = GetValueOfCard(hand.Item3);

            
            if (value1 == value2 && value2 == value3)
            {
                
                if (value1 > maxValue)
                {
                    maxValue = value1;
                    winningHand = hand;
                }
            }
        }

        result = winningHand;

        // Return true if a valid triplet is found, otherwise return false
        return winningHand.Item1 != string.Empty;
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

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
            // Inetger to check highest value
            int highestHand = 0;
            
            //resultTuple
            result = new Tuple<string, string>(string.Empty, string.Empty);

            //Loop through all tuples and replace currently highest one if there is higher pair
            foreach (var pair in hand) 
            {
                if (pair.Item1 == pair.Item2 && GetValueOfCard(pair.Item1) > highestHand)
                {
                    highestHand = (GetValueOfCard(pair.Item1));
                    result = pair;
                   
                }
            }

            return result.Item1!=string.Empty ? true : false;

        }
        public int GetValueOfCard(string card)
        {
            int result = 0;

            // try to convert to int, and check if the value is between 2 and 10
            if (int.TryParse(card, out int cardValue) && cardValue >= 2 && cardValue <= 10 ) 
            {
                result = cardValue;
            }
            //otherwise, convert following chars to corresponding ints
            else
            {
                switch (card)
                {
                    case "J":
                        result = 11;
                        break;

                    case "Q":
                        result = 12;
                        break;

                    case "K":
                        result = 13;
                        break;

                    case "A":
                        result = 14;
                        break;
                }
            }; 
            return result;
        }
    }
}

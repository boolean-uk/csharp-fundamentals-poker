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


            var groupedCards = hand.GroupBy(card => card.Item1);


            var pairGroup = groupedCards.FirstOrDefault(group => group.Count() >= 2);

            if (pairGroup != null)
            {
                // Get the highest pair value
                var pairValue = GetValueOfCard(pairGroup.Key);

                // Find the highest pair in the hand
                var highestPair = hand.Where(card => card.Item1 == pairGroup.Key)
                                      .OrderByDescending(card => GetValueOfCard(card.Item2))
                                      .FirstOrDefault();

                result = highestPair;
                return true;
            }

            return false;


           // return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            switch (card)
            {
                case "J": return 11;
                case "Q": return 12;
                case "K": return 13;
                case "A": return 14;
                default:
                    if (int.TryParse(card, out int value))
                        return value;
                    else
                        return 0; // Invalid card value


            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {

        // Note:
        // IEnumerable is a class that the List inherits (ie List has all the functionality of IEnumerable)
        // IEnumerable allows you to use a foreach loop on the variable hands (which is a List of tuples)

        //TODO: complete the winningPair method, without chaning the method signature
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result) { 



            result = new Tuple<string, string>(string.Empty, string.Empty);


            // your code here...          

            List<Tuple<string, string>> winning_Hands =
            hands.Where(hand => hand.Item1 == hand.Item2).ToList();

            int current_sum = 0;
            int hand_sum = 0;

            foreach (var item in winning_Hands)
            {
                hand_sum = GetValueOfCard(item.Item1) + GetValueOfCard(item.Item2);
                if (hand_sum > current_sum)
                {
                    current_sum = hand_sum;
                    result = item;
                }
            }

            return result.Item1 != string.Empty? true : false;
        }

        public int GetValueOfCard(string card)
        {
            var card_Values = new Dictionary<string, int>()
            {
                { "2", 2},
                { "3", 3},
                { "4", 4},
                { "5", 5},
                { "6", 6},
                { "7", 7},
                { "8", 8},
                { "9", 9},
                { "10", 10},
                { "J", 11},
                { "Q", 12},
                { "K", 13},
                { "A", 14}
            };

            if (card_Values.TryGetValue(card, out int cardValue))
            {
                return cardValue;

            }

            return -1;

        }
    }
}
    


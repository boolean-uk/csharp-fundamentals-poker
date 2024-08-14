using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            List<Tuple<string, string, string>> winning_Hands =
            hand.Where(hand => hand.Item1 == hand.Item2 && hand.Item1 == hand.Item3).ToList();

            int current_sum = 0;
            int hand_sum = 0;

            foreach (var item in winning_Hands)
            {
                hand_sum = GetValueOfCard(item.Item1) + GetValueOfCard(item.Item2) + GetValueOfCard(item.Item3);
                if (hand_sum > current_sum)
                {
                    current_sum = hand_sum;
                    result = item;
                }
            }


            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            return false;
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
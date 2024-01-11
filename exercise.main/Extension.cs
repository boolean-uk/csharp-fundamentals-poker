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
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
            Dictionary<string, int> valueToImageCards = new Dictionary<string, int>()
            {
                {"J",11},
                {"Q",12},
                {"K",13},
                {"A",14},
            };
            int temp = 0;


            foreach (var cards in hand)
            {
                if (cards.Item1 == cards.Item2 && cards.Item2 == cards.Item3)
                {
                    int sum = 0;
                    if (valueToImageCards.ContainsKey(cards.Item1))
                    {
                        sum = valueToImageCards[cards.Item1] * 3;                        
                    }
                    else
                    {
                        sum = int.Parse(cards.Item1) * 3;
                    }
                    if (sum > temp)
                    {
                        temp = sum;
                        result = cards;
                    }
                }
            }
            return result.Item1 != string.Empty ? true : false;           
        }

    }
}

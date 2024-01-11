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


            int highestHandValue = 0;


            foreach (var pair in hand)
            {
                if (pair.Item1 == pair.Item2 && pair.Item2 == pair.Item3)
                {
                    if (highestHandValue < GetValueOfCard(pair.Item1))
                    {
                        highestHandValue = GetValueOfCard(pair.Item1);
                        result = pair;
                    };





                }

                






               
            }

             return result.Item1 != string.Empty ? true : false;
        }
        
       
        Dictionary<string, int> highCards = new Dictionary<string, int>
            { {"J",11},
              {"Q",12},
              {"K",13},
              {"A",14},

            };
        //TODO: complete the following method, keeping the signature the same

        public int GetValueOfCard(string card)

        {
            int cardValue;
            if (highCards.TryGetValue(card, out cardValue))
            {
                return cardValue;
            }

            return int.Parse(card);

        }
    }
}


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
            Dictionary<string,int> valueToImageCards = new Dictionary<string,int>()
            {
                {"J",11},
                {"Q",12},
                {"K",13},
                {"A",14},
            };                
            int temp = 0;
            

            foreach (var cards in hand) 
            {
                if (cards.Item1 == cards.Item2)
                {
                    int sum = 0;                
                    if (valueToImageCards.ContainsKey(cards.Item1))
                    {
                        sum = valueToImageCards[cards.Item1] * 2;                                                                     
                    }
                    else
                    {
                        sum = int.Parse(cards.Item1) * 2;
                    }
                    if (sum > temp) 
                    {
                        temp = sum;
                        result = cards;
                    }                    
                }                
            }            
            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> valueToImageCards = new Dictionary<string, int>()
            {
                {"J",11},
                {"Q",12},
                {"K",13},
                {"A",14},
            };
            return valueToImageCards.ContainsKey(card) ? valueToImageCards[card] : int.Parse(card);
        }
    }
}
/*
 * else 
                {
                    if (!pairFound)
                    {
                        int firstValue = valueToImageCards.ContainsKey(cards.Item1) ? valueToImageCards[cards.Item1] : int.Parse(cards.Item1);
                        int secondValue = valueToImageCards.ContainsKey(cards.Item2) ? valueToImageCards[cards.Item2] : int.Parse(cards.Item2);
                        int sum = firstValue + secondValue;
                        if (sum > temp)
                        {
                            temp = sum;
                            result = cards;
                        }
                    }
                }
 */
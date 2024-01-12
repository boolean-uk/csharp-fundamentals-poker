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
            //result = new Tuple<string,string>(string.Empty, string.Empty);
            result = iterateHands(hand);

            return result.Item1!=string.Empty ? true : false;
        }

        public Tuple<string, string> iterateHands(IEnumerable<Tuple<string, string>> hand)
        {
            Dictionary<Tuple<string, string>, int> pairs = new Dictionary<Tuple<string, string>, int>(); 
            foreach (var item in hand)
            {
                if (decidePair(item.Item1, item.Item2).Item1)
                {
                    pairs.Add(item, decidePair(item.Item1, item.Item2).Item2);
                }
            }
            if(pairs.Count == 0) {
                return new Tuple<string, string>(string.Empty, string.Empty);
            }
            return pairs.OrderByDescending(i => i.Value).First().Key;
            
        }

        public Tuple<bool,int> decidePair(string card1, string card2)
        {
            int card1Value = GetValueOfCard(card1);
            int card2Value = GetValueOfCard(card2);
            
            return Tuple.Create(card1Value == card2Value, card1Value + card2Value);
        }

        public int GetValueOfCard(string card)
        {
            int value = 0;
            try
            {
                value = Int32.Parse(card);
            }
            catch(FormatException) {
                switch(card)
                {
                    case "A":
                        value = 14;
                        break;
                    case "K":
                        value = 13;
                        break;
                    case "Q":
                        value = 12;
                        break;
                    case "J":
                        value = 11;
                        break;
                }
            }
            return value;           
        }
    }
}

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
           

            foreach (var card in hand)
            {
                if (card.Item1 == card.Item2)
                {
                    if (result.Item1 != string.Empty && GetValueOfCard(card.Item1) > GetValueOfCard(result.Item1))
                    {
                        result = card;
                    }
                    else if (result.Item1 == string.Empty)
                    {
                        result = card;
                    }
                    
                    
                    
                }
            }

          

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
           switch (card)
            {
                case "A": 
                    return 14;
                case "K":
                    return 13;
                case "Q":
                    return 12;
                case "J":
                    return 11;
                default: return int.Parse(card);
            }           
        }
    }
}

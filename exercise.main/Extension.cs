using exercise.main.Classes;
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
            

            foreach (var pair in hand)
            {
                if (pair.Item1 == pair.Item2 && pair.Item1 == pair.Item3)
                {
                    if (result.Item1 != string.Empty && GetValueOfCard(pair.Item1) > GetValueOfCard(result.Item1))
                    {
                        result = pair;

                        if (GetValueOfCard(result.Item1) < GetValueOfCard(pair.Item3))
                        {
                            result = pair;
                        }
                    }
                    else if (result.Item1 == string.Empty)
                    {
                        result = pair;
                        
                    }
                }
                
            }
            return result.Item1 != string.Empty ? true : false;
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

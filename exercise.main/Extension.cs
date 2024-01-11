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

            foreach (Tuple<string, string, string> triple in hand)
            {
                if (triple.Item1 == triple.Item2 && triple.Item2 == triple.Item3)
                {
                    if (result.Item1 != string.Empty)
                    {
                        if (GetValueOfCard(triple.Item1) > GetValueOfCard(result.Item1))
                        {
                            result = triple;
                        }
                    }
                    else
                    {
                        result = triple;
                    }

                }
            }

            return result.Item1 != string.Empty ? true : false;
        }

        public int GetValueOfCard(string card)
        {
            switch (card)
            {
                case "A": return 14;
                case "K": return 13;
                case "Q": return 12;
                case "J": return 11;
                default: return Int32.Parse(card);
            }
        }

    }
}

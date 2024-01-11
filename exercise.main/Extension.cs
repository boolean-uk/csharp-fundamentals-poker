using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension : Core
    {

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);



            foreach (Tuple<string, string, string> pair in hand)
            {
                if (pair.Item1 != pair.Item2 || pair.Item1 != pair.Item3) continue;

                if (result.Item1 == string.Empty)
                {
                    result = pair;
                }
                else if (GetValueOfCard(pair.Item1) > GetValueOfCard(result.Item1))
                {
                    result = pair;
                }
            }


            return result.Item1 != string.Empty ? true : false;
        }

    }
}

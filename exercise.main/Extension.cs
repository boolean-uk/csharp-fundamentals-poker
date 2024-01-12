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
            //Call Core to use its getValueOfCard function
            Core core = new Core();

            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            //Go through all hands
            foreach (var pair in hand)
            {
                //Is it a "pair"?
                if (pair.Item1 == pair.Item2 && pair.Item1 == pair.Item3)
                {
                    //Is the pair bigger than the currently saved one?
                    if (core.GetValueOfCard(pair.Item1) > core.GetValueOfCard(result.Item1))
                    {
                        result = pair;
                    }

                };
            }

            return result.Item1 != string.Empty ? true : false; ;
        }

    }
}

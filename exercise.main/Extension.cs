using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        Core core = new Core();
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            foreach (Tuple<string, string, string> triple in hand)
            {
                if (triple.Item1 == triple.Item2 && triple.Item2 == triple.Item3 && core.GetValueOfCard(triple.Item1) > core.GetValueOfCard(result.Item1))
                    result = triple;
            }
            return result.Item1 != string.Empty ? true : false;
        }

    }
}

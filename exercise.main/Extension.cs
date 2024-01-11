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


            List<Tuple<Tuple<string, string, string>, int>> playersWithTriples;
            Tuple<Tuple<string, string, string>, int> playerWithTriple;

            playersWithTriples = new List<Tuple<Tuple<string, string, string>, int>>();

            foreach (var pair in hand)
            {
                if (pair.Item1 == pair.Item2)
                {
                    int pairValue = core.GetValueOfCard(pair.Item1);
                    playerWithTriple = new Tuple<Tuple<string, string, string>, int>(pair, pairValue);
                    playersWithTriples.Add(playerWithTriple);

                    result = core.FindHighestCard(playersWithTriples);

                }
                else
                {
                    continue;
                }
            }





            return result.Item1 != string.Empty ? true : false;
        }

    }
}

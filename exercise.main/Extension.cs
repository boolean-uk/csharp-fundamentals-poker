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
        Core core = new Core();
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
            int card1, card2, card3, value;
            List<Tuple<string, string, string, int>> players = new List<Tuple<string, string, string, int>>();
            Tuple<string, string, string, int> temp;
            foreach(var pair in hand)
            {
                card1 = core.GetValueOfCard(pair.Item1);
                card2 = core.GetValueOfCard(pair.Item2);
                card3 = core.GetValueOfCard(pair.Item3);
                if( card1 == card2 && card1 == card3 )
                {
                    value = core.GetValueOfCard(pair.Item1);
                    temp = new Tuple<string, string, string, int>(pair.Item1, pair.Item2, pair.Item3, value);
                    players.Add(temp);
                }
            }
            if(players.Count > 0)
            {
                int valueTemp = 0;
                foreach(var p in players)
                {
                    if(valueTemp < p.Item4)
                    {
                        valueTemp = p.Item4;
                        result = new Tuple<string, string, string>(p.Item1, p.Item2, p.Item3);
                    }
                }
            }
            return result.Item1 != string.Empty ? true : false;
        }

    }
}

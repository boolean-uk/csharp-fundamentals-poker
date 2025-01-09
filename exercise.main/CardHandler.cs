using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class CardHandler
    {
        Dictionary<string, int> CardValues { get; set; } = new Dictionary<string, int>
            {
                {"1",1 },
                {"2",2},
                {"3",3},
                {"4",4},
                {"5",5},
                {"6",6},
                {"7",7 },
                {"8",8},
                {"9",9},
                {"10",10},
                {"J", 11},
                {"Q", 12},
                {"K", 13 },
                {"A",14},
            };
        public CardHandler() { }

        public int GetValueOfCard(string card)
        {
            return CardValues[card];
        }

        public bool isPair(Tuple<string, string> pair)
        {
            return pair.Item1 == pair.Item2;
        }

        public bool isTriplet(Tuple<string, string, string> triplet) {
            return triplet.Item1 == triplet.Item2 && triplet.Item2 == triplet.Item3;
        }
    }
}

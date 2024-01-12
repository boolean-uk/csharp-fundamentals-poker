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

            // Function takes a list with tuples, 1 tuple is 1 hand with 2 cards
            // result is the winning pair or empty if there is no similar cards

            result = new Tuple<string, string>(string.Empty, string.Empty);
            
            // first result can change if the next tup is of higher number
            // should check if the result is not empty and not bigger than previous tup
            
            foreach (var tup in hand)
            {
                if (result.Item1 == string.Empty && tup.Item1.Equals(tup.Item2))
                {
                    result = tup;
                }
                if (result.Item1 != string.Empty && tup.Item1 == tup.Item2 && GetValueOfCard(result.Item1) < GetValueOfCard(tup.Item1))
                {
                    result = tup;
                }
            }
            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            var cards = new Dictionary<string, int> {
                {"1",1},{"2",2},{"3",3}, {"4",4}, {"5",5}, {"6",6},
                {"7",7},{"8",8},{"9",9}, {"10",10},{"J",11},{"Q",12},
                {"K",13},{"A",14}
            };
            return cards[card];           
        }
    }
}

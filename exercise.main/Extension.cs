using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {

         // Poker cards and there value
        private Dictionary<string, int> cards = new Dictionary<string, int> {
            {"2",2}, {"3",3}, {"4",4}, {"5",5}, {"6",6}, {"7",7}, {"8",8},{"9",9},{"10",10},{"J",11},{"Q",12},{"K",13},{"A",14}
        };

        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            //TODO find a pair
            foreach (var item in hand) {
                if (item.Item1.Equals(item.Item2) && item.Item1.Equals(item.Item3)) { //!Pair found
                    if (checkHighestPair(item.Item1, result.Item1)) {
                        result = item;
                    }
                    
                }
            }

            return result.Item1!=string.Empty ? true : false;
        }

        private bool checkHighestPair(string toup, string res) {
            cards.TryGetValue(toup, out int toupVal);
            cards.TryGetValue(res, out int resVal);
            if (toupVal > resVal) {
                return true;
            }
            return false;
        }

        
    }
}

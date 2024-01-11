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
       
        // Poker cards and there value
        private Dictionary<string, int> cards = new Dictionary<string, int> {
            {"2",2}, {"3",3}, {"4",4}, {"5",5}, {"6",6}, {"7",7}, {"8",8},{"9",9},{"10",10},{"J",11},{"Q",12},{"K",13},{"A",14}
        };
        
        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);
           
            foreach (var touple in hand) {
                string t1 = touple.Item1;
                string t2 = touple.Item2;
                if (touple.Item1.Equals(touple.Item2)) { //!found a pair
                    // Check if newly faound pair is larger.
                    if (checkHighestPair(touple.Item1, result.Item1)) {
                        result = touple;
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

        public int GetValueOfCard(string card){
            cards.TryGetValue(card, out int value);
            return value;           
        }
    }
}

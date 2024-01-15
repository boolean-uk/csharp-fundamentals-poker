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


            foreach (var triplePair in hand) { 

                if (triplePair.Item1 == triplePair.Item2 && triplePair.Item3 == triplePair.Item2 
                    && GetValueOfCard(triplePair.Item1) > GetValueOfCard(result.Item1)){
                    result = triplePair;
                }
            }

            return result.Item1 != string.Empty ? true : false;
        }

        public int GetValueOfCard(string card)
        {
            if (card == "2")
            {
                return 2;
            }
            else if (card == "3")
            {
                return 3;
            }
            else if (card == "4")
            {
                return 4;
            }
            else if (card == "5")
            {
                return 5;
            }
            else if (card == "6")
            {
                return 6;
            }
            else if (card == "7")
            {
                return 7;
            }
            else if (card == "8")
            {
                return 8;
            }
            else if (card == "9")
            {
                return 9;
            }
            else if (card == "10")
            {
                return 10;
            }
            else if (card == "J")
            {
                return 11;
            }
            else if (card == "Q")
            {
                return 12;
            }
            else if (card == "K")
            {
                return 13;
            }
            else if (card == "A")
            {
                return 14;
            }
            else
            {
                return 0;
            }

        }

    }
}

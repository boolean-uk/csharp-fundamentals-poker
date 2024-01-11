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

            int currentHighest = 0;
            int potentialHigher = 0;
            int hands = hand.Count();

            foreach (Tuple<string, string, string> three in hand)
            {
                if (three.Item1 == three.Item2 && three.Item1 == three.Item3)
                {
                    potentialHigher = GetValueOfCard(three.Item1);
                    if (potentialHigher > currentHighest)
                    {
                        currentHighest = potentialHigher;
                        result = three;
                    }
                }
            }


            return result.Item1 != string.Empty ? true : false;
        }



        public int GetValueOfCard(string card)
        {
            switch (card)
            {
                case ("2"):
                    return 2;
                case ("3"):
                    return 3;
                case ("4"):
                    return 4;
                case ("5"):
                    return 5;
                case ("6"):
                    return 6;
                case ("7"):
                    return 7;
                case ("8"):
                    return 8;
                case ("9"):
                    return 9;
                case ("10"):
                    return 10;
                case ("J"):
                    return 11;
                case ("Q"):
                    return 12;
                case ("K"):
                    return 13;
                case ("A"):
                    return 14;
            }
            return 0;
        }

    }
}

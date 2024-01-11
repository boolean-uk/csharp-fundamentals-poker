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


            string FirstCard = "";
            string SecondCard = "";
            string ThirdCard = "";

            int intValueOfCard = 0;
            int HighestPair = 0;

            foreach (Tuple<string, string, string> cardTriple in hand)
            {

                FirstCard = cardTriple.Item1;
                SecondCard = cardTriple.Item2;

                if (FirstCard == SecondCard || FirstCard == cardTriple.Item3)
                {
                    intValueOfCard = GetValueOfCard(FirstCard);
                    if (intValueOfCard > HighestPair)
                    {
                        HighestPair = intValueOfCard;
                        result = cardTriple;
                    }

                }



            }

            return result.Item1 != string.Empty ? true : false;
        }


        public int GetValueOfCard(string card)
        {
            int ValueOfCard = 0;
            if (card == string.Empty) ValueOfCard = 0;
            else if (card == "J") { ValueOfCard = 11; }
            else if (card == "Q") { ValueOfCard = 12; }
            else if (card == "K") { ValueOfCard = 13; }
            else if (card == "A") { ValueOfCard = 14; }
            else { ValueOfCard = int.Parse(card); }
            return ValueOfCard;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.ExceptionServices;
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
            result = new Tuple<string,string>(string.Empty, string.Empty);
            //go through the list of tuples

            //check if the tuple is a pair

            //if it is a pair, check if the value of the card is
            //bigger than any other pair we have found
            //
            //if it is bigger, then set this pair as the result

            //need var that updates the current highest pair


            string FirstCard = "";
            string SecondCard = "";

            int intValueOfCard = 0;
            int HighestPair = 0;

            foreach (Tuple<string, string> cardPair in hand)
            {
              
                FirstCard = cardPair.Item1; 
                SecondCard = cardPair.Item2;

                if (FirstCard == SecondCard)
                {
                    intValueOfCard = GetValueOfCard(FirstCard);
                    if (intValueOfCard > HighestPair)
                    {
                        HighestPair = intValueOfCard;
                        result = cardPair;
                    }

                }
              
                
               
            }

            return result.Item1!=string.Empty ? true : false;
        }






        public int GetValueOfCard(string card)
        {
            int ValueOfCard = 0;
            if (card == string.Empty) ValueOfCard = 0;
            else if (card == "J") { ValueOfCard= 11; }
            else if (card == "Q") { ValueOfCard = 12; }
            else if (card == "K") { ValueOfCard = 13; }
            else if (card == "A") { ValueOfCard = 14; }
            else {ValueOfCard = int.Parse(card); }
            return ValueOfCard;     
        }
    }
}

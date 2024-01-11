using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension:Core
    {
        public Dictionary<string, int> cards2;
        public Extension() 
        {
            cards2 = new Dictionary<string, int>(base.cards);
        }

        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            List<(string, string, string)> temp = new List<(string, string, string)>();
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);


            foreach ((string card1, string card2, string card3) in hand)  // Or var tuple in hand
            {
               

                //Check if the cards are in treplet:
                if (GetValueOfCard(card1) == GetValueOfCard(card2) && GetValueOfCard(card1) == GetValueOfCard(card3))
                {
                    temp.Add((card1, card2, card3));
                }
            }

            // Check if several winning hands:
            if (temp.Count > 1)
            {
                int checkHigest = 0;
                foreach ((string card1, string card2, string card3) in temp)
                {
                    if (checkHigest < GetValueOfCard(card1))
                    {
                        checkHigest = GetValueOfCard(card1);
                        result = new Tuple<string, string, string>(card1, card2, card3);
                    }
                }
            }

            return result.Item1 != string.Empty ? true : false;

           
            
        }

        
       

    }
}

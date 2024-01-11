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
        public Dictionary<string, int> cards = new Dictionary<string, int>() { 
            { "2", 2 },

            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
            { "10", 10 },
            { "J", 11 },
            { "Q", 12 },
            { "K", 13 },
            { "A", 14 }
        
        };
       

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
          

            // List<Tuple<string, string>> temp = new List<Tuple<string, string>>();
            List<(string, string)> temp = new List<(string, string)>();
            result = new Tuple<string,string>(string.Empty, string.Empty);  // Empty tuple



        

            foreach ((string card1 , string card2)  in hand)  // Or var tuple in hand
            {
                //temp.Add((card1, card2));
                //Console.WriteLine("WRITING" + temp[0](0));

                //Check if the cards are in pair:
                if (GetValueOfCard(card1) == GetValueOfCard(card2))
                {
                    temp.Add((card1, card2));
                } 
            }

            // Check if several winning hands:
            if (temp.Count > 1)
            {
                int checkHigest = 0;
                foreach ((string card1, string card2) in temp)
                {
                    if (checkHigest < GetValueOfCard(card1))
                    {
                        checkHigest = GetValueOfCard(card1);
                        result = new Tuple<string,string>(card1, card2);
                    }
                }
            }

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            int cardResult = 0;
            
           
            if (cards.ContainsKey(card))
                // Return the value of the card in int.
            {   cardResult = cards[card];
                return cardResult;
            }   

            else {
                throw new Exception("Inncorect card type");
            }       
        }
    }
}

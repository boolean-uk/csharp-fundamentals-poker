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
        //Test before making a pull request
       
        Dictionary<string, int> cardValues = new Dictionary<string, int>();
        int temporaryWinner = 0;
        string tempWinnerstring = "";


        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);
                    

            foreach ( var pair in hand)
            {

                if(pair.Item1 == pair.Item2)
                { 
                    int valueOfCard = GetValueOfCard(pair.Item1);
                    
                    if (valueOfCard > temporaryWinner) { 
                     
                    temporaryWinner = cardValues[pair.Item1];
                    tempWinnerstring = pair.Item1;
                    result = new Tuple<string, string>(tempWinnerstring, tempWinnerstring);
                    }            
                }
            }

            return result.Item1!=string.Empty ? true : false;
        }

        public bool winningtriple(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string,string>(string.Empty, string.Empty, string.Empty);

            foreach (var pair in hand)
            {

                if (pair.Item1 == pair.Item2 && pair.Item1 == pair.Item3)
                {
                    int valueOfCard = GetValueOfCard(pair.Item1);

                    if (valueOfCard > temporaryWinner)
                    {

                        temporaryWinner = cardValues[pair.Item1];
                        tempWinnerstring = pair.Item1;
                        result = new Tuple<string, string, string>(tempWinnerstring, tempWinnerstring, tempWinnerstring);
                    }
                }
            }

            return result.Item1 != string.Empty ? true : false;

        }


            public int GetValueOfCard(string card)
        {

            if (cardValues.Count ==0 ) { populateDictionary(); }

            cardValues.TryGetValue(card, out int value);

            return  value;           
        }
        
        public void populateDictionary()
        {
            for( int i = 2; i<=10;i++ )
            {
                cardValues.Add($"{i}", i);
            }
           
            cardValues.Add("A", 14);
            cardValues.Add("K", 13);
            cardValues.Add("Q",12);
            cardValues.Add("J",11);

        }
    }
}

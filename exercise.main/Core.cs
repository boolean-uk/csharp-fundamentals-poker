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

            string winningPair = string.Empty;
            int winningValue = 0;

            foreach(Tuple<string, string> pair in hand)
            {
                if(pair.Item1.Equals(pair.Item2) && GetValueOfCard(pair.Item1)>winningValue) 
                { 
                    winningPair = pair.Item1;
                    winningValue = GetValueOfCard(pair.Item1);
                }
            }

            result = new Tuple<string,string>(winningPair, winningPair);

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {   
            Dictionary<string,int> lookup = new Dictionary<string, int>() 
            {
                {"1",1},
                {"2",2}, 
                {"3",3}, 
                {"4",4}, 
                {"5",5}, 
                {"6",6},
                {"7",7}, 
                {"8",8},
                {"9",9}, 
                {"10",10}, 
                {"J",11}, 
                {"Q",12},
                {"K",13},
                {"A",14}
            };
            return  lookup[card];           
        }
    }
}

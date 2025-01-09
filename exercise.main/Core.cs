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

        public Core() { }
        // Note:
        // IEnumerable is a class that the List inherits (ie List has all the functionality of IEnumerable)
        // IEnumerable allows you to use a foreach loop on the variable hands (which is a List of tuples)

        //TODO: complete the winningPair method, without chaning the method signature
        CardHandler handler = new CardHandler();

        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);

            // your code here...

            var winningValue = 0;
            var currentIndex = 0;
            foreach (var item in hands)
            {
                if(handler.isPair(item) && handler.GetValueOfCard(item.Item1) > winningValue)
                {
                    result = item;
                    winningValue = handler.GetValueOfCard(item.Item2);
                }
                currentIndex++;
            }
           
           

            return result.Item1!=string.Empty ? true : false;
        }

        public int GetValueOfCard(string card)
        {
            return handler.GetValueOfCard(card);
        }
    }
}

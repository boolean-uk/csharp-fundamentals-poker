using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hands, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);


            CardHandler handler = new CardHandler();
            var winningValue = 0;
            var currentIndex = 0;
            foreach (var item in hands)
            {
                if (handler.isTriplet(item) && handler.GetValueOfCard(item.Item1) > winningValue)
                {
                    result = item;
                    winningValue = handler.GetValueOfCard(item.Item2);
                }
                currentIndex++;
            }
            return result.Item1 != string.Empty ? true : false;
        }


    }

}

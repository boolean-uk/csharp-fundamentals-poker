using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        Core core = new Core();

        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            foreach (Tuple<string, string, string> tripple in hand)
            {
                string firstCard = tripple.Item1;
                string secondCard = tripple.Item2;
                string thirdCard = tripple.Item3;

                if (firstCard == secondCard && secondCard == thirdCard)
                {
                    if (result.Item1 != string.Empty)
                    {
                        if (core.GetValueOfCard(firstCard) < core.GetValueOfCard(result.Item1))
                            continue;
                    }
                    result = new Tuple<string, string, string>(firstCard, secondCard, thirdCard);
                }
            }
            return result.Item1!=string.Empty ? true : false;
        }

    }
}

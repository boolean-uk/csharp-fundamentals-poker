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
       
        // Note:
        // IEnumerable is a class that the List inherits (ie List has all the functionality of IEnumerable)
        // IEnumerable allows you to use a foreach loop on the variable hands (which is a List of tuples)
        
        //TODO: complete the winningPair method, without chaning the method signature
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);

            foreach (var hand in hands)
            {
                if (hand.Item1 == hand.Item2)
                {
                    if (result.Item1 != string.Empty)
                    {
                        if (GetValueOfCard(hand.Item1) > GetValueOfCard(result.Item1))
                        {
                            result = hand;
                        }
                    } else
                    {
                        result = hand;
                    }
                }
            }
            return result.Item1!=string.Empty ? true : false;
        }

        public bool winningTriplet(IEnumerable<Tuple<string, string, string>> hands, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            foreach (var hand in hands)
            {
                if (hand.Item1 == hand.Item2 && hand.Item2 == hand.Item3)
                {
                    if (result.Item1 != string.Empty)
                    {
                        if (GetValueOfCard(hand.Item1) > GetValueOfCard(result.Item1))
                        {
                            result = hand;
                        }
                    }
                    else
                    {
                        result = hand;
                    }
                }
            }
            return result.Item1 != string.Empty ? true : false;
        }

        public int GetValueOfCard(string card)
        {
            bool isNumericCard = int.TryParse(card, out int cardNumber);

            if (isNumericCard)
            {
                return cardNumber;
            }
            else
            {
                switch (card)
                {
                    case "J":
                        return 11;
                    case "Q":
                        return 12;
                    case "K":
                        return 13;
                    case "A":
                        return 14;
                    default:
                        return 0;
                }
            }
        }
    }
}

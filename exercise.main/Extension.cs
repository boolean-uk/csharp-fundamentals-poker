using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //public string card;
        public Dictionary<string, int> cardValues = new Dictionary<string, int>()
        {
            {"2", 2 },
            {"3" , 3 },
            {"4" , 4 },
            {"5" , 5 },
            {"6" , 6 },
            {"7" , 7 },
            {"8" , 8 },
            {"9" , 9 },
            {"10", 10},
            {"J" , 11 },
            {"Q" , 12 },
            {"K" , 13 },
            {"A" , 14 }
        };
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            // create a list to store the hand with two same values as winning hand
            List<Tuple<string, string, string>> winningHand = new List<Tuple<string, string, string>>();

            // to store the int value of the card
            List<int> winningPairValues = new List<int>();

            // find the pair in the parameter given hands (given in the tests).
            foreach (Tuple<string, string, string> pairs in hand)
            {
                if (pairs.Item1 == pairs.Item2 && pairs.Item2 == pairs.Item3)
                {
                    //add the winning hand to the List with a new Tuple > winningHand
                    // search in hands, and find a match of the same cards, if there is a pair store it in winningHands. If there 
                    // isnt a pair, return string.empty
                    winningHand.Add(pairs);
                }
            }

            if (winningHand.Count == 1)
            {
                // result is the first value of index of winningHand
                result = winningHand[0];
                // if there are more pairs in hands
            }
            else if (winningHand.Count > 1)
            {
                // then check/loop each winningHand what pairs 

                /*for(int i = 0; i < winningHand.Count; i++)
                {
                  // use the method getvalueofcard to check each value of the card in that pair.
                  // store at the same index of winningPairValues the winningHand item1
                  // Tuple<string, string> tuple = winningHand[i];
                */
                foreach (var cards in winningHand)
                {
                    winningPairValues.Add(GetValueOfCard(cards.Item1));
                }

                int winningIndex = winningPairValues.IndexOf(winningPairValues.Max());

                // what pair contains the highest value pair? 
                result = winningHand[winningIndex];
            }

            return result.Item1 != string.Empty ? true : false;
            // return false;

        }

        public int GetValueOfCard(string card)
        {
            // get value of card out of cardValues
            // key value pairs in cardValues to check the highest value of cards\
            // card toString() ? 

            if (cardValues.ContainsKey(card.ToUpper()))
            {
                return cardValues[card.ToUpper()];
            }

            return 0;
        }
    }
}


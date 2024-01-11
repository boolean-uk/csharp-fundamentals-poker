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
            bool isWinningHand = false;
            int value = 0;

            foreach (var triplet in hand)
            {
                if(compareValues(triplet.Item1, triplet.Item2) && compareValues(triplet.Item1, triplet.Item3))
                {
                    int tripletValue = calculateSum(triplet.Item1, triplet.Item2, triplet.Item3);
                    if(tripletValue > value)
                    {
                        value = tripletValue;
                        result = triplet;
                        isWinningHand = true;
                    }
                }
            }

            return isWinningHand;
        }


        /// <summary>
        /// compares 2 cards
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns> a bool value telling us if the cards are the same or not </returns>
        private bool compareValues(string input1, string input2)
        {
            return (core.GetValueOfCard(input1) == core.GetValueOfCard(input2));
        }


        /// <summary>
        /// Method for calculating sum of three hands
        /// </summary>
        /// <param name="sNum1"></param>
        /// <param name="sNum2"></param>
        /// <param name="sNum3"></param>
        /// <returns> sum of three cards in int value </returns>
        private int calculateSum(string sNum1, string sNum2, string sNum3)
        {
            return core.GetValueOfCard(sNum1) + core.GetValueOfCard(sNum2) + core.GetValueOfCard(sNum3);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            // If there are no cards in the hand, return false
            if (!hand.Any())
            {
                return false;
            }

            // Initialize highestValue with the smallest possible integer value
            int highestValue = int.MinValue;

            //Iterating through each card in the hand
            foreach (var card in hand)
            {
                //numeric value of the card
                int cardValue = GetValueOfCard(card.Item1);

                //checking if the current card has a higher value than current highest card
                if (cardValue > highestValue && card.Item1 == card.Item2 && card.Item2 == card.Item3)
                {
                    //updating the highest value
                    highestValue = cardValue;
                    result = card;

                }
            }


            // If both cards in the result have the same numeric value, it means there is a winning pair
            return result.Item1 != string.Empty ? true : false;

            //return false;
        }
        public int GetValueOfCard(string card)
        {
            //Defining a dictionary to map card values to numeric values
            Dictionary<string, int> cardValues = new Dictionary<string, int>
            {
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

            // Using the TryGetValue method to get the numeric value of the card
            if (cardValues.TryGetValue(card, out int value))
            {
                return value;
            }
            // Return 0 for unknown cards
            return 0;
        }


    }
}

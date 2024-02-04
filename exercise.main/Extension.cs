using System;
using System.Collections.Generic;
using System.Linq;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            Dictionary<string, int> cardValues = new Dictionary<string, int>();
            bool hasTriplet = false;

            foreach (var triplet in hand)
            {
                string card1 = triplet.Item1;
                string card2 = triplet.Item2;
                string card3 = triplet.Item3;

                int value1 = GetValueOfCard(card1);
                int value2 = GetValueOfCard(card2);
                int value3 = GetValueOfCard(card3);

                if (value1 == value2 && value2 == value3)
                {
                    hasTriplet = true;

                    if (!cardValues.ContainsKey(card1))
                    {
                        cardValues[card1] = value1;
                    }

                    // Add the other cards to the dictionary if not present
                    if (!cardValues.ContainsKey(card2))
                    {
                        cardValues[card2] = value2;
                    }

                    if (!cardValues.ContainsKey(card3))
                    {
                        cardValues[card3] = value3;
                    }
                }
            }

            if (hasTriplet)
            {
                var highestTriplet = cardValues.OrderByDescending(x => x.Value).FirstOrDefault();

                result = new Tuple<string, string, string>(highestTriplet.Key, highestTriplet.Key, highestTriplet.Key);
                return true;
            }

            return false;
        }

        public int GetValueOfCard(string card)
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
                    if (int.TryParse(card, out int value))
                    {
                        return value;
                    }
                    return 0;
            }
        }
    }
}

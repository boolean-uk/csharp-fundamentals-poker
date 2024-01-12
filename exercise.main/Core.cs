using System;
using System.Collections.Generic;
using System.Linq;

namespace exercise.main
{
    public class Core
    {
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty);

            if (hand == null || !hand.Any())
                return false;

            Dictionary<string, int> cardCounts = new Dictionary<string, int>();
            List<Tuple<string, string>> winningPairs = new List<Tuple<string, string>>();

            foreach (var card in hand)
            {
                string cardValue1 = card.Item1;
                string cardValue2 = card.Item2;

                // Check for a winning pair with cardValue1
                if (cardCounts.ContainsKey(cardValue1))
                {
                    cardCounts[cardValue1]++;
                    if (cardCounts[cardValue1] == 2)
                    {
                        winningPairs.Add(card);
                    }
                }
                else
                {
                    cardCounts[cardValue1] = 1;
                }

                // Check for a winning pair with cardValue2
                if (cardCounts.ContainsKey(cardValue2))
                {
                    cardCounts[cardValue2]++;
                    if (cardCounts[cardValue2] == 2)
                    {
                        winningPairs.Add(card);
                    }
                }
                else
                {
                    cardCounts[cardValue2] = 1;
                }
            }

            if (winningPairs.Any())
            {
                // Find the pair with the highest value
                result = winningPairs.OrderByDescending(pair => GetValueOfCard(pair.Item1)).First();
                return true;
            }

            return false;
        }

        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> cardValues = new Dictionary<string, int>
            {
                {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5},
                {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9},
                {"10", 10}, {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
            };

            // Use the TryGetValue method to get the value of the card
            return cardValues.TryGetValue(card, out int value) ? value : 0;
        }
    }
}

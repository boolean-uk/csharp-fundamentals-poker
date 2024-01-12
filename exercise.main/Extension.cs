using System;
using System.Collections.Generic;
using System.Linq;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool WinningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            // Dictionary to store the count of each card value
            Dictionary<string, int> cardCounts = new Dictionary<string, int>();

            // Iterate through the hand and count occurrences of each card value
            foreach (var card in hand)
            {
                string cardValue = card.Item1;
                if (cardCounts.ContainsKey(cardValue))
                {
                    cardCounts[cardValue]++;
                    // Check for a winning triplet
                    if (cardCounts[cardValue] == 3)
                    {
                        result = card;
                        Console.WriteLine($"Found a winning triplet: {card.Item1} {card.Item2} {card.Item3}");
                        return true;
                    }
                }
                else
                {
                    cardCounts[cardValue] = 1;
                }
            }

            Console.WriteLine("No winning triplet found.");
            return false;
        }
    }
}

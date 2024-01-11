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
            var groupedCards = hand.GroupBy(card => card.Item1);

            // Find the first group with three or more cards (a triplet)
            var tripletGroup = groupedCards.FirstOrDefault(group => group.Count() >= 3);

            if (tripletGroup != null)
            {
                // Get the highest triplet value
                var tripletValue = GetValueOfCard(tripletGroup.Key);

                // Find the highest triplet in the hand
                var highestTriplet = hand.Where(card => card.Item1 == tripletGroup.Key)
                                         .OrderByDescending(card => GetValueOfCard(card.Item2))
                                         .FirstOrDefault();

                result = highestTriplet;
                return true;
            }

            return false;
            
        }
        public int GetValueOfCard(string card)
        {
            switch (card)
            {
                case "J": return 11;
                case "Q": return 12;
                case "K": return 13;
                case "A": return 14; // Ace is considered 14
                default:
                    if (int.TryParse(card, out int value))
                        return value;
                    else
                        return 0; // Invalid card value
            }
        }

        }
}

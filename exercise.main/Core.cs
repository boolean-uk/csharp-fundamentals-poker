using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty);

            Dictionary<string, int> cardValues = new Dictionary<string, int>();
            bool hasPair = false;

            foreach (var pair in hand)
            {
                string card1 = pair.Item1;
                string card2 = pair.Item2;

                int value1 = GetValueOfCard(card1);
                int value2 = GetValueOfCard(card2);

                if (value1 == value2)
                {
                    hasPair = true;

                    if (!cardValues.ContainsKey(card1))
                    {
                        cardValues[card1] = value1;
                    }

                    if (!cardValues.ContainsKey(card2))
                    {
                        cardValues[card2] = value2;
                    }
                }
            }

            if (hasPair)
            {
                var highestPair = cardValues.OrderByDescending(x => x.Value).FirstOrDefault();

                result = new Tuple<string, string>(highestPair.Key, highestPair.Key);
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

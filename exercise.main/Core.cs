using System.Runtime.InteropServices;

namespace exercise.main
{
    public class Core
    {
        Dictionary<string, int> cardValues;

        public Core() {
            cardValues = new Dictionary<string, int>()
            {
                {"A", 14}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10}, {"J", 11}, {"Q", 12}, {"K", 13}
            };
        }

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);

            List<Tuple<string, string>> hands = hand.ToList();
            foreach (var x in hands)
            {
                if (x.Item1 == x.Item2 && GetValueOfCard(result.Item1) < GetValueOfCard(x.Item1)) result = x; 
            }
            
            return result.Item1 != string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            return cardValues.GetValueOrDefault(card.ToUpper());           
        }
    }
}

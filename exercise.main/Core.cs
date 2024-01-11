namespace exercise.main
{
    public class Core
    {
        private readonly Dictionary<string , int> cardValues = new Dictionary<string , int>
        {
            {"1", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5},
            {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
            {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
        };

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string , string>> hand , out Tuple<string , string> result)
        {
            result = new Tuple<string , string>(string.Empty , string.Empty);
            int maxScore = 0;

            foreach(var pair in hand)
            {
                if(pair.Item1 == pair.Item2)
                {
                    int score = GetValueOfCard(pair.Item1);
                    if(score > maxScore)
                    {
                        maxScore = score;
                        result = pair;
                    }
                }
            }

            return result.Item1 != string.Empty;
        }
        public int GetValueOfCard(string card)
        {
            if(cardValues.ContainsKey(card))
            {
                return cardValues[card];
            }
            else
            {
                throw new ArgumentException("Invalid card value: " + card);
            }
        }
    }
}

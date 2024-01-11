namespace exercise.main
{
    public class Extension
    {
        private readonly Dictionary<string , int> cardValues = new Dictionary<string , int>
        {
            {"1", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5},
            {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
            {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
        };

        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string , string , string>> hand , out Tuple<string , string , string> result)
        {
            result = new Tuple<string , string , string>(string.Empty , string.Empty , string.Empty);
            int maxScore = 0;

            foreach(var triplet in hand)
            {
                if(triplet.Item1 == triplet.Item2 && triplet.Item2 == triplet.Item3)
                {
                    int score = GetValueOfCard(triplet.Item1);
                    if(score > maxScore)
                    {
                        maxScore = score;
                        result = triplet;
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


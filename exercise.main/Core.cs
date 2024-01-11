namespace exercise.main
{
    public class Core
    {
        private readonly Dictionary<string, int> _uniqueValues = new()
       {
           {"J", 11 },
           {"Q", 12 },
           {"K", 13},
           {"A", 14 }
       };

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty);
            foreach (var h in hand)
            {
                if (h.Item1 == h.Item2 && GetValueOfCard(h.Item1) > GetValueOfCard(result.Item1))
                {
                    result = h;
                }
            }
            return result.Item1 != string.Empty;
        }
        public int GetValueOfCard(string card)
        {
            if (_uniqueValues.ContainsKey(card))
            {
                return _uniqueValues[card];
            }
            else
            {
                try
                {
                    return Int32.Parse(card);
                }
                catch { return 0; }
            }
        }
    }
}

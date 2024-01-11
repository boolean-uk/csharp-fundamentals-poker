﻿namespace exercise.main
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
            Dictionary<Tuple<string, string>, int> matches = new();
            foreach (var h in hand)
            {
                if (h.Item1 == h.Item2)
                {
                    matches.Add(h, GetValueOfCard(h.Item1) + GetValueOfCard(h.Item2));
                }
            }
            if (matches.Count == 0)
            {
                result = new Tuple<string, string>(string.Empty, string.Empty);
            }
            else if (matches.Count == 1)
            {
                result = matches.First().Key;
            }
            else
            {
                result = matches.MaxBy(h => h.Value).Key;
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
                return Int32.Parse(card);
            }
        }
    }
}

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
            
            Core core = new Core();

            List<Tuple<string, string, string>> hands = hand.ToList();
            foreach (var x in hands)
            {
                if (x.Item1 == x.Item2 && x.Item1 == x.Item3 && core.GetValueOfCard(result.Item1) < core.GetValueOfCard(x.Item1)) result = x;
            }

            return result.Item1 != string.Empty ? true : false;
        }

    }
}

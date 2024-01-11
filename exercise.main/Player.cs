namespace exercise.main
{
    public class Player
    {
        private readonly string _name;
        private List<Card> hand;
        public Player(string name)
        {
            _name = name;
            hand = new();
        }

        public void GiveCard(Card card)
        {
            hand.Add(card);
        }

        public void ClearHand()
        {
            hand.Clear();
        }

        public List<Card> GetCards()
        {
            return hand;
        }
    }
}

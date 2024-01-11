namespace exercise.main
{
    public class Player
    {
        public readonly string name;
        private List<Card> hand;
        public Player(string name)
        {
            this.name = name;
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

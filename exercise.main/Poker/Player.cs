namespace exercise.main.Poker
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public void ClearHand()
        {
            Hand.Clear();
        }

        public string ShowHand()
        {
            string hand = "";
            foreach(var card in Hand)
            {
                hand += $"{card.Value} of {card.Suit}, ";
            }
            return hand.TrimEnd(',' , ' ');
        }
    }
}
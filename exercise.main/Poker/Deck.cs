namespace exercise.main.Poker
{
    public class Deck
    {
        public readonly List<Card> cards;
        public readonly Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = { "Spades" , "Hearts" , "Diamonds" , "Clubs" };
            string[] values = { "1" , "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" , "10" , "J" , "Q" , "K" , "A" };

            foreach(var suit in suits)
            {
                foreach(var value in values)
                {
                    cards.Add(new Card { Suit = suit , Value = value });
                }
            }
        }

        public void Shuffle()
        {
            for(int i = 0;i < cards.Count;i++)
            {
                var temp = cards[i];
                int randomIndex = random.Next(cards.Count);
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }

        public Card Deal()
        {
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
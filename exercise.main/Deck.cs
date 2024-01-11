namespace exercise.main
{
    public class Deck
    {
        private readonly List<Card> _initialCards;
        private Queue<Card> _cards;
        private static Random random = new Random();

        public Deck(List<Card> cards)
        {
            _initialCards = cards;
            Shuffle();
        }

        public void Shuffle()
        {
            _cards = new Queue<Card>(_initialCards.OrderBy(c => random.Next()).ToList()); //Shuffle and regenerate deck
        }

        public Card Deal()
        {
            return _cards.Dequeue();
        }

        public List<Card> GetCards()
        {
            return [.. _cards];
        }
    }
}

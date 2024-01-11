using exercise.main.Poker;

namespace PokerGame.Tests
{
    public class PokerGameTests
    {
        [Test]
        public void TestCardCreation()
        {
            Card card = new Card { Value = "A" , Suit = "Spades" };
            Assert.AreEqual("A" , card.Value);
            Assert.AreEqual("Spades" , card.Suit);
        }

        [Test]
        public void TestShuffleDeck()
        {
            Deck deck = new Deck();
            Card firstCardBeforeShuffle = deck.cards.First();
            deck.Shuffle();
            Card firstCardAfterShuffle = deck.cards.First();
            Assert.AreNotEqual(firstCardBeforeShuffle , firstCardAfterShuffle);
        }

        [Test]
        public void TestDealCard()
        {
            Deck deck = new Deck();
            int initialDeckSize = deck.cards.Count;
            Card card = deck.Deal();
            Assert.AreEqual(initialDeckSize - 1 , deck.cards.Count);
            Assert.IsFalse(deck.cards.Contains(card));
        }

        [Test]
        public void TestPlayerHand()
        {
            Player player = new Player("Player 1");
            Assert.AreEqual("Player 1" , player.Name);
            Assert.IsEmpty(player.Hand);

            Card card = new Card { Value = "A" , Suit = "Spades" };
            player.AddCardToHand(card);
            Assert.AreEqual(1 , player.Hand.Count);
            Assert.AreEqual(card , player.Hand.First());

            player.ClearHand();
            Assert.IsEmpty(player.Hand);
        }
    }
}

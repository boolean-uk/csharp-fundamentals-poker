using exercise.main;

namespace exercise.tests
{
    public class ExtensionTests
    {
        [Test]
        public void TestThreeCards()
        {
            Extension extension = new Extension();
            Tuple<string, string, string> hand1 = new Tuple<string, string, string>("4", "4", "2");
            Tuple<string, string, string> hand2 = new Tuple<string, string, string>("1", "A", "4");
            Tuple<string, string, string> hand3 = new Tuple<string, string, string>("K", "K", "K");
            List<Tuple<string, string, string>> hands = [hand1, hand2];

            Tuple<string, string, string> winner;
            bool result = extension.winningThree(hands, out winner);
            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));

            hands = [hand1, hand3];
            result = extension.winningThree(hands, out winner);

            Assert.That(result, Is.True);
            Assert.IsTrue(winner.Item1 == "K" && winner.Item2 == "K" && winner.Item3 == "K");
        }


        [Test]
        public void CardTest()
        {
            Card card = new("A", "Hearts");
            Assert.Multiple(() =>
            {
                Assert.That(card, Is.Not.Null);
                Assert.That(card.value, Is.EqualTo("A"));
                Assert.That(card.suit, Is.EqualTo("Hearts"));
            });
        }

        [Test]
        public void DeckTest()
        {
            Card card1 = new("A", "Hearts");
            Card card2 = new("4", "Spades");
            Card card3 = new("10", "Clubs");
            Card card4 = new("Q", "Diamonds");
            List<Card> cards = [card1, card2, card3, card4];
            Deck deck = new(cards);
            Assert.That(deck, Is.Not.Null);

            Assert.That(cards, Does.Contain(deck.Deal()));
            Assert.That(cards.Count - 1, Is.EqualTo(deck.GetCards().Count)); //Dealing card should remove a card from the deck
            deck.Deal();
            Assert.That(cards.Count - 2, Is.EqualTo(deck.GetCards().Count)); //Dealing card should remove another card from the deck

            deck.Shuffle(); //Should regen deck
            Assert.That(deck.GetCards().Count, Is.EqualTo(cards.Count)); //Should now be equal again
        }

        [Test]
        public void PlayerTest()
        {
            Player player = new("Skjalg");
            Assert.That(player.GetCards().Count, Is.EqualTo(0));
            Card card = new Card("A", "Hearts");
            player.GiveCard(card);
            Assert.That(player.GetCards().Count, Is.EqualTo(1));
            Assert.That(player.GetCards()[0], Is.EqualTo(card));
            Card card2 = new Card("10", "Clubs");
            player.GiveCard(card2);
            Assert.That(player.GetCards().Count, Is.EqualTo(2));
            player.ClearHand();
            Assert.That(player.GetCards().Count, Is.EqualTo(0)); //Hand should now be empty again
        }
    }
}

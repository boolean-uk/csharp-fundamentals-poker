using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class UngradedExtensionTests
    {
        [Test]
        public void DeckHas52Cards()
        {
            UngradedExtension extension = new UngradedExtension();

            UngradedExtension.Deck deck = new UngradedExtension.Deck();

            Assert.That(deck.Cards.Count, Is.EqualTo(52));
        }
        [Test]
        public void Shuffle()
        {
            UngradedExtension extension = new UngradedExtension();

            UngradedExtension.Deck deck = new UngradedExtension.Deck();
            UngradedExtension.Deck deckShuffled = new UngradedExtension.Deck();

            bool OrdersEqual = deck.Cards.SequenceEqual(deckShuffled.Cards);
            Assert.IsTrue(OrdersEqual, "Both decks should have the same order before shuffling.");

            deckShuffled.Shuffle();

            OrdersEqual = deck.Cards.SequenceEqual(deckShuffled.Cards);
            Assert.IsTrue(!OrdersEqual, "Shuffle should change the order of cards in the deck.");
        }
        //[Test]
        //public void Deal()
        //{
        //    UngradedExtension extension = new UngradedExtension();
        //    UngradedExtension.Deck deck = new UngradedExtension.Deck();
        //    int originalCount = deck.Cards.Count;
        //    UngradedExtension.Card card = deck.Deal();
        //    Assert.That(deck.Cards.Count, !Is.EqualTo(originalCount));
        //    Assert.That(card, !Is.SubsetOf(deck.Cards));
        //}
    }
}

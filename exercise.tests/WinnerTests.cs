using System;
using exercise.main;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class WinnerTests
    {
        Winner winner = new Winner();

        [Test]
        public void StraightTest()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("3", Suit.Hearts),
                new Card("4", Suit.Diamonds),
                new Card("5", Suit.Hearts),
                new Card("6", Suit.Spades),
                new Card("7", Suit.Hearts),
            };
            int result = winner.Straight(hand);
            Assert.That(result, Is.EqualTo(407));
        }
        [Test]
        public void Straight1Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("J", Suit.Hearts),
                new Card("4", Suit.Diamonds),
                new Card("10", Suit.Hearts),
                new Card("6", Suit.Spades),
                new Card("7", Suit.Hearts),
            };
            int result = winner.Straight(hand);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Straight2Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("Q", Suit.Hearts),
                new Card("J", Suit.Diamonds),
                new Card("A", Suit.Hearts),
                new Card("K", Suit.Spades),
                new Card("10", Suit.Hearts),
            };
            int result = winner.Straight(hand);
            Assert.That(result, Is.EqualTo(414));
        }
    }
}

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

        [Test]
        public void FlushTest()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("Q", Suit.Hearts),
                new Card("J", Suit.Diamonds),
                new Card("A", Suit.Hearts),
                new Card("K", Suit.Spades),
                new Card("10", Suit.Hearts),
            };
            int result = winner.Flush(hand);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Flush2Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("2", Suit.Hearts),
                new Card("4", Suit.Hearts),
                new Card("6", Suit.Hearts),
                new Card("8", Suit.Hearts),
                new Card("Q", Suit.Hearts),
            };
            int result = winner.Flush(hand);
            Assert.That(result, Is.EqualTo(532));
        }

        [Test]
        public void FourOfAKindTest()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Hearts),
                new Card("4", Suit.Spades),
                new Card("4", Suit.Diamonds),
                new Card("4", Suit.Clubs),
                new Card("Q", Suit.Hearts),
            };
            int result = winner.FourOfAKind(hand);
            Assert.That(result, Is.EqualTo(704));
        }
        [Test]
        public void FourOfAKind2Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Hearts),
                new Card("4", Suit.Spades),
                new Card("6", Suit.Diamonds),
                new Card("4", Suit.Clubs),
                new Card("Q", Suit.Hearts),
            };
            int result = winner.FourOfAKind(hand);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void FourOfAKind3Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Hearts),
                new Card("4", Suit.Spades),
                new Card("6", Suit.Diamonds),
                new Card("4", Suit.Clubs),
                new Card("6", Suit.Hearts),
            };
            int result = winner.FourOfAKind(hand);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void StraightFlushTest()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Hearts),
                new Card("5", Suit.Spades),
                new Card("6", Suit.Diamonds),
                new Card("7", Suit.Clubs),
                new Card("8", Suit.Hearts),
            };
            int result = winner.StraightFlush(hand);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void StraightFlush2Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Hearts),
                new Card("5", Suit.Spades),
                new Card("Q", Suit.Diamonds),
                new Card("Q", Suit.Clubs),
                new Card("8", Suit.Hearts),
            };
            int result = winner.StraightFlush(hand);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void StraightFlush3Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("6", Suit.Spades),
                new Card("8", Suit.Spades),
                new Card("7", Suit.Spades),
            };
            int result = winner.StraightFlush(hand);
            Assert.That(result, Is.EqualTo(808));
        }
        [Test]
        public void StraightFlush4Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("Q", Suit.Spades),
                new Card("7", Suit.Spades),
                new Card("K", Suit.Spades),
            };
            int result = winner.StraightFlush(hand);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void FullHouseTest()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("4", Suit.Spades),
                new Card("4", Suit.Spades),
            };
            int result = winner.FullHouse(hand);
            Assert.That(result, Is.EqualTo(604));
        }
        [Test]
        public void FullHouse2Test()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("5", Suit.Spades),
            };
            int result = winner.FullHouse(hand);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void FulHouseTest()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("5", Suit.Spades),
                new Card("8", Suit.Spades),
                new Card("K", Suit.Spades),
            };
            int result = winner.FullHouse(hand);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Pair()
        {
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Spades),
                new Card("5", Suit.Diamonds),
                new Card("5", Suit.Spades),
                new Card("8", Suit.Clubs),
                new Card("K", Suit.Spades),
            };
            int result = winner.Pair(hand);
            Assert.That(result, Is.EqualTo(105));
        }


        [Test]
        public void ScoreTest()
        {
            List<Card> flop = new List<Card>()
            {
                new Card("3", Suit.Clubs),
                new Card("2", Suit.Clubs),
                new Card("4", Suit.Clubs),
                new Card("K", Suit.Diamonds),
                new Card("3", Suit.Diamonds),
            };
            List<Card> hand = new List<Card>()
            {
                new Card("4", Suit.Hearts),
                new Card("K", Suit.Hearts),
            };
            int result = winner.Score(hand, flop);
            Assert.That(result, Is.EqualTo(217));

        }
        [Test]
        public void Score1Test()
        {
            List<Card> flop = new List<Card>()
            {
                new Card("J", Suit.Diamonds),
                new Card("10", Suit.Diamonds),
                new Card("5", Suit.Clubs),
                new Card("6", Suit.Clubs),
                new Card("K", Suit.Diamonds),
            };
            List<Card> hand = new List<Card>()
            {
                new Card("Q", Suit.Diamonds),
                new Card("J", Suit.Clubs),
            };
            int result = winner.Score(hand, flop);
            Assert.That(result, Is.EqualTo(111));
        }

        [Test]
        public void Score2Test()
        {
            List<Card> flop = new List<Card>()
            {
                new Card("J", Suit.Diamonds),
                new Card("10", Suit.Diamonds),
                new Card("A", Suit.Clubs),
                new Card("6", Suit.Clubs),
                new Card("K", Suit.Diamonds),
            };
            List<Card> hand = new List<Card>()
            {
                new Card("Q", Suit.Diamonds),
                new Card("J", Suit.Clubs),
            };
            int result = winner.Score(hand, flop);
            Assert.That(result, Is.EqualTo(414));
        }
    }
}

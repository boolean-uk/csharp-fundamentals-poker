using exercise.main.Poker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class WinningHandsTests
    {
        [Test]
        public void ThreeOfAKindTest()
        {
            WinningHands winningHands = new();
            List<Card> cards = new()
            {
                new Card("K", "Spades"),
                new Card("K", "Hearts"),
                new Card("K", "Spades"),
                new Card("5", "Hearts"),
                new Card("2", "Diamonds"),
                new Card("4", "Spades")
            };
            winningHands.IterateWinConditions(cards);

            Assert.That(winningHands.Score, Is.EqualTo(4));
        }
    }
}

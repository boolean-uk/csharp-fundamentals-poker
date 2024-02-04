using exercise.main;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace exercise.tests
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void WinningThree_Scenario1()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("K", "5", "3"),
                new Tuple<string, string, string>("3", "7", "A")
            };

            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));
            Assert.That(winner.Item3, Is.EqualTo(String.Empty));
        }

        [Test]
        public void WinningThree_Scenario2()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("K", "5", "2"),
                new Tuple<string, string, string>("2", "2", "7")
            };

            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));
            Assert.That(winner.Item3, Is.EqualTo(String.Empty));
        }

        [Test]
        public void WinningThree_Scenario3()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("4", "3", "A"),
                new Tuple<string, string, string>("6", "6", "6"),
                new Tuple<string, string, string>("7", "7", "K"),
                new Tuple<string, string, string>("3", "3", "3")
            };

            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("6"));
            Assert.That(winner.Item2, Is.EqualTo("6"));
            Assert.That(winner.Item3, Is.EqualTo("6"));
        }
    }
}

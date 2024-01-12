using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class ExtensionTests
    {
        [Test]
        public void scenario1()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new()
            {
                new Tuple<string, string, string>("K", "K", "K"),
                new Tuple<string, string, string>("Q", "Q", "Q"),
                new Tuple<string, string, string>("2", "3", "4"),
            };

            Tuple<string, string, string> winner;
            var result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("K"));
            Assert.That(winner.Item2, Is.EqualTo("K"));
            Assert.That(winner.Item3, Is.EqualTo("K"));
        }

        [Test]
        public void scenario2()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new()
            {
                new Tuple<string, string, string>("K", "Q", "K"),
                new Tuple<string, string, string>("Q", "Q", "Q"),
                new Tuple<string, string, string>("2", "3", "4"),
            };

            Tuple<string, string, string> winner;
            var result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("Q"));
            Assert.That(winner.Item2, Is.EqualTo("Q"));
            Assert.That(winner.Item3, Is.EqualTo("Q"));
        }

        [Test]
        public void scenario3()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new()
            {
                new Tuple<string, string, string>("K", "Q", "K"),
                new Tuple<string, string, string>("Q", "2", "Q"),
                new Tuple<string, string, string>("2", "3", "4"),
            };

            Tuple<string, string, string> winner;
            var result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(string.Empty));
            Assert.That(winner.Item2, Is.EqualTo(string.Empty));
            Assert.That(winner.Item3, Is.EqualTo(string.Empty));
        }
    }
}

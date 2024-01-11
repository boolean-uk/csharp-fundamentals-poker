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
        public void Scenario1()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>()
            {
                new Tuple<string, string, string>("2", "3", "2"),
                new Tuple<string, string, string>("7", "A", "Q")
            };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(string.Empty));
            Assert.That(winner.Item2, Is.EqualTo(string.Empty));
            Assert.That(winner.Item3, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Scenario2()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>()
            {
                new Tuple<string, string, string>("7", "7", "7"),
                new Tuple<string, string, string>("7", "A", "Q")
            };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("7"));
            Assert.That(winner.Item2, Is.EqualTo("7"));
            Assert.That(winner.Item3, Is.EqualTo("7"));
        }

        [Test]
        public void Scenario3()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>()
            {
                new Tuple<string, string, string>("7", "7", "7"),
                new Tuple<string, string, string>("9", "9", "9")
            };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("9"));
            Assert.That(winner.Item2, Is.EqualTo("9"));
            Assert.That(winner.Item3, Is.EqualTo("9"));
        }

        public void Scenario4()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>()
            {
                new Tuple<string, string, string>("7", "7", "7"),
                new Tuple<string, string, string>("9", "9", "9"),
                new Tuple<string, string, string>("3", "3", "3"),
                new Tuple<string, string, string>("1", "1", "1")
            };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("9"));
            Assert.That(winner.Item2, Is.EqualTo("9"));
            Assert.That(winner.Item3, Is.EqualTo("9"));
        }
    }
}

using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void Scenario1()
        {
            Extension ext = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "K"),
            new Tuple<string, string, string>("3","7", "3")
        };
            Tuple<string, string, string> winner;

            bool result = ext.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));
        }

        [Test]
        public void Scenario2()
        {
            Extension ext = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("5", "5", "K"),
            new Tuple<string, string, string>("J","J", "J")
        };
            Tuple<string, string, string> winner;

            bool result = ext.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("J"));
            Assert.That(winner.Item1, Is.EqualTo("J"));
            Assert.That(winner.Item1, Is.EqualTo("J"));

        }

        [Test]
        public void Scenario3()
        {
            Extension ext = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("7", "7", "7"),
            new Tuple<string, string, string>("A","A", "A")
        };
            Tuple<string, string, string> winner;

            bool result = ext.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("A"));
            Assert.That(winner.Item1, Is.EqualTo("A"));
            Assert.That(winner.Item1, Is.EqualTo("A"));

        }
    }
}

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

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string,string>>
        {
            new Tuple<string, string, string>("K", "5", "5"),
            new Tuple<string, string, string>("3","7", "J")
        };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));
            Assert.That(winner.Item3, Is.EqualTo(String.Empty));

        }

        [Test]
        public void Scenario2()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("5", "5", "5"),
            new Tuple<string, string, string>("A","A", "2")
        };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("5"));
            Assert.That(winner.Item2, Is.EqualTo("5"));
            Assert.That(winner.Item2, Is.EqualTo("5"));

        }

        [Test]
        public void Scenario3()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("2", "2", "2"),
            new Tuple<string, string, string>("3","6", "7"),
            new Tuple<string, string, string>("5", "5", "5"),
            new Tuple<string, string, string>("J","J", "J"),
            new Tuple<string, string, string>("3", "3", "3"),
            new Tuple<string, string, string>("A","6", "5")
        };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("J"));
            Assert.That(winner.Item2, Is.EqualTo("J"));
            Assert.That(winner.Item2, Is.EqualTo("J"));

        }


    }
}

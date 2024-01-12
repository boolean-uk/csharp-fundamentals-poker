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
        public void Scenario4()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("K", "K", "K"),
                new Tuple<string, string, string>("2", "2", "2"),
                new Tuple<string, string, string>("Q", "Q", "Q")
            };

            Tuple<string, string, string> result;

            bool success = extension.winningThree(hand, out result);
            
            Assert.That(success, Is.True);
            Assert.That(result.Item1, Is.EqualTo("K"));
            Assert.That(result.Item2, Is.EqualTo("K"));
            Assert.That(result.Item3, Is.EqualTo("K"));


        }
        [Test]
        public void Scenario5()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("7", "8", "9"),
            new Tuple<string, string, string>("2", "3", "4"),
            new Tuple<string, string, string>("K", "Q", "J")
        };
            Tuple<string, string, string> result;

            bool success = extension.winningThree(hand, out result);

            Assert.That(success, Is.False);
            Assert.That(result.Item1, Is.EqualTo(string.Empty));
            Assert.That(result.Item2, Is.EqualTo(string.Empty));
            Assert.That(result.Item3, Is.EqualTo(string.Empty));
        }

    }
}

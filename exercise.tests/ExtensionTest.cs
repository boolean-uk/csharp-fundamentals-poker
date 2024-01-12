using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class ExtensionTest
    {
        [Test]
        public void Scenario4()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("4", "3", "8"),
                new Tuple<string, string, string>("6", "6", "6"),
                new Tuple<string, string, string>("7", "7", "7"),
                new Tuple<string, string, string>("3","3", "3")
            };
            Tuple<string, string, string> winner;
            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);

            Assert.IsTrue(winner.Item1 == "7" && winner.Item2 == "7" && winner.Item3 == "7");

        }
    }
}

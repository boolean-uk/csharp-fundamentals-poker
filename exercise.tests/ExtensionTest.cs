using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests
{
    public class ExtensionTest {

    [Test]
        public void Scenario1() {
       

            Extension core = new Extension();
       
            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>> { 
                new Tuple<string, string, string>("K", "5", "5"),
                new Tuple<string, string, string>("3","7", "5")
            };
            Tuple<string, string, string> winner;
        
            bool result = core.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));

        }
    }
}
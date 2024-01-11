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
        //{("K","5","5"),("3","7","7")} => false out ("","","")
        [Test]
        public void ScenarioE1()
        {

            // Access
            Extension extension = new Extension();

            //Model

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "5"),
            new Tuple< string, string, string >("3","7", "7")
        };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);


            // Assert
            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));
            Assert.That(winner.Item3, Is.EqualTo(String.Empty));

        }


        //{("5","5","5"),("7","7","7")} => true out ("7","7","7")
        [Test]
        public void ScenarioE2()
        {

            // Access
            Extension extension = new Extension();

            //Model

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("5", "5", "5"),
            new Tuple< string, string, string >("7","7", "7")
        };
            Tuple<string, string, string> winner;

            bool result = extension.winningThree(hand, out winner);


            // Assert
            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("7"));
            Assert.That(winner.Item2, Is.EqualTo("7"));
            Assert.That(winner.Item3, Is.EqualTo("7"));

        }

        //{("4", "3", "4"),("6","6", "6"),("7","7", "7"),("3","3", "3")}  => true ("7", "7", "7")
        [Test]
        public void ScenarioE3()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>> { 

            new Tuple<string, string, string>("4", "3", "4"),
            new Tuple< string, string, string >("6", "6", "6"),
            new Tuple < string, string, string > ("7",  "7", "7"),
            new Tuple < string, string, string > ("3", "3", "3")
        };
            Tuple<string, string, string> winner;
            bool result = extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);

            Assert.IsTrue(winner.Item1 == "7" && winner.Item2 == "7" && winner.Item3 == "7");

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;


namespace exercise.tests
{
    public class ExtentionTests
    {
        [SetUp]
        public void Setup()
        {

        }


        //{("K","5","K"),("3","7","3")} => false out ("","","")
        [Test]
        public void Scenario1()
        {


            Extension extention = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5","K"),
            new Tuple < string, string, string > ("3", "7", "3")
        };
            Tuple<string, string, string> winner;

            bool result = extention.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(string.Empty));
            Assert.That(winner.Item2, Is.EqualTo(string.Empty));

        }

        //{("K","5","K"),("A","A","A")} => true out ("A","A","A")
        [Test]
        public void Scenario2()
        {


            Extension extention = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5","K"),
            new Tuple < string, string, string > ("A", "A", "A")
        };
            Tuple<string, string, string> winner;

            bool result = extention.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.IsTrue(winner.Item1 == "A" && winner.Item2 == "A" && winner.Item3 == "A");

        }

        //{("K","5","K"),("A","A","A"),("Q","Q","Q")} => true out ("A","A","A")
        [Test]
        public void Scenario3()
        {


            Extension extention = new Extension();

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5","K"),
            new Tuple < string, string, string > ("A", "A", "A"),
            new Tuple < string, string, string > ("Q", "Q", "Q")
        };
            Tuple<string, string, string> winner;

            bool result = extention.winningThree(hand, out winner);

            Assert.That(result, Is.True);
            Assert.IsTrue(winner.Item1 == "A" && winner.Item2 == "A" && winner.Item3 == "A");

        }

    }
    
}

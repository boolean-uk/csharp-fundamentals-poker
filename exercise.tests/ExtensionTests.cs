using exercise.main;

namespace exercise.tests
{
    public class ExtensionTests
    {
        internal Extension extension; 

        [SetUp]
        public void Setup() 
        {
            this.extension = new Extension();
        }


        //{("K","5", "J"),("3","7", "9")} => false out ("","")
        [Test]
        public void Scenario1()
        {

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "J"),
            new Tuple<string, string, string>("3","7", "9")
        };
            Tuple<string, string, string> winner;

            bool result = this.extension.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));
            Assert.That(winner.Item3, Is.EqualTo(String.Empty));

        }

        //{("K","5", "J"),("2","2", "2")} => true out ("2","2")
        public void Scenario1b()
        {
            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "J"),
            new Tuple<string, string, string>("2","2", "2")
        };
            Tuple<string, string, string> winner;

            bool result = this.extension.winningThree(hand, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo("2"));
            Assert.That(winner.Item2, Is.EqualTo("2"));
            Assert.That(winner.Item3, Is.EqualTo("2"));

        }

        //("K","K", "K"), ("A","A", "A")} => true out ("A","A", "A")
        [Test]
        public void Scenario2()
        {

            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "K", "K"),
            new Tuple<string, string, string>("A","A", "A")
        };
            Tuple<string, string, string> winner;
            bool result = this.extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);

            Assert.IsTrue(winner.Item1 == "A" && winner.Item2 == "A" && winner.Item3 == "A");

        }

        //{("9", "6", "3"),("4", "3", "2"),("6","6", "6"),("7","7", "7"),("3","3", "3")}  => true ("7", "7", "7")
        [Test]
        public void Scenario3()
        {
            List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("9", "6", "3"),
            new Tuple<string, string, string>("4", "3", "2"),
            new Tuple<string, string, string>("6", "6", "6"),
            new Tuple<string, string, string>("7", "7", "7"),
            new Tuple<string, string, string>("3","3", "3")
        };
            Tuple<string, string, string> winner;
            bool result = this.extension.winningThree(hand, out winner);

            Assert.That(result, Is.True);

            Assert.IsTrue(winner.Item1 == "7" && winner.Item2 == "7" && winner.Item3 == "7");

        }
    }
}

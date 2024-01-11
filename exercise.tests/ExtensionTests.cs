using exercise.main;

namespace exercise.tests
{
    public class ExtensionTests
    {
        //{("K","5","1"),("3","7","3")} => false out ("","","")
        [Test]
        public void Scenario1()
        {
            Extension extension = new Extension();

            List<Tuple<string , string , string>> hand = new List<Tuple<string , string , string>>
            {
                new Tuple<string, string, string>("K", "5", "1"),
                new Tuple<string, string, string>("3", "7", "3")
            };
            Tuple<string , string , string> winner;

            bool result = extension.winningThree(hand , out winner);

            Assert.That(result , Is.False);
            Assert.That(winner.Item1 , Is.EqualTo(String.Empty));
            Assert.That(winner.Item2 , Is.EqualTo(String.Empty));
            Assert.That(winner.Item3 , Is.EqualTo(String.Empty));
        }

        //{("K","K","K"),("2","2","2")} => true out ("K","K","K")
        [Test]
        public void Scenario2()
        {
            Extension extension = new Extension();

            List<Tuple<string , string , string>> hand = new List<Tuple<string , string , string>>
            {
                new Tuple<string, string, string>("K", "K", "K"),
                new Tuple<string, string, string>("2", "2", "2")
            };
            Tuple<string , string , string> winner;

            bool result = extension.winningThree(hand , out winner);

            Assert.That(result , Is.True);
            Assert.IsTrue(winner.Item1 == "K" && winner.Item2 == "K" && winner.Item3 == "K");
        }

        //{("4", "4", "4"),("6","6","6"),("7","7","7"),("3","3","3")}  => true ("7", "7", "7")
        [Test]
        public void Scenario3()
        {
            Extension extension = new Extension();

            List<Tuple<string , string , string>> hand = new List<Tuple<string , string , string>>
            {
                new Tuple<string, string, string>("4", "4", "4"),
                new Tuple<string, string, string>("6", "6", "6"),
                new Tuple<string, string, string>("7", "7", "7"),
                new Tuple<string, string, string>("3", "3", "3")
            };
            Tuple<string , string , string> winner;

            bool result = extension.winningThree(hand , out winner);

            Assert.That(result , Is.True);
            Assert.IsTrue(winner.Item1 == "7" && winner.Item2 == "7" && winner.Item3 == "7");
        }

        [TestCase("2" , 2)]
        [TestCase("3" , 3)]
        [TestCase("4" , 4)]
        [TestCase("5" , 5)]
        [TestCase("6" , 6)]
        [TestCase("7" , 7)]
        [TestCase("8" , 8)]
        [TestCase("9" , 9)]
        [TestCase("10" , 10)]
        [TestCase("J" , 11)]
        [TestCase("Q" , 12)]
        [TestCase("K" , 13)]
        [TestCase("A" , 14)]

        public void TestCardsExtension(string card , int value)
        {
            Extension extension = new Extension();
            int result = extension.GetValueOfCard(card);
            Assert.That(result , Is.EqualTo(value));
        }
    }
}

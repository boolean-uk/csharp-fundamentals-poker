using exercise.main;

namespace exercise.tests
{
    public class ExtensionTests
    {
        [Test]
        public void Scenario1()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hands = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("K", "K", "1"),
                new Tuple<string, string, string>("1", "3", "1"),
                new Tuple<string, string, string>("9", "Q", "Q"),
                new Tuple<string, string, string>("3", "2", "1"),
                new Tuple<string, string, string>("1", "1", "10")
            };
            Tuple<string, string, string> winner;
            bool result = extension.winningThree(hands, out winner);

            Assert.That(result, Is.False);
            Assert.That(winner.Item1, Is.EqualTo(String.Empty));
            Assert.That(winner.Item2, Is.EqualTo(String.Empty));
            Assert.That(winner.Item3, Is.EqualTo(String.Empty));
        }

        [Test]
        public void Scenario2()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hands = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("Q", "K", "6"),
                new Tuple<string, string, string>("1", "3", "1"),
                new Tuple<string, string, string>("9", "9", "9"),
                new Tuple<string, string, string>("3", "2", "1"),
                new Tuple<string, string, string>("1", "1", "10")
            };
            Tuple<string, string, string> winner;
            bool result = extension.winningThree(hands, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("9"));
            Assert.That(winner.Item2, Is.EqualTo("9"));
            Assert.That(winner.Item3, Is.EqualTo("9"));
        }

        [Test]
        public void Scenario3()
        {
            Extension extension = new Extension();

            List<Tuple<string, string, string>> hands = new List<Tuple<string, string, string>>
            {
                new Tuple<string, string, string>("Q", "Q", "Q"),
                new Tuple<string, string, string>("1", "3", "1"),
                new Tuple<string, string, string>("9", "6", "9"),
                new Tuple<string, string, string>("J", "J", "J"),
                new Tuple<string, string, string>("1", "1", "10")
            };
            Tuple<string, string, string> winner;
            bool result = extension.winningThree(hands, out winner);

            Assert.That(result, Is.True);
            Assert.That(winner.Item1, Is.EqualTo("Q"));
            Assert.That(winner.Item2, Is.EqualTo("Q"));
            Assert.That(winner.Item3, Is.EqualTo("Q"));
        }

    }
}

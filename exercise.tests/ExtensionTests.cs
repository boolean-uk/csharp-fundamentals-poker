using exercise.main;

namespace exercise.tests;

public class ExtensionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Scenario1()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "1"),
            new Tuple<string, string, string>("3", "7", "1")
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
            new Tuple<string, string, string>("A", "A", "A"),
            new Tuple<string, string, string>("3", "7", "1")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("A"));
        Assert.That(winner.Item2, Is.EqualTo("A"));
        Assert.That(winner.Item3, Is.EqualTo("A"));
    }

    [Test]
    public void Scenario3()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "K", "K"),
            new Tuple<string, string, string>("Q", "Q", "Q")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("K"));
        Assert.That(winner.Item2, Is.EqualTo("K"));
        Assert.That(winner.Item3, Is.EqualTo("K"));
    }
}

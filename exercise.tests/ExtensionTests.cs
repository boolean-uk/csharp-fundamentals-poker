using exercise.main;

namespace exercise.tests;

public class ExtensionTests
{
    [Test]
    public void Scenario1()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "4"),
            new Tuple<string, string, string>("3", "7", "Q")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo(string.Empty));
        Assert.That(winner.Item2, Is.EqualTo(string.Empty));
        Assert.That(winner.Item3, Is.EqualTo(string.Empty));
    }
    [Test]
    public void Scenario2()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "K", "K"),
            new Tuple<string, string, string>("3", "3", "3")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("K"));
        Assert.That(winner.Item2, Is.EqualTo("K"));
        Assert.That(winner.Item3, Is.EqualTo("K"));
    }
    [Test]
    public void Scenario3()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "4"),
            new Tuple<string, string, string>("3", "3", "3"),
            new Tuple<string, string, string>("Q", "Q", "4"),
            new Tuple<string, string, string>("6", "6", "6")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("6"));
        Assert.That(winner.Item2, Is.EqualTo("6"));
        Assert.That(winner.Item3, Is.EqualTo("6"));
    }
}

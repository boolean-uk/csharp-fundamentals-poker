using exercise.main;
using Newtonsoft.Json.Serialization;

namespace exercise.tests;

public class ExtensionTests
{

    //{("K","5"),("3","7")} => false out ("","")
    [Test]
    public void Scenario1()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "K"),
            new Tuple<string, string, string>("3","7", "5")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo(String.Empty));
        Assert.That(winner.Item2, Is.EqualTo(String.Empty));
        Assert.That(winner.Item3, Is.EqualTo(String.Empty));
    }

    //{("K","5"),("2","2")} => true out ("2","2")
    public void Scenario1b()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "K"),
            new Tuple<string, string, string>("3","3", "3")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("3"));
        Assert.That(winner.Item2, Is.EqualTo("3"));
        Assert.That(winner.Item2, Is.EqualTo("3"));
    }

    //("K","K"), ("A","A")} => true out ("A","A")
    [Test]
    public void Scenario2()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("A", "A", "A"),
            new Tuple<string, string, string>("7","7", "7")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("A"));
        Assert.That(winner.Item2, Is.EqualTo("A"));
        Assert.That(winner.Item2, Is.EqualTo("A"));
    }
    //{("4", "3"),("6","6"),("7","7"),("3","3")}  => true ("7", "7")
    [Test]
    public void Scenario3()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "J"),
            new Tuple<string, string, string>("3","7", "5"),
            new Tuple<string, string, string>("3","3", "3"),
            new Tuple<string, string, string>("Q","Q", "Q"),
            new Tuple<string, string, string>("J","J", "J")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("Q"));
        Assert.That(winner.Item2, Is.EqualTo("Q"));
        Assert.That(winner.Item2, Is.EqualTo("Q"));
    }
}
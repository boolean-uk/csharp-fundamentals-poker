using exercise.main;
using Newtonsoft.Json.Serialization;

namespace exercise.tests;

public class TestsExtension
{
    
    [Test]
    public void Scenario1()
    {

        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>> 
        { 
            new Tuple<string, string, string>("K", "5", "3"),
            new Tuple<string, string, string>("3","7", "A")
        };
        Tuple<string, string, string> winner;
        
        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo(String.Empty));
        Assert.That(winner.Item2, Is.EqualTo(String.Empty));
        Assert.That(winner.Item3, Is.EqualTo(String.Empty));

    }

    public void Scenario1b()
    {

        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5","3"),
            new Tuple<string, string, string>("2","2", "2")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo("2"));
        Assert.That(winner.Item2, Is.EqualTo("2"));
        Assert.That(winner.Item3, Is.EqualTo("2"));

    }

    [Test]
    public void Scenario2()
    {

        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "K", "K"),
            new Tuple<string, string, string>("A","A", "A")
        };
        Tuple<string, string, string> winner;
        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        
        Assert.IsTrue(winner.Item1=="A" && winner.Item2=="A" && winner.Item2 == "A");

    }

    [Test]
    public void Scenario3()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("4", "3", "2"),
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
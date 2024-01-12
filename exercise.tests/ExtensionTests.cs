using System;
using System.Collections.Generic;
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
            new Tuple<string, string, string>("K", "5", "7"),
            new Tuple<string, string, string>("3","7", "7")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo(String.Empty));
        Assert.That(winner.Item2, Is.EqualTo(String.Empty));

    }
    [Test]
    public void Scenario2()
    {
        Extension ext = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "K", "K"),
            new Tuple<string, string, string>("A","A", "A")
        };
        Tuple<string, string, string> winner;
        bool result = ext.winningThree(hand, out winner);

        Assert.That(result, Is.True);

        Assert.IsTrue(winner.Item1 == "A" && winner.Item2 == "A" && winner.Item3 =="A");

    }
    [Test]
    public void Scenario3()
    {
        Extension ext = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("8", "8", "8"),
            new Tuple<string, string, string>("A","5", "A"),
            new Tuple<string, string, string>("A","A", "3"),
            new Tuple<string, string, string>("J","J", "J"),
        };
        Tuple<string, string, string> winner;
        bool result = ext.winningThree(hand, out winner);

        Assert.That(result, Is.True);

        Assert.IsTrue(winner.Item1 == "J" && winner.Item2 == "J" && winner.Item3 == "J");

    }
}



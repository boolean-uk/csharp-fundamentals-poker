using exercise.main;
using Newtonsoft.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace exercise.tests;

public class ExtensionTests
{

    //{("K","5"),("3","7")} => false out ("","")
    [Test]
    public void Scenario1Threes()
    {


        Extension ext = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "5", "7"),
            new Tuple<string, string, string>("3", "7", "J")
        };
        Tuple<string, string, string> winner;

        bool result = ext.winningThree(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo(string.Empty));
        Assert.That(winner.Item2, Is.EqualTo(string.Empty));
        Assert.That(winner.Item3, Is.EqualTo(string.Empty));

    }

    //("K","K"), ("A","A")} => true out ("A","A")
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

        Assert.IsTrue(winner.Item1 == "A" && winner.Item2 == "A");
        Assert.IsTrue(winner.Item1 == "A" && winner.Item3 == "A");

    }
    //{("4", "3"),("6","6"),("7","7"),("3","3")}  => true ("7", "7")
    [Test]
    public void Scenario3()
    {
        Extension ext = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string,string>("4", "3", "6"),
            new Tuple<string, string,string>("6", "6", "6"),
            new Tuple<string, string,string>("7", "7", "7"),
            new Tuple<string, string,string>("3","3", "3")
        };
        Tuple<string, string, string> winner;
        bool result = ext.winningThree(hand, out winner);

        Assert.That(result, Is.True);

        Assert.IsTrue(winner.Item1 == "7" && winner.Item2 == "7");
        Assert.IsTrue(winner.Item1 == "7" && winner.Item3 == "7");

    }
    [TestCase("1", 1)]
    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [TestCase("3", 3)]
    [TestCase("4", 4)]
    [TestCase("5", 5)]
    [TestCase("6", 6)]
    [TestCase("7", 7)]
    [TestCase("8", 8)]
    [TestCase("9", 9)]
    [TestCase("10", 10)]
    [TestCase("J", 11)]
    [TestCase("Q", 12)]
    [TestCase("K", 13)]
    [TestCase("A", 14)]
    public void TestCards(string card, int value)
    {
        Core core = new Core();
        int result = core.GetValueOfCard(card);
        Assert.That(result, Is.EqualTo(value));
    }

}
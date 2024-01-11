using exercise.main;
using Newtonsoft.Json.Serialization;

namespace exercise.tests;

public class Tests
{
    
    //{("K","5"),("3","7")} => false out ("","")
    [Test]
    public void Scenario1()
    {
       

        Core core = new Core();
       
        List<Tuple<string, string>> hand = new List<Tuple<string, string>> 
        { 
            new Tuple<string, string>("K", "5"),
            new Tuple<string, string>("3","7")
        };
        Tuple<string, string> winner;
        
        bool result = core.winningPair(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo(String.Empty));
        Assert.That(winner.Item2, Is.EqualTo(String.Empty));

    }

    //{("K","5"),("2","2")} => true out ("2","2")
    public void Scenario1b()
    {


        Core core = new Core();

        List<Tuple<string, string>> hand = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("K", "5"),
            new Tuple<string, string>("2","2")
        };
        Tuple<string, string> winner;

        bool result = core.winningPair(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo("2"));
        Assert.That(winner.Item2, Is.EqualTo("2"));

    }

    //("K","K"), ("A","A")} => true out ("A","A")
    [Test]
    public void Scenario2()
    {


        Core core = new Core();

        List<Tuple<string, string>> hand = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("K", "K"),
            new Tuple<string, string>("A","A")
        };
        Tuple<string, string> winner;
        bool result = core.winningPair(hand, out winner);

        Assert.That(result, Is.True);
        
        Assert.IsTrue(winner.Item1=="A" && winner.Item2=="A");

    }
    //{("4", "3"),("6","6"),("7","7"),("3","3")}  => true ("7", "7")
    [Test]
    public void Scenario3()
    {
        Core core = new Core();

        List<Tuple<string, string>> hand = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("4", "3"),
            new Tuple<string, string>("6", "6"),
            new Tuple<string, string>("7", "7"),
            new Tuple<string, string>("3","3")
        };
        Tuple<string, string> winner;
        bool result = core.winningPair(hand, out winner);

        Assert.That(result, Is.True);

        Assert.IsTrue(winner.Item1 == "7" && winner.Item2 == "7");

    }

    [TestCase("2",2)]
    [TestCase("3",3)]
    [TestCase("4",4)]
    [TestCase("5",5)]
    [TestCase("6",6)]
    [TestCase("7",7)]
    [TestCase("8",8)]
    [TestCase("9",9)]
    [TestCase("10",10)]
    [TestCase("J",11)]
    [TestCase("Q",12)]
    [TestCase("K",13)]
    [TestCase("A",14)]
    public void TestCards(string card, int value)
    {
        Core core = new Core();
        int result = core.GetValueOfCard(card);
        Assert.That(result, Is.EqualTo(value));
    }

}
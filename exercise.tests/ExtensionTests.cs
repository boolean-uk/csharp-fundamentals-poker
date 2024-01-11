using exercise.main;
using Newtonsoft.Json.Serialization;

namespace exercise.tests;

public class TestsExtention
{
    
    //{("K","5","3"),("3","7","3")} => false out ("","","")
    [Test]
    public void Scenario1()
    {
       

        Extension extension = new Extension();
       
        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>> 
        { 
            new Tuple< string, string, string >("K", "5", "3"),
            new Tuple < string, string, string > ("3", "7", "3")
        };
        Tuple<string, string, string> winner;
        
        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo(String.Empty));
        Assert.That(winner.Item2, Is.EqualTo(String.Empty));
        Assert.That(winner.Item3, Is.EqualTo(String.Empty));

    }

    //{("K","5","K"),("2","2","2")} => true out ("2","2","2")
    public void Scenario1b()
    {


        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple< string, string, string >("K", "5", "K"),
            new Tuple< string, string, string >("2","2", "2")
        };
        Tuple<string, string, string> winner;

        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("2"));
        Assert.That(winner.Item2, Is.EqualTo("2"));
        Assert.That(winner.Item3, Is.EqualTo("2"));

    }

    //("K","K"), ("A","A")} => true out ("A","A")
    [Test]
    public void Scenario2()
    {


        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple< string, string, string >("K", "K", "K"),
            new Tuple< string, string, string >("A","A", "A")
        };
        Tuple<string, string, string> winner;
        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        
        Assert.IsTrue(winner.Item1=="A" && winner.Item2=="A" && winner.Item3 =="A");

    }
    //{("4", "3"),("6","6"),("7","7"),("3","3")}  => true ("7", "7")
    [Test]
    public void Scenario3()
    {
        Extension extension = new Extension();

        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple< string, string, string >("4", "3", "2"),
            new Tuple< string, string, string >("6", "6", "6"),
            new Tuple < string, string, string > ("7", "7", "7"),
            new Tuple < string, string, string > ("3", "3", "2")
        };
        Tuple<string, string, string> winner;
        bool result = extension.winningThree(hand, out winner);

        Assert.That(result, Is.True);

        Assert.IsTrue(winner.Item1 == "7" && winner.Item2 == "7" && winner.Item3 == "7");

    }

}
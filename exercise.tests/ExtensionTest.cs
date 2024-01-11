using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests;

public class ExtensionTest 
{

    [Test]
    public void Scenario1() {
    

        Extension core = new Extension();
    
        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>> { 
            new Tuple<string, string, string>("K", "5", "5"),
            new Tuple<string, string, string>("3","7", "5")
        };
        Tuple<string, string, string> winner;
    
        bool result = core.winningThree(hand, out winner);

        Assert.That(result, Is.False);
        Assert.That(winner.Item1, Is.EqualTo(String.Empty));
        Assert.That(winner.Item2, Is.EqualTo(String.Empty));
        Assert.That(winner.Item3, Is.EqualTo(String.Empty));

    }

    [Test]
    public void Scenario1b() {
    

        Extension core = new Extension();
    
        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>> { 
            new Tuple<string, string, string>("A", "A", "5"),
            new Tuple<string, string, string>("5","6", "8")
        };
        Tuple<string, string, string> winner;
    
        bool result = core.winningThree(hand, out winner);

        Assert.That(result, Is.True);
        Assert.That(winner.Item1, Is.EqualTo("5"));
        Assert.That(winner.Item2, Is.EqualTo("5"));
        Assert.That(winner.Item2, Is.EqualTo("5"));

    }

    [Test]
    public void Scenario2() 
    {
    

        Extension core = new Extension();
    
        List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>> { 
            new Tuple<string, string, string>("2","2", "2"),
            new Tuple<string, string, string>("3","3", "3"),
            new Tuple<string, string, string>("4","4", "4"),
            new Tuple<string, string, string>("5", "5", "5"),
            new Tuple<string, string, string>("6","6", "6"),
            
        };
        Tuple<string, string, string> winner;
    
        bool result = core.winningThree(hand, out winner);

        Assert.That(result, Is.True);
    
        Assert.IsTrue(winner.Item1=="7" && winner.Item2=="7" && winner.Item3 == "7");

    }
}

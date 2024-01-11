using exercise.main;

Extension extension = new Extension();

List<Tuple<string, string, string>> hand = new List<Tuple<string, string, string>>
        {
            new Tuple<string, string, string>("K", "K", "K"),
            new Tuple<string, string, string>("A","A", "A")
        };
Tuple<string, string, string> winner;

bool result = extension.winningThree(hand, out winner);
Console.WriteLine("Hello, World!");
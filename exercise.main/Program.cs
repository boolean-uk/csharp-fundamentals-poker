// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using exercise.main;

Core core = new Core();

List<Tuple<string, string>> hand = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("K", "K"),
            new Tuple<string, string>("A", "A"),

        };
Tuple<string, string> winner;

bool result = core.winningPair(hand, out winner);
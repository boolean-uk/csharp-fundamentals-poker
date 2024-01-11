using exercise.main;

Core core = new Core();
Extension extension = new Extension();


List<Tuple<string, string>> hand = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("K", "5"),
            new Tuple<string, string>("3","7")
        };
Tuple<string, string> winner;
core.winningPair(hand, out winner);
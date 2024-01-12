using exercise.main;

UngradedExtension extension = new UngradedExtension();

//UngradedExtension.Deck deck = new UngradedExtension.Deck();
//Console.WriteLine("Deck");
//deck.Display();

//Console.WriteLine("\n");
//Console.WriteLine("Deck afther suffle");
//deck.Shuffle();
//deck.Display();

UngradedExtension.Player player1 = new UngradedExtension.Player("Nigel");
UngradedExtension.Player player2 = new UngradedExtension.Player("Stitch");
UngradedExtension.Player player3 = new UngradedExtension.Player("A Cat");

//Console.WriteLine("\n");
//Console.WriteLine("Player one hand before deals");
//player1.Display();

//Console.WriteLine("\n");
//Console.WriteLine("Player one hand afther one deals");
//deck.Deal(player1);
//player1.Display();

List<UngradedExtension.Player> players = new List<UngradedExtension.Player> { player1, player2, player3 };
UngradedExtension.PokerGame pokerGame1 = new UngradedExtension.PokerGame(players);
pokerGame1.start();

//Console.WriteLine("\n");
//Console.WriteLine("Deck");
//deck.Display();
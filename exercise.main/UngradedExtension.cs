using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class UngradedExtension
    {
        public class Card
        {
            public string _value { get; set; }
            public string _suit { get; set; }

            public Card(string value, string suit)
            {
                _value = value;
                _suit = suit;
            }
            public void Display()
            {
                Console.BackgroundColor = ConsoleColor.White;
                switch (_suit)
                {
                    case "H":
                    case "D":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "C":
                    case "S":
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                }

                Console.Write($"{_value}|{_suit}");

                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            public int NumericValue()
            {
                int score = 0;
                bool result = int.TryParse(_value, out score);
                if (!result)
                {
                    switch (_value)
                    {
                        case "J":
                            score = 11; break;
                        case "Q":
                            score = 12; break;
                        case "K":
                            score = 13; break;
                        case "A":
                            score = 14; break;
                    }
                }
                return score;
            }
        }
        public class Deck
        {
            public List<Card> Cards { get; set; }

            public Deck()
            {
                Cards = new List<Card>();
                string[] suits = { "H", "D", "C", "S" };
                string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

                foreach (string suit in suits)
                {
                    foreach (string value in values)
                    {
                        Cards.Add(new Card(value, suit));
                    }
                }
            }
            public void Display()
            {
                foreach (Card card in Cards)
                {
                    card.Display();
                }
            }

            public void Shuffle()
            {
                Random random = new Random();

                for (int i = 0; i < Cards.Count; i++)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    Card temp = Cards[i];
                    Cards[i] = Cards[randomIndex];
                    Cards[randomIndex] = temp;
                }
            }

            public void Deal(Player player)
            {
                Card result = Cards[Cards.Count - 1];
                Cards.RemoveAt(Cards.Count - 1);
                player.Hand.Add(result);
            }
            public void Deal(List<Card> cardList)
            {
                Card result = Cards[Cards.Count - 1];
                Cards.RemoveAt(Cards.Count - 1);
                cardList.Add(result);
            }
        }
        public class Player
        {
            public string Name { get; set; }
            public List<Card> Hand { get; set;}
            public Player(string name)
            {
                Name = name;
                Hand = new List<Card>();
            }
            public void Display()
            {
                Utils.WriteNormal($"{Name}: \n");
                Utils.WriteNormal(" ");
                foreach (Card card in Hand)
                {
                    card.Display();
                    Utils.WriteNormal(" ");
                }
            }
            public void ClearHand() 
            { 
                Hand.Clear();
            }
        }
        public class PokerGame
        {
            public List<Player> _players { get; set; }
            public Deck _deck { get; set; }
            public List<Card> _table { get; set; }
            public int _winner { get; set; }
            public PokerGame(List<Player> players)
            {
                _players = players;
                _deck = new Deck();
                _table = new List<Card>();
                _winner = 0;
            }

            public void render()
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.DarkGreen;

                foreach (Player player in _players)
                {
                    player.Display();
                    Console.WriteLine("\n");
                }

                Utils.WriteNormal("\nTable: \n");
                Utils.WriteNormal(" ");
                foreach (Card card in _table)
                {
                    card.Display();
                    Utils.WriteNormal(" ");
                }

                Thread.Sleep(400);
            }

            public void start()
            {
                _deck.Shuffle();

                foreach (Player player in _players)
                    player.ClearHand(); render();

                foreach (Player player in _players)
                    _deck.Deal(player); render();


                foreach (Player player in _players)
                    _deck.Deal(player); render();

                _deck.Deal(_table); render();
                _deck.Deal(_table); render();
                _deck.Deal(_table); render();

                Thread.Sleep(1000);

                _deck.Deal(_table); render();
                _deck.Deal(_table); render();

                writeWinners();
                Console.ResetColor();
            }

            public void writeWinners()
            {
                List<Tuple<Player, Card, int>> scores = new List<Tuple<Player, Card, int>>();

                foreach (Player player in _players)
                {
                    foreach (Card cardFromHand in player.Hand)
                    {
                        int match = 0;

                        foreach (Card otherCardInHand in player.Hand)
                        {
                            if (otherCardInHand != cardFromHand && cardFromHand._value == otherCardInHand._value)
                                match++;
                        }

                        foreach (Card cardFromTable in _table)
                        {
                            if (cardFromHand._value == cardFromTable._value)
                                match++;
                        }

                        scores.Add(new Tuple<Player, Card, int>(player, cardFromHand, match));
                    }
                }

                var mostMatches = scores.Max(score => score.Item3);
                var highestValueWithMostMatches = scores.Where(score => score.Item3 == mostMatches)
                                                        .Max(score => score.Item2.NumericValue());

                var winners = scores.Where(score => score.Item3 == mostMatches && score.Item2.NumericValue() == highestValueWithMostMatches)
                                    .ToList();

                var distinctWinners = winners.GroupBy(w => w.Item1)
                                 .Select(group => group.First())
                                 .ToList();

                Utils.WriteNormal("\n\n\nWinner(s):\n");
                foreach (var winner in distinctWinners)
                {
                    Utils.WriteNormal($"{winner.Item1.Name} with ");

                    // Display all matching cards in the winner's hand
                    foreach (var card in winner.Item1.Hand)
                    {
                        if (card.NumericValue() == highestValueWithMostMatches)
                        {
                            card.Display();
                            Utils.WriteNormal(" ");
                        }
                    }

                    // Display all matching cards on the table
                    foreach (var card in _table)
                    {
                        if (card.NumericValue() == highestValueWithMostMatches)
                        {
                            card.Display();
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}

public class Utils
{
    public static void WriteNormal(String text)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(text);
    }
}
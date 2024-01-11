using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static exercise.main.UngradedExtension;
using System.Threading;

namespace exercise.main
{
    public class UngradedExtension
    {
        public class Card
        {
            public string _value { get; set; }
            public string Suit { get; set; }

            public Card(string value, string suit)
            {
                _value = value;
                Suit = suit;
            }
            public void Display()
            {
                Console.Write($"{_value}|{Suit}  ");
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
                Console.WriteLine($"{Name}: ");
                foreach (Card card in Hand)
                {
                    card.Display();
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
            public void start()
            {
                foreach (Player player in _players)
                    player.ClearHand(); render();

                foreach (Player player in _players)
                    _deck.Deal(player); render();

                foreach (Player player in _players)
                    _deck.Deal(player); render();

                _deck.Deal(_table); render();
                _deck.Deal(_table); render();
                _deck.Deal(_table); render();

                //Thread.Sleep(2000);

                _deck.Deal(_table); render();
                _deck.Deal(_table); render();

                finish();
            }
            public void render()
            {
                Console.Clear();

                foreach (Player player in _players)
                {
                    player.Display();
                    Console.WriteLine("\n");
                }

                Console.WriteLine("Table: ");
                foreach (Card card in _table)
                    card.Display();

                //Thread.Sleep(400);
            }
            public void finish()
            {
                List<Tuple<Player, Card, int>> scores = new List<Tuple<Player, Card, int>>();

                foreach (Player player in _players)
                {
                    foreach (Card cardFromHand in player.Hand)
                    {
                        int match = 0;
                        foreach (Card cardFromTable in _table)
                        {
                            if (cardFromHand._value == cardFromTable._value && cardFromHand.Suit == cardFromTable.Suit)
                                match++;
                        }
                        scores.Add(new Tuple<Player, Card, int>(player, cardFromHand, match));
                    }
                }

                var bestScores = scores.OrderByDescending(score => score.Item3)
                                       .ThenByDescending(score => score.Item2.NumericValue())
                                       .ToList();

                var highestScore = bestScores.First().Item3;

                var winners = bestScores.Where(score => score.Item3 == highestScore).ToList();

                Console.WriteLine("\nWinner(s):");
                foreach (var winner in winners)
                {
                    Console.WriteLine($"{winner.Item1.Name} with {winner.Item2.Display}");
                }
            }

        }
    }
}

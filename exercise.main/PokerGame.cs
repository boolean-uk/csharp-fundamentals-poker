using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class PokerGame
    {
        public PokerGame()
        {
            mDeck = new Deck();
            Table = new List<Card>();

            InitializePlayers();
        }
        public Deck mDeck { get; set; }

        public List<Card> Table { get; set; }

        public List<Player> mPlayers { get; set; }

        public void InitializePlayers()
        {
            Console.WriteLine("Enter Player 1's name: ");
            mPlayers = new List<Player>();
            mPlayers.Add(new Player(Console.ReadLine()));

            Console.WriteLine("Enter Player 2's name: ");
            mPlayers.Add(new Player(Console.ReadLine()));

            Console.WriteLine($"Welcome to Poker night, {mPlayers.First().Name} and {mPlayers.Last().Name}!");
        }

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Lets Begin!");

            mPlayers.First().Hand.Add(mDeck.Deal());
            mPlayers.First().Hand.Add(mDeck.Deal());

            mPlayers.Last().Hand.Add(mDeck.Deal());
            mPlayers.Last().Hand.Add(mDeck.Deal());

            Table.Add(mDeck.Deal());
            Table.Add(mDeck.Deal());
            Table.Add(mDeck.Deal());

            PrintTableAndHand();
        }

        public void PrintTableAndHand()
        {
            Console.Clear();

            Console.WriteLine($"{mPlayers.First().Name}'s Cards: {mPlayers.First().Hand.First().mCard.Item1}{mPlayers.First().Hand.First().mCard.Item2}, {mPlayers.First().Hand.Last().mCard.Item1}{mPlayers.First().Hand.Last().mCard.Item2}");
            Console.WriteLine($"{mPlayers.Last().Name}'s Cards: {mPlayers.Last().Hand.First().mCard.Item1}{mPlayers.Last().Hand.First().mCard.Item2}, {mPlayers.Last().Hand.Last().mCard.Item1}{mPlayers.Last().Hand.Last().mCard.Item2}");

            foreach (var c in Table)
            {
                Console.Write($"[{c.mCard.Item1}{c.mCard.Item2}] ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise.main
{
    internal class PokerGame
    {
        private List<Player> _players = new List<Player>();
        Deck deck = new Deck();
        Table flop = new Table();
        Winner winner = new Winner();

        public PokerGame()
        {
            Initiate();
            RunGame();
        }

        public void Initiate()
        {
            Console.WriteLine("With how many players are you playing?");
            bool ask = false;
            int players = 0;
            while (!ask)
            {

                string playerAmount = Console.ReadLine();
                ask = Int32.TryParse(playerAmount, out players);
                if (players > 20)
                {
                    Console.WriteLine("Maximum players is 20, enter a new number");
                    ask = false;
                    continue;
                }
                if (!ask) Console.WriteLine("Please give a number");
            }
            
            for (int i = 0; i < players; i++)
            {
                Console.WriteLine($"How should I call player {i + 1}?");
                _players.Add(new Player(Console.ReadLine().Trim()));
            }

        }
        public void Reset()
        {
            deck.Shuffle();
            foreach(Player player in _players)
            {
                player.Reset();
            }
            flop.Reset();
        }

        public void FinishGame(bool playersLeft = true)
        {
            while (flop.Flop.Count < 5)
            {
                flop.Draw(deck.Deal());
            }
            Console.WriteLine($"The game is finished!");
            if (playersLeft) Console.WriteLine($"{winner.DetermineWinner(_players, flop.Flop).Name} has won the game");
            else Console.WriteLine("Nobody has won the game");
            ShowGame();
            Console.WriteLine("Do you want to play another round? (y/n)");
            bool ask = true;
            while (ask)
            {
                switch (Console.ReadLine().ToLower().Trim())
                {
                    case "y":
                    case "yes":
                        Reset();
                        RunGame();
                        ask = false;
                        break;
                    case "n":
                    case "no":
                        Console.WriteLine("Okay, thanks for playing!");
                        ask = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Couldn't read the input, please answer (y)es or (n)o");
                        break;
                }
            }
        }
        public void RunGame()
        {
            SetupGame();
            NextRound();
            flop.Setup(deck.Deal(), deck.Deal(), deck.Deal());
            NextRound();
            flop.Draw(deck.Deal());
            NextRound();
            flop.Draw(deck.Deal());
            NextRound();
            FinishGame();
        }
        public void SetupGame()
        {
            deck.Shuffle();
            foreach (Player player in _players)
            {
                player.Draw(deck.Deal());
                player.Draw(deck.Deal());
            }
        }

        public void ShowGame()
        {
            Console.WriteLine(flop.ToString());
            foreach (Player player in _players)
            {
                if (!player.IsPlaying) continue;
                Console.WriteLine(player.ShowPlayerHand());
            }
        }

        public void NextRound()
        {
            ShowGame();
            foreach (Player player in _players)
            {
                if (!player.IsPlaying) continue;
                Console.WriteLine($"{player.Name}, do you want to (f)old? ");
                string input = Console.ReadLine().ToLower().Trim();
                if (input == "fold" || input == "f")
                {
                    player.GiveUp();
                }
            }
            if (_players.Count(x => x.IsPlaying) == 1)
            {
                FinishGame();
                return;
            }
            if (_players.Count(x => x.IsPlaying) == 0) FinishGame(false);

        } 

    }
}

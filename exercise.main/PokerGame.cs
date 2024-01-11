using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise.main
{
    internal class PokerGame
    {
        private List<Player> _players = new List<Player>
        {
            new Player("Player 1"),
            new Player("Player 2")
        };
        Deck deck = new Deck();
        Table flop = new Table();

        public PokerGame()
        {
            RunGame();
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

            Console.WriteLine($"The game is finished!");
            ShowGame();
            Console.WriteLine("Do you want to play another round? (y/n)");
            bool ask = true;
            while (ask)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "y" :
                    case "yes":
                        Reset();
                        RunGame();
                        ask = false;
                        break;
                    case "n":
                    case "no":
                        Console.WriteLine("Okay, thanks for playing!");
                        ask = false;
                        break;
                    default:
                        Console.WriteLine("Couldn't read the input, please answer (y)es or (n)o");
                        break;
                }
            }


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
                string input = Console.ReadLine();
                if (input == "fold" || input == "f")
                {
                    player.GiveUp();
                }
            }
        } 

    }
}

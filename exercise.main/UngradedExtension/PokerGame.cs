using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.UngradedExtension
{
    public class PokerGame
    {
        Player player1;
        Player player2;
        Table table;
        Deck deck;
        public PokerGame(string p1, string p2) {
            player1 = new Player(p1);
            player2 = new Player(p2);
            table = new Table();
            deck = new Deck();
        }


        public void Start()
        {
            deck.InitializeDeck();
            player1.ClearHand();
            player2.ClearHand();
            table.clearTable();

            player1.AddCardToHand(deck.Deal());
            player2.AddCardToHand(deck.Deal());
            player1.AddCardToHand(deck.Deal());
            player2.AddCardToHand(deck.Deal());

            table.AddCard(deck.Deal());
            table.AddCard(deck.Deal());
            table.AddCard(deck.Deal());

        }

        public void playTurn()
        {
            table.AddCard(deck.Deal());
        }

        public void simulateGame()
        {
            Start();
            PrintGameStatus();
            playTurn();

            playTurn();

            Console.WriteLine("Game over");

            PrintGameStatus();
        }

        public void PrintGameStatus()
        {
            Console.WriteLine("The game now looks like: ");
            this.table.PrintTable();
            this.player1.PrintHand();
            this.player2.PrintHand();
        }
    }
}

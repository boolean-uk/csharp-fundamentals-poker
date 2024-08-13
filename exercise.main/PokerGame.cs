using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class PokerGame
    {
        Player player1 = new Player("Player1");
        Player player2 = new Player("Player2");
        List<Player> players = new List<Player>();
        Deck deck = new Deck();
        List<Card> table = new List<Card>();

        public string CalculateWinner()
        {
            //Calculate Winner
            return "Someone";
        }

        public void StartNewGame(int numberOfPlayers = 2)
        {
            //Clear player hands
            player1.ClearHand();
            player2.ClearHand();
            table.Clear();
            Console.WriteLine("Clearing both player's hands and table\n");

            //Initialize and shuffle deck
            deck.InitializeDeck();
            deck.ShuffleDeck();
            Console.WriteLine("Deck shuffled\n");

            //Deal 2 cards to each player
            player1.AddCard(deck.Deal());
            player2.AddCard(deck.Deal());
            player1.AddCard(deck.Deal());
            player2.AddCard(deck.Deal());
            //Console.WriteLine(player1.name + " has:\n" + player1.hand[0].cardName + "\n" + player1.hand[1].cardName + "\n");
            //Console.WriteLine(player2.name + " has:\n" + player2.hand[0].cardName + "\n" + player2.hand[1].cardName + "\n");

            //Deal 3 cards to the table
            table.Add(deck.Deal());
            table.Add(deck.Deal());
            table.Add(deck.Deal());
            //Console.WriteLine("Table has:\n" + table[0].cardName + "\n" + table[1].cardName + "\n" + table[2].cardName + "\n");

            //Deal 2 more cards to the table
            table.Add(deck.Deal());
            table.Add(deck.Deal());
            //Console.WriteLine("Table recieved:\n" + table[3].cardName + "\n" + table[4].cardName + "\n");

            //Write everything at once to make it less troublesome
            Console.WriteLine("Table has:");
            foreach (Card card in table)
            {
                Console.WriteLine(card.FullName());
            }
            Console.WriteLine(player1.name + " has:\n" + player1.hand[0].FullName() + "\n" + player1.hand[1].FullName());
            Console.WriteLine(player2.name + " has:\n" + player2.hand[0].FullName() + "\n" + player2.hand[1].FullName());

            Console.WriteLine(CalculateWinner() + " wins!\n");
        }
    }
}

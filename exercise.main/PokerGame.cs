using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class PokerGame
    {
        Deck deck = new Deck();
        List<Player> players = new List<Player>();  
        List<Card> board = new List<Card>();


        public PokerGame(string player1Name, string player2Name)
        {
            Player player1 = new Player(player1Name);
            Player player2 = new Player(player2Name);
            players.Add(player1);
            players.Add(player2);
        }

        private string CreateBoardString()
        {
            string text = "";
            foreach (var card in board)
            {
                text = text + card.RepresentCard() + ", ";
            }
            text = text.Remove(text.Length - 2);
            return text;
        }

        public void RunAGame()
        {
            Console.WriteLine("New game started!\nDealing cards!");
            // start by generating the deck.
            deck.InitializeDeck();

            //then we shuffle the deck
            deck.ShuffleDeck();


            //as in real texas holdem, we yeet the first card
            deck.DealCard();

            //time to deal cards to players in this order 0,0 -> 1,0 ->1,1 -> 2,1 -> 2,2
            foreach (var player in players)
            {
                player.AddCard(deck.DealCard());
            }
            foreach (var player in players)
            {
                player.AddCard(deck.DealCard());
            }
            
            foreach (var player in players)
            {
                Console.WriteLine(player.name + "'s" + " hand: " + player.cards[0].RepresentCard() + " and " + player.cards[1].RepresentCard());
            }

            Console.WriteLine("Dealing the flop: ");
            // deal first 3 cards, also known as the flop
            for (int i = 0; i < 3; i++)
            {
                board.Add(deck.DealCard());
            }

            Console.WriteLine("Flop shows: " + CreateBoardString());

            // as in texas holdem, we yeet one card before the turn
            deck.DealCard();
            board.Add(deck.DealCard());

            Console.WriteLine("Turn shows: " + CreateBoardString());

            // as in texas holdem, we yeet one card before the river
            deck.DealCard();
            board.Add(deck.DealCard());

            Console.WriteLine("River shows: " + CreateBoardString());

        }


    }
}

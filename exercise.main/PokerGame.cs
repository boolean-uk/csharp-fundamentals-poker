using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Objects;
namespace exercise.main
{
    public  class PokerGame
    {

        List<string> Values = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        List<string> Suits = ["Spades", "Hearts", "Diamonds", "Clubs"];
        List<Card> Cards = new List<Card>();
        
        public void startGame()
        {
            foreach (string suit in Suits) { 
                foreach(string value in Values)
                {
                    Card current = new Card(value, suit);
                    Cards.Add(current);
                }
            }

            Deck deck = new Deck(Cards);            
            deck.Shuffle();

            Console.WriteLine("Enter Player1 name: ");
            string player1Name = Console.ReadLine();
            Console.WriteLine("Enter Player2 name: ");
            string player2Name = Console.ReadLine();

            List<Card> player1Hand = new List<Card>();
            List<Card> player2Hand = new List<Card>();
            player1Hand.Add(deck.Deal());
            player2Hand.Add(deck.Deal());
            player1Hand.Add(deck.Deal());
            player2Hand.Add(deck.Deal());

            Player player1 = new Player(player1Name, player1Hand);
            Player player2 = new Player(player2Name, player2Hand);

            Console.WriteLine();
            Console.WriteLine("Player names");
            Console.WriteLine(player1.Name + " " + player2.Name);
            Console.WriteLine();
            Console.WriteLine($"{player1.Name} hand:");

            foreach(Card card in player1.Hand){
                 Console.Write(card.Value + " " + card.Suit + " ");
            }

            Console.WriteLine();
            Console.WriteLine(); 
            Console.WriteLine($"{player2.Name} hand:");

            foreach (Card card in player2.Hand) {
                 Console.Write(card.Value + " " + card.Suit + " ");     
            }

            Console.WriteLine();

            List<Card> flop = new List<Card>();
            flop.Add(deck.Deal());
            flop.Add(deck.Deal());
            flop.Add(deck.Deal());

            Console.WriteLine();
            Console.WriteLine("Dealer flops cards: ");
            Console.WriteLine("Cards on table: ");
            foreach (Card card in flop){
                Console.Write(card.Value + " " + card.Suit + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dealer turns card: ");
            Card turn = deck.Deal();
            Console.WriteLine("Cards on table: ");

            foreach (Card card in flop)
            {
                Console.Write(card.Value + " " + card.Suit + " " );
            }
            Console.WriteLine(turn.Value + " " + turn.Suit + " ");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dealer plays river card");
            Card river = deck.Deal();
            Console.WriteLine("Cards on table: ");
            foreach (Card card in flop)
            {
                Console.Write(card.Value + " " + card.Suit + " ");
            }

            Console.Write(turn.Value + " " + turn.Suit + " ");
            Console.Write(river.Value + " " + river.Suit + " ");
            Console.WriteLine();
            Console.WriteLine();

        }


        public int GetCardValue(Card card){

            if (card.Value == "2")
            {
                return 2;
            } else if (card.Value == "3")
            {
                return 3;
            } else if (card.Value == "4")
            {
                return 4;
            } else if (card.Value == "5")
            {
                return 5;
            } else if (card.Value == "6")
            {
                return 6;
            } else if (card.Value == "7")
            {
                return 7; 
            } else if (card.Value == "8")
            {
                return 8;
            } else if (card.Value == "9")
            {
                return 9;
            } else if (card.Value == "10")
            {
                return 10;
            } else if (card.Value == "J")
            {
                return 11;
            } else if (card.Value == "Q")
            {
                return 12;
            } else if (card.Value == "K")
            {
                return 13;
            } else if (card.Value == "A")
            {
                return 14;
            } else
            {
                return 0;
            }

        }

        public void CalculateWinner(){




        }

        
    }
    
        
    
}

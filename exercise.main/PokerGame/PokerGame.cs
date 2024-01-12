using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.PokerGame
{
    internal class PokerGame
    {
        public PokerGame() 
        {
            Console.WriteLine("generating deck");
            Deck deck = new Deck();
            Console.WriteLine("dealing cards");
            Player p1 = new Player("mandy");
            Player p2 = new Player("andy");
            List<Card> cardsOnTable = new List<Card>();
            List<Player> players = new List<Player>() { p1, p2 };

            foreach (Player p in players) 
            {
                List<Card> cards = new List<Card>();
                for (int i = 0; i < 2; i++) 
                {
                    cards.Add(deck.Deal());
                }
                p._cards = cards;
            }
            Console.WriteLine("cards are dealt");

            Console.WriteLine("dealing first three cards");
            for (int i = 0; i < 3; i++) 
            {
                Card card = deck.Deal();
                cardsOnTable.Add(card);
            }

            Console.WriteLine("dealing last two cards");

            for (int i = 0; i < 2; i++)
            {
                Card card = deck.Deal();
                cardsOnTable.Add(card);
            }
            Console.WriteLine("finding the winner");
            string winner = getWinner(p1, p2, cardsOnTable);
            Console.WriteLine("the winner is: " + winner);
        }

        public string getWinner(Player player1, Player player2, List<Card> deck) 
        {
            List<Player> players = new List<Player>() 
            {
                player1,
                player2,
            };
            string winner = "draw";
            int occs = 0; 
            foreach (Player p in players) 
            {
                int sumPair1 = 0;
                int sumPair2 = 0;

                if (p._cards[0] == p._cards[1]) 
                {
                    sumPair1++;
                    sumPair2++;
                }

                int occurence1 = deck.Count(d => d._cardValue == p._cards[0]._cardValue);
                int occurence2 = deck.Count(d => d._cardValue == p._cards[1]._cardValue);

                int total = occurence1 >= occurence2 ? occurence1 : occurence2;
                if (total > occs) 
                {
                    occs = total;
                    winner = p._name;
                }
            }
            return winner;
        }
    }
}

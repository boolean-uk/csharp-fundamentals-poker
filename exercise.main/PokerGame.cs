using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class PokerGame
    {

        // Only for creating unique players
        private string[] names = { "James", "Mia", "Pia", "John", "Mikalen", "Erik", "Emma", "Sven" };
        private Player? player1;
        private Player? player2;
        private Deck? deck;
        private List<Card>? tableCards;
        public void StartGame(int players) {
            deck = new Deck();
            tableCards = new List<Card>();
            GeneratePlayers();
            DealFirstCards();

        }

        private void DealFirstCards()
        {
            for (int i = 0; i < 2; i++) {
                player1.Hit();
                player2.Hit();
            }
        }

        public void GameProgress() {
            if (tableCards.Count < 5) {
                tableCards.Add(deck.Deal());
                Console.WriteLine("Cards on the table: "+ tableCards);
            }
        }

        private void GeneratePlayers() {
            Random rd = new Random();
            player1 = new Player(names[rd.Next(names.Length)], deck);
            player2 = new Player(names[rd.Next(names.Length)], deck);
        }

        

        public void Winner() {

        }
    }
}
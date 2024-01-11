using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    internal class PokerGame
    {
        private Player _player1;
        private Player _player2;
        private Deck _deck;
        private List<Card> _table = new List<Card> { };

        public PokerGame(string name1, string name2)
        {
            _player1 = new Player(name1);
            _player2 = new Player(name2);
            _deck = new Deck();
        }

        public void StartGame()
        {
            FirstPhase();
            SecondPhase();
            ConcludeGame();
        }

        public void FirstPhase()
        {
            _player1.ClearCards();
            _player2.ClearCards();
            _deck.Shuffle();
            _table.Add(_deck.Deal());
            for (int i = 0; i < 2; i++)
            {
                _player1.Draw(_deck.Deal());
                _player2.Draw(_deck.Deal());
                _table.Add(_deck.Deal());
            }
            WriteStatus();
        }

        public void SecondPhase()
        {
            _table.Add(_deck.Deal());
            _table.Add(_deck.Deal());
            WriteStatus();
        }

        public void ConcludeGame()
        {
            Console.WriteLine("\nTBD");
        }

        public void WriteStatus()
        {
            Console.WriteLine("\nTable has: ");
            foreach (Card card in _table)
            {
                Console.WriteLine(card.GetCardString());
            }
            Console.WriteLine("\nPlayer 1 has: ");
            foreach  (Card card in _player1.ReturnCard())
            {
                Console.WriteLine(card.GetCardString());
            }
            Console.WriteLine("\nPlayer 2 has: ");
            foreach (Card card in _player2.ReturnCard())
            {
                Console.WriteLine(card.GetCardString());
            }

            Console.ReadLine(); //pauses for enter key
        }
    }
}

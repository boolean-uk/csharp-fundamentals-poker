using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    internal class PokerGame
    {
        private List<Player> _players = new List<Player>();
        private Deck _deck = new Deck();
        private List<Card> _board = new List<Card>();

        public List<Player> Players { get { return _players; } }
        public Deck Deck { get { return _deck; } }
        public List<Card> Board { get { return _board; } }

        public PokerGame(string p1, string p2)
        {
            //add players to player class
            Player player = new Player(p1);
            AddPlayer(player);
            player = new Player(p2);
            AddPlayer(player);

            _deck = new Deck();
        }

        private void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void NextTurn()
        {
            //check board state
            switch (_board.Count)
            {
                case 0: NewBoard(); break;
                case 5: ClearBoard(); NewBoard(); break;
                default: RevealCard(); break;
            }
            BoardState();
        }

        private void NewBoard()
        {
            foreach (Player player in _players)
            {
                player.Draw(_deck.Deal());
                player.Draw(_deck.Deal());
            }
            _board.Add(_deck.Deal());
            _board.Add(_deck.Deal());
            _board.Add(_deck.Deal());
        }

        private void ClearBoard()
        {
            _board.Clear();
            foreach (Player player in _players)
            {
                player.EmptyHand();
            }
        }

        private void RevealCard()
        {
            _board.Add(_deck.Deal());
        }

        private void BoardState()
        {
            foreach (Player player in _players)
            {
                Console.WriteLine($"{player.Name} hand:");
                foreach (Card card in player.Hand)
                {
                    card.PrintCard();
                }
                Console.WriteLine();
            }

            Console.WriteLine("Board:");
            foreach (Card card in _board)
            {
                card.PrintCard();
            }
            Console.WriteLine();
        }

    }
}

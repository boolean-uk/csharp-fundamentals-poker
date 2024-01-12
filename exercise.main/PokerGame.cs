using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class PokerGame
    {
        private Player _player1;
        private Player _player2;

        private Deck _deck = new Deck();
        private List<Card> _boardState = new List<Card>();
        private List<Card> _discardPile = new List<Card>();

        public void addToBoardState(Card card)
        {
            BoardState.Add(card);
        }

        public void initialDeal()
        {
            Player1.addToHand(Deck.Deal());
            Player2.addToHand(Deck.Deal());
            Player1.addToHand(Deck.Deal());
            Player2.addToHand(Deck.Deal());
        }

        public void flop()
        {
            DiscardPile.Add(Deck.Deal());
            BoardState.Add(Deck.Deal());
            BoardState.Add(Deck.Deal());
            BoardState.Add(Deck.Deal());
        }

        public void turn()
        {
            DiscardPile.Add(Deck.Deal());
            BoardState.Add(Deck.Deal());
        }

        public void river()
        {
            DiscardPile.Add(Deck.Deal());
            BoardState.Add(Deck.Deal());
        }

        public Player Player1 { get { return _player1; } set { _player1 = value; } }
        public Player Player2 { get { return _player2; } set { _player2 = value; } }
        public Deck Deck { get { return Deck; } set { Deck = value; } }

        public List<Card> BoardState { get { return BoardState;  } set { BoardState = value; } }
        public List<Card> DiscardPile { get { return _discardPile;  } set { _discardPile = value; } }
    }
}

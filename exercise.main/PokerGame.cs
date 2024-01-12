using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class PokerGame
    {
        Player _player1;
        Player _player2;
        Deck _deck;
        List<Card> _cardsOnTable;
        public PokerGame(Player player1, Player player2, Deck deck)
        {
            _player1 = player1;
            _player2 = player2;
            _deck = deck;
            _cardsOnTable = new List<Card>();
        }


        public void InitializePlay()
        {
            _deck.Shuffle();
            _player1.AddCard(_deck.Deal());
            _player1.AddCard(_deck.Deal());

            _player2.AddCard(_deck.Deal());
            _player2.AddCard(_deck.Deal());


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Game
{
    public class PokerGame
    {
        Player _player1;
        List<Card> _player1PlayedCards = new List<Card>();

        Player _player2;
        List<Card> _player2PlayedCards = new List<Card>();

        Deck _deck;
        List<Card> _deckCards = new List<Card>();

        Core _core = new Core();
        Extension _extension = new Extension();

        public PokerGame()
        {
            _player1 = new Player("Player 1");
            _player2 = new Player("Player 2");
            _deck = new Deck();
        }

        public void startGame()
        {
            Console.WriteLine("Starting game: \n");
            setTable();
        }

        public void showCards()
        {
            _player1PlayedCards = _player1.playCards();
            _player2PlayedCards = _player2.playCards();
        }

        public void checkVictory()
        {
            Console.WriteLine();
            Console.WriteLine("The cards on the table is:");
            foreach (Card card in _deckCards)
            {
                Console.Write($"{card.getValue()} of {card.getSuit()}, ");
            }
            Console.WriteLine();

            List<Tuple<string, string>> p1Pairs = new List<Tuple<string, string>>();
            foreach (Card card in _deckCards)
            {
                p1Pairs.Add(new Tuple<string, string>(_player1PlayedCards.First().getValue(), card.getValue()));
                p1Pairs.Add(new Tuple<string, string>(_player1PlayedCards.Last().getValue(), card.getValue()));
            }
            IEnumerable<Tuple<string, string>> p1Values = p1Pairs;


            List<Tuple<string, string>> p2Pairs = new List<Tuple<string, string>>();
            foreach (Card card in _deckCards)
            {
                p2Pairs.Add(new Tuple<string, string>(_player2PlayedCards.First().getValue(), card.getValue()));
                p2Pairs.Add(new Tuple<string, string>(_player2PlayedCards.Last().getValue(), card.getValue()));
            }
            IEnumerable<Tuple<string, string>> p2Values = p2Pairs;

            Tuple<string, string> p1Result;
            bool p1 = _core.winningPair(p1Values, out p1Result);
            Tuple<string, string> p2Result;
            bool p2 = _core.winningPair(p2Values, out p2Result);

            Console.WriteLine($"{_player1.getPlayerName()} had:\n" +
                $"{_player1PlayedCards.First().getValue()} of " +
                $"{_player1PlayedCards.First().getSuit()} and " +
                $"{_player1PlayedCards.Last().getValue()} of " +
                $"{_player1PlayedCards.Last().getSuit()}");

            Console.WriteLine($"{_player2.getPlayerName()} had:\n" +
                $"{_player2PlayedCards.First().getValue()} of " +
                $"{_player2PlayedCards.First().getSuit()} and " +
                $"{_player2PlayedCards.Last().getValue()} of " +
                $"{_player2PlayedCards.Last().getSuit()}");

            // Pair victory
            if (p1 && p2)
            {
                if (_core.GetValueOfCard(p1Result.Item1) > _core.GetValueOfCard(p2Result.Item1))
                { victoryPair(_player1, p1Result); }
                else { victoryPair(_player2, p2Result); };
            }
            else if (p1)
            {
                victoryPair(_player1, p1Result);
            }
            else if (p2)
            {
                victoryPair(_player2, p2Result);
            }
            else
            {
                Console.WriteLine("Game over, 5 cards have been dealt. \n No one wins.");
            }
        }

        internal void victoryPair(Player player, Tuple<string, string> winningCards)
        {
            Console.WriteLine($"{player.getPlayerName()} won with a pair of {winningCards.Item1}'s!\nGame is over.");
        }

        public void setTable()
        {
            Console.WriteLine("Setting the table.");
            dealCardsToPlayers();
            dealCardsToPlayers();
            Console.WriteLine("Dealing 3 cards onto the table.");
            for (int i = 0; i < 3; i++)
            {
                dealCards();
            }
            Console.Write("Table finished setup\n\n");
        }

        public void dealCardsToPlayers()
        {
            _player1.takeCard(_deck.Deal());
            Console.WriteLine($"Dealer gave {_player1.getPlayerName()} a card.");
            _player2.takeCard(_deck.Deal());
            Console.WriteLine($"Dealer gave {_player2.getPlayerName()} a card.");
        }

        public void dealCards()
        {
            Card newCard = _deck.Deal();
            _deckCards.Add(newCard);
            Console.WriteLine($"{newCard.getValue()} of {newCard.getSuit()} was added to the table.");
        }
    }
}

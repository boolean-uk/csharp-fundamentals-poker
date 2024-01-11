using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class PokerGame
    {
        private List<Player> _playerList = new List<Player>();
        private List<Card> _tableCards = new List<Card>();
        private string _tableString;
        private int _playerIndex;
        private int _stageIndex;

        
        public PokerGame()
        {
        }
        public void RegisterPlayer(Player player, int ID)
        {
            {
                player.getPlayerName(player, ID);
                PlayerList.Add(player);
            }
            Console.WriteLine($"{PlayerList.Count} players has been registered.\n");
            Console.WriteLine("Press 'ENTER' to continue.\n");
        }
        public async void PlayerTurn(List<Card> deck)
        { 
            if(PlayerIndex == PlayerList.Count() || StageIndex == 0)
            {
                PlayerIndex = 0;
                NextStage(deck);
            }
                Console.Clear();
                Console.Write($"It is {PlayerList[PlayerIndex].Name}'s turn.\n");
                if (TableCards.Count != 0)
                {
                    Console.WriteLine($"Table cards: {TableString}\n");
                }
                Console.Write("Available inputs:\n");
                Console.Write("1: See your cards\n");
                Console.Write("2: Continue\n");
                switch (Console.ReadLine())
                {
                    case "1": PlayerList[PlayerIndex].showCards(); PlayerTurn(deck); break;
                    case "2": PlayerIndex++; PlayerTurn(deck); break;
                    
                }
        }
        public void Stage1(List<Card> deck)
        {
            Console.Clear();
            foreach (var player in _playerList)
            {
                Card card = new Card(string.Empty, string.Empty);
                card = Deck.dealCard(deck);
                player.Cards.Add(card); 
            }
            foreach (var player in _playerList)
            {
                Card card = Deck.dealCard(deck);
                player.Cards.Add(card);
            }
            Console.WriteLine("Players have been dealt their cards.\n");
            Console.WriteLine("Press 'ENTER' to continue.\n");
            if (Console.ReadKey().Key.ToString() == "Enter")
            {
                PlayerTurn(deck);
            }
        }
        public void Stage2(List<Card> deck)
        {
            Console.Clear();
            for(int i = 0; i < 3; i++)
            {
                Card card = Deck.dealCard(deck);
                TableCards.Add(card);
                TableString += $"{card.Value}{card.Suit}, ";
            }
            Console.WriteLine("Three cards have been placed on the table.");
            Console.WriteLine("Press 'ENTER' to continue.");
            if (Console.ReadKey().Key.ToString() == "Enter")
            {
                PlayerTurn(deck);
            }
        }

        public void Stage3(List<Card> deck)
        {
            Console.Clear();
            Card card = Deck.dealCard(deck);
            TableCards.Add(card);
            TableString += $"{card.Value}{card.Suit} ";
            Console.WriteLine("A fourth card has been placed on the table.");
            Console.WriteLine("Press 'ENTER' to continue.");
            if (Console.ReadKey().Key.ToString() == "Enter")
            {
                PlayerTurn(deck);
            }
        }

        public async void Stage4(List<Card> deck)
        {
            Console.Clear();
            Card card = Deck.dealCard(deck);
            TableCards.Add(card);
            TableString += $",{card.Value}{card.Suit} ";
            Console.WriteLine("A fifth card has been placed on the table.");
            Console.WriteLine("Press 'ENTER' to continue.");
            if (Console.ReadKey().Key.ToString() == "Enter")
            {
                PlayerTurn(deck);
            }
        }
        public void NextStage(List<Card> deck)
        {
            switch (StageIndex)
            {
                case 0: StageIndex++; Stage1(deck); break;
                case 1: StageIndex++; Stage2(deck); break;
                case 2: StageIndex++; Stage3(deck); break;
                case 3: StageIndex++; Stage4(deck); break;

            }
        }

        public List<Player> PlayerList { get { return _playerList; } set { PlayerList = value; } }
        public List<Card> TableCards { get { return _tableCards; } set { _tableCards = value; } }
        public string TableString { get { return _tableString; } set { _tableString = value; } }
        public int PlayerIndex { get { return _playerIndex; } set { _playerIndex = value; } }
        public int StageIndex {  get { return _stageIndex; } set { _stageIndex = value; } }
    }
}

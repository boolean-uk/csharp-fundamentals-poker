using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    public class PokerGame
    {
        public List<Player> Players;
        public Deck Deck;
        public List<Card> Table;
        public PokerGame()
        {
            Players = new List<Player>();

            Player player1 = new Player("Martin");
            JoinGame(player1);

            Player player2 = new Player();
            JoinGame(player2);

            Deck = new Deck();
            Table = new List<Card>();
        }

        public void JoinGame(Player player)
        {
            Players.Add(player);
        }

        public void DealTable()
        {
            Card card = Deck.Deal();
            Console.WriteLine($"[{card.Value} of {card.Suit}] ");
            Table.Add(card);
        }

        public void DealPlayer(Player player)
        {
            player.TakeCard(Deck.Deal());
        }

        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> lookup = new Dictionary<string, int>()
            {
                {"1",1},
                {"2",2},
                {"3",3},
                {"4",4},
                {"5",5},
                {"6",6},
                {"7",7},
                {"8",8},
                {"9",9},
                {"10",10},
                {"J",11},
                {"Q",12},
                {"K",13},
                {"A",14}
            };
            return lookup[card];
        }
        public List<Tuple<Player, List<Card>>> GetResults()
        {

            List<Tuple<Player, List<Card>>> results = new List<Tuple<Player, List<Card>>>();

            foreach (Player p in Players)
            {
                List<Card> allCards = p.ShowCards().Concat(Table).ToList();

                var bestGroup = allCards.GroupBy(card => GetValueOfCard(card.Value))
                                        .OrderByDescending(group => group.Count())
                                        .ThenByDescending(group => group.Key)
                                        .First();

                Tuple<Player, List<Card>> playerResults = Tuple.Create(p, bestGroup.ToList());
                results.Add(playerResults);

            }

            results = results.OrderByDescending(a => a.Item2.Count())
                .ThenByDescending(a => GetValueOfCard(a.Item2[0].Value)).ToList();
            
            return results;
        }
    }
}

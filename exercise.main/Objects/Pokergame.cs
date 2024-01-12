using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Pokergame
    {
        public Player player1 = new Player();
        public Player player2 = new Player();
        Deck deck = new Deck();
        public List<Card> table = new List<Card>();
        public Pokergame(string namePlayer1, string namePlayer2) {
            player1.Name = namePlayer1;
            player2.Name = namePlayer2;
        }
        public bool gameContinues = true;




        public void Start()
        {
            gameContinues = true;
            deck.Shuffle();
            DealPlayers(2);
            DealTable(3);
        }
        void DealPlayers(int amount) 
        {
            if (amount < 1) { return; }
            for (int i = 0; i < amount; i++)
            {
                player1.Draw(deck.Deal()); player2.Draw(deck.Deal());
            }
        }
        public void DealTable(int amount)
        {
            if (amount < 1) { return; }
            for (int i = 0; i < amount; i++)
            {
                table.Add(deck.Deal());
            }
        }
        bool checkHand(Player player, List<Card> table) {
            List<Card> playerHand = player.GetHand();
            var check = playerHand.Concat(table).ToList();

            var winningHand = check
            .GroupBy(x => x.CardValue) // items with same CardValue are grouped together
            .Where(x => x.Count() >= 2) // filter groups where they have more than one member
            .ToList();

            return winningHand.Count() > 0;
        }
        public void Checkwin()
        {
            if (checkHand(player1, table)) { Console.WriteLine(player1.Name + " Won "); gameContinues = false; }
            if (checkHand(player2, table)) { Console.WriteLine(player2.Name + " Won "); gameContinues = false; }


        }

    }
}


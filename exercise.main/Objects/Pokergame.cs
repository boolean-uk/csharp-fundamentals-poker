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
        List<Card> table = new List<Card>();
        public Pokergame(string namePlayer1, string namePlayer2) {
            player1.Name = namePlayer1;
            player2.Name = namePlayer2;
        }

        

        public void Start()
        {
            deck.Shuffle();
            for (int i = 0; i < 2; i++) { player1.Draw(deck.Deal());player2.Draw(deck.Deal()); }
        }
        public void Deal() 
        {
            player1.Draw(deck.Deal()); player2.Draw(deck.Deal());
        }
        public bool checkWin(Player player) {
            List<Card> playerHand = player.GetHand();


            var winningHand = playerHand
            .GroupBy(x => x.CardValue) // items with same CardValue are grouped together
            .Where(x => x.Count() > 1); // filter groups where they have more than one member

            if (winningHand != null)
            {
                return true;
            }
            return false;
        }

    }
}


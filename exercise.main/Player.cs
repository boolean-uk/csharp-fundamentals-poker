using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Player
    {
        private string _name;
        private List<Card> _cards = new List<Card>();
        private int id;
        public Player()
        {

        }
        public void getPlayerName(Player player, int ID)
        {
            Console.Clear();
            Console.WriteLine($"Player {ID+1}, what is your name?");
            Name = Console.ReadLine();
        }
        public void showCards()
        {
            Console.Clear();
            Console.WriteLine($"{Name}, your cards are:\n");
            foreach(Card card in _cards) { Console.Write($"{card.Value}{card.Suit} "); }
        }
        public void clearCards(Player player)
        {
            player.Cards.Clear();
        }
        public string Name { get { return _name; } set {  _name = value; } }
        public List<Card> Cards { get { return _cards; } set { _cards = value; } }

        public int Id { get { return id; } set { id = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.UngradedExtension
{
    public class Table
    {
        List<Card> cards;
        public Table() 
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
            Console.WriteLine("Added " + card.ToString() + " to the table");
        }

        public void clearTable()
        {
            cards.Clear();
        }

        public void PrintTable()
        {
            Console.WriteLine("Table cards:");
            cards.ForEach(x => x.PrintCard());
        }
    } 
}

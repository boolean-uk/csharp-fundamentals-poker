using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card
    {
        public string cardName;
        public string cardType;
        public int cardValue;

        public string FullName()
        {
            return cardName + " of " + cardType;
        }
        public Card(string name, string type)
        {
            cardName = name;
            cardType = type;

            cardValue = 0;
            switch(name)
            {
                case "2":
                    cardValue = 2;
                    break;
                case "3":
                    cardValue = 3;
                    break;
                case "4":
                    cardValue = 4;
                    break;
                case "5":
                    cardValue = 5;
                    break;
                case "6":
                    cardValue = 6;
                    break;
                case "7":
                    cardValue = 7;
                    break;
                case "8":
                    cardValue = 8;
                    break;
                case "9":
                    cardValue = 9;
                    break;
                case "10":
                    cardValue = 10;
                    break;
                case "J":
                    cardValue = 11;
                    break;
                case "Q":
                    cardValue = 12;
                    break;
                case "K":
                    cardValue = 13;
                    break;
                case "A":
                    cardValue = 14;
                    break;
            }
        }
    }
}
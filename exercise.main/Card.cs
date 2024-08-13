using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card
    {
        public int cardValue = 0; // 2-A
        public string color = string.Empty; // spade, diamond, club or heart
        public string face = string.Empty; // 2 3 4 5 6 7 8 9 10 J Q K A

        public string RepresentCard() //returns a nice looking representation of the card
        {
            string theCard = this.face + " of " + this.color;

        

            return theCard;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card
    {
        public Card(char suit, int value)
        {
            mCard = new Tuple<char, int>(suit, value);
        }
        public Tuple<char, int> mCard { get; set; }
    }
}

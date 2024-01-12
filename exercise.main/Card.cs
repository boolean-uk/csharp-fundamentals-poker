using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Card
    {
        public string _suit { get; set; }

        public string _value { get; set; }

        public Card(string suit, string value)
        {
            _suit = suit;
            _value = value;
        }


    }
}

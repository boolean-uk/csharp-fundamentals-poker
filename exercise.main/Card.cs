﻿namespace exercise.main
{
    public class Card
    {
        public string value { get; set; }
        public string suit { get; set; }

        public Card(string value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }
    }
}

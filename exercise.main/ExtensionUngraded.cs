using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ExtensionUngraded
    {

        class Card {
            public int cardValue;
            public string cardSuit;
        
        }

        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> cardValue = new Dictionary<string, int>()
            {
                {"2", 2 },
                {"3", 3 },
                {"4", 4 },
                {"5", 5 },
                {"6", 6 },
                {"7", 7 },
                {"8", 8 },
                {"9", 9 },
                {"10", 10},
                {"J", 11 },
                {"Q", 12 },
                {"K", 13 },
                {"A", 14 }
            };

            if (cardValue.ContainsKey(card))
            {
                return cardValue[card];
            }
            return 0;
        }

        public string GetCardFromValue(int card)
        {
            Dictionary<int, string> cardValue = new Dictionary<int, string>()
            {
                {2, "2" },
                {3, "3" },
                {4, "4" },
                {5, "5" },
                {6, "6" },
                {7, "7" },
                {8, "8" },
                {9, "9" },
                {10, "10"},
                {11, "J" },
                {12, "Q" },
                {13, "K" },
                {14, "A" }
            };

            if (cardValue.ContainsKey(card))
            {
                return cardValue[card];
            }
            return "Error";
        }
    }

}

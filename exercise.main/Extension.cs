﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);

            List<PlayerHand> allPlayers = createPlayers(hand);

            int higestPair = -1;
            for (int i = 0; i < allPlayers.Count(); i++)
            {
                var player = allPlayers.ElementAt(i);
                if (player.threePair == true && higestPair < player.higestCardValue)
                {
                    higestPair = player.higestCardValue;
                }
            }

            if (higestPair != -1)
            {
                string maxCard = GetCardFromValue(higestPair);
                result = new Tuple<string, string, string>(maxCard, maxCard, maxCard);
                return true;
            }

            return false;
        }



        struct PlayerHand()
        {
            public bool threePair = false;
            public int higestCardValue = 0;
        }

        private List<PlayerHand> createPlayers(IEnumerable<Tuple<string, string, string>> hand)
        {
            List<PlayerHand> allPlayers = new List<PlayerHand>();
            for (int i = 0; i < hand.Count(); i++)
            {
                PlayerHand player = new PlayerHand();
                int cardOne = GetValueOfCard(hand.ElementAt(i).Item1);
                int cardTwo = GetValueOfCard(hand.ElementAt(i).Item2);
                int cardThree = GetValueOfCard(hand.ElementAt(i).Item3);

                int tempHigestValue = Math.Max(cardOne, cardTwo);
                player.higestCardValue = Math.Max(tempHigestValue, cardThree);

                if (cardOne == cardTwo && cardOne == cardThree) player.threePair = true;

                allPlayers.Add(player);
            }
            return allPlayers;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {


        //TODO: complete the following method, keeping the signature the same
        public bool winningPair1(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            bool hand1pair = false;
            bool hand2pair = false;
            bool isWinningHand = false;

            result = new Tuple<string, string>(string.Empty, string.Empty);

            //Check if the first players hand is a pair
            if (GetValueOfCard(hand.First().Item1) == GetValueOfCard(hand.First().Item2))
            {
                hand1pair = true;
            }
            //Check if the second players hand is a pair
            if (GetValueOfCard(hand.Last().Item1) == GetValueOfCard(hand.Last().Item2))
            {
                hand2pair = true;
            }

            //If first players hand is pair and second player does not have a pair, player one wins
            if (hand1pair && !hand2pair)
            {
                result = hand.First();
                isWinningHand = true;
            }

            //If second players hand is a pair and first player does not have a payer two wins
            if (!hand1pair && hand2pair)
            {
                result = hand.Last();
                isWinningHand = true;
            }

            //If both players hev a pair, calculate the sum of the integer values of both pairs and return the winner with the highest pair
            if (hand1pair && hand2pair)
            {
                int hand1val = GetValueOfCard(hand.First().Item1) + GetValueOfCard(hand.First().Item2);
                int hand2val = GetValueOfCard(hand.Last().Item1) + GetValueOfCard(hand.Last().Item2);
                isWinningHand = true;
                result = hand1val > hand2val ? hand.First() : hand.Last();
            }






            return isWinningHand;
        }

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {

            bool isWinningHand = false;
            int value = 0;
            result = new Tuple<string, string>("", "");
            //find pairs
            foreach (var pair in hand)
            {
                if (GetValueOfCard(pair.Item1) == GetValueOfCard(pair.Item2))
                {
                    int pairVal = GetValueOfCard(pair.Item2) + GetValueOfCard(pair.Item1);
                    if (pairVal > value)
                    {
                        value = pairVal;
                        result = pair;
                        isWinningHand = true;
                    }
                }
            }






            return isWinningHand;
        }
        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> valueCard = new();
            valueCard.Add("2", 2);
            valueCard.Add("3", 3);
            valueCard.Add("4", 4);
            valueCard.Add("5", 5);
            valueCard.Add("6", 6);
            valueCard.Add("7", 7);
            valueCard.Add("8", 8);
            valueCard.Add("9", 9);
            valueCard.Add("10", 10);
            valueCard.Add("J", 11);
            valueCard.Add("Q", 12);
            valueCard.Add("K", 13);
            valueCard.Add("A", 14);

            if (valueCard.ContainsKey(card))
            {
                return valueCard[card];
            }
            else
            {
                return -1;
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension {

    Dictionary<string, int> _cardValueMap;

    public Extension()
    {
        _cardValueMap = new Dictionary<string, int>();
        _cardValueMap = initCardValueMap(_cardValueMap);
    }
    //TODO: complete the following method, keeping the signature the same
    public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
    {
        result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
        int winningHandValue = 0;
        foreach (Tuple<string, string, string> cardPair in hand)
        {
            if (GetValueOfCard(cardPair.Item1) == GetValueOfCard(cardPair.Item2) && GetValueOfCard(cardPair.Item1) == GetValueOfCard(cardPair.Item3))
                {
                if (GetValueOfCard(cardPair.Item1) > winningHandValue)
                {
                    result = new Tuple<string, string, string>(cardPair.Item1, cardPair.Item2, cardPair.Item3);
                    winningHandValue = GetValueOfCard(cardPair.Item1);
                }

            }
        }

        return result.Item1 != string.Empty ? true : false;
    }
    public int GetValueOfCard(string card)
    {
        return _cardValueMap[card];
    }

    public Dictionary<string, int> initCardValueMap(Dictionary<string, int> dict)
    {
        dict.Add("2", 2);
        dict.Add("3", 3);
        dict.Add("4", 4);
        dict.Add("5", 5);
        dict.Add("6", 6);
        dict.Add("7", 7);
        dict.Add("8", 8);
        dict.Add("9", 9);
        dict.Add("10", 10);
        dict.Add("J", 11);
        dict.Add("Q", 12);
        dict.Add("K", 13);
        dict.Add("A", 14);

        return dict;
    }
}
}

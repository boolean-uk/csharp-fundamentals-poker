using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty);
            int card1, card2, value;
            List<Tuple<string, string, int>> players = new List<Tuple<string, string, int>>();
            Tuple<string, string, int> temp;
            foreach(var pair in hand)
            {
                card1 = GetValueOfCard(pair.Item1);
                card2 = GetValueOfCard(pair.Item2);
                if (card1 == card2)
                {
                    value = GetValueOfCard(pair.Item1);
                    temp = new Tuple<string, string, int>(pair.Item1,pair.Item2,value);
                    players.Add(temp);
                }
            }
            if(players.Count > 0)
            {
                int valueTemp = 0;
                foreach(var p in players)
                {
                    if (valueTemp < p.Item3)
                    {
                        valueTemp = p.Item3;
                        result = new Tuple<string, string>(p.Item1, p.Item2);
                    }
                }
            }
            return result.Item1 != string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> _cardValue = new Dictionary<string, int>();
            _cardValue.Add("1", 1);
            _cardValue.Add("2", 2);
            _cardValue.Add("3", 3);
            _cardValue.Add("4", 4);
            _cardValue.Add("5", 5);
            _cardValue.Add("6", 6);
            _cardValue.Add("7", 7);
            _cardValue.Add("8", 8);
            _cardValue.Add("9", 9);
            _cardValue.Add("10", 10);
            _cardValue.Add("J", 11);
            _cardValue.Add("Q", 12);
            _cardValue.Add("K", 13);
            _cardValue.Add("A", 14);
            if (_cardValue.ContainsKey(card))
            {
                return _cardValue[card];
            }
            return  0;           
        }
    }
}

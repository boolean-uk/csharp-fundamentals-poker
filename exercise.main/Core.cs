using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{

    public class Hand {
        private bool isWinning;

        private Tuple<int, int> values;

        private int score;

        public Hand(Tuple<int,int> hand) {
            values = hand;
            score = values.Item1 + values.Item2;
            isWinning = checkWinnings();
        }

        private bool checkWinnings() {
            if (values.Item1 == values.Item2)
                return true;
            return false;
        }

        public Tuple<string, string> getSym() {
            Dictionary<int, string> CardValues = new Dictionary<int, string>
            {
            { 11, "J"},
            { 12, "Q"},
            { 13, "K"},
            { 14, "A"}
            };
            
            if(values.Item1 == 11 || values.Item1 == 12 || values.Item1 == 13 || values.Item1 == 14)
                return new Tuple<string, string>(CardValues [values.Item1], CardValues[values.Item2]);
            return new Tuple<string, string>(values.Item1.ToString(), values.Item2.ToString());
        }

        public bool IsWinning
        {
            get { return isWinning; }
            set { isWinning = value; }
        }
        public Tuple<int,int> Values
        {
            get { return values; }
        }
        public int Score
        {
            get { return score; }
        }
    }

    public class Core
    {
       private bool isWinner;
        
        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            List<Hand> hands = new List<Hand>();

            foreach (Tuple<string,string> item in hand)
            {
                Tuple<int, int> temp = new Tuple<int, int>(GetValueOfCard(item.Item1), GetValueOfCard(item.Item2));
                Hand h = new Hand(temp);
                hands.Add(h);
            }

            int c = 0;
            int index = -1;
            int score = 0;
            foreach (Hand item in hands)
            {
                if (item.IsWinning) {
                    if(item.Score > score) {
                        score = item.Score;
                        index = c;
                    }
                }
                c++;
            }

            if (index != -1)
                result = hands[index].getSym();
            else
                result = new Tuple<string,string>(String.Empty, String.Empty);

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            Dictionary<string, int> CardValues = new Dictionary<string, int>
            {
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14}
            };

            if (CardValues.ContainsKey(card))
                return CardValues[card];
            try {            
                return Int32.Parse(card);
            } catch (Exception e) {
                return 0;
            }

        }
    }
}

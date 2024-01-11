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
        private Dictionary<string, int> cards;
        
        
        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);

            List<Tuple<Tuple<string, string>, int>> playersWithPairs;
            Tuple<Tuple<string, string>, int> playerWithPair;

            
            playersWithPairs = new List<Tuple<Tuple<string, string>, int>>();

            foreach (var pair in hand)
            {
                if(pair.Item1 == pair.Item2)
                {
                    int pairValue = GetValueOfCard(pair.Item1);
                    playerWithPair = new Tuple<Tuple<string, string>, int>(pair,pairValue);
                    playersWithPairs.Add(playerWithPair);
                    
                    result = FindHighestCard(playersWithPairs);
                    
                }
                else
                {
                    continue;
                }
            }
          

          

            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            cards = new Dictionary<string, int>();

            cards.Add("2", 2);
            cards.Add("3", 3);
            cards.Add("4", 4);
            cards.Add("5", 5);
            cards.Add("6", 6);
            cards.Add("7", 7);
            cards.Add("8", 8);
            cards.Add("9", 9);
            cards.Add("10", 10);
            cards.Add("J", 11);
            cards.Add("Q", 12);
            cards.Add("K", 13);
            cards.Add("A", 14);

            if (cards.ContainsKey(card))
            {
                return cards[card];
            } 
            else
            {
                return 0;
            }
                
                       
        }

        public Tuple<string,string> FindHighestCard(List<Tuple<Tuple<string, string>, int>> playersWithPairs)
        {
            Tuple<Tuple<string, string>, int> tempWinningPlayer = playersWithPairs.First();
            
            int winningPlayerValue = 0;
            foreach (var player in playersWithPairs) 
            {
                if (player.Item2 > winningPlayerValue) 
                {
                    winningPlayerValue = player.Item2;
                    tempWinningPlayer = player;
                }
                
            }
            return tempWinningPlayer.Item1;
        }

        public Tuple<string, string, string> FindHighestCard(List<Tuple<Tuple<string, string, string>, int>> playersWithPairs)
        {
            Tuple<Tuple<string, string, string>, int> tempWinningPlayer = playersWithPairs.First();

            int winningPlayerValue = 0;
            foreach (var player in playersWithPairs)
            {
                if (player.Item2 > winningPlayerValue)
                {
                    winningPlayerValue = player.Item2;
                    tempWinningPlayer = player;
                }

            }
            return tempWinningPlayer.Item1;
        }
    }
}

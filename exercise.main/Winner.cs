using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Schema;

namespace exercise.main
{
    /// <summary>
    /// Input: Every hand of cards. == List of players and Table
    /// Output: The winning player
    /// 
    /// </summary>
    public class Winner
    {
        List<Player> _players = new List<Player>();
        List<Card> _flop = new List<Card>();
        Core core = new Core();

        public Player DetermineWinner(List<Player> players, List<Card> flop)
        {
            _flop = flop;
            Player winner = null;
            int highestScore = 0;
            foreach (Player player in players)
            {
                if (!player.IsPlaying) continue;
                int score = Score(player.Hand, _flop);
                if (score > highestScore)
                {
                    winner = player;
                    highestScore = score;
                }

            }
            return winner;

        }

        
        public List<List<Card>> AllCombinations(List<Card> hand, List<Card> table)
        {
            List<List<Card>> result = [];
          //  List<Card> duplicate = new List<Card>(table);
            Card[] combi = new Card[5];

            foreach (Card handCard in hand)
            {
                combi[0] = handCard;
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        combi[i] = table[(i + j) % 5];
                    }
                    result.Add(combi.ToList());
                }
            }
            combi[0] = hand[0];
            combi[1] = hand[1];
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j ++)
                {
                    for (int k = j+1; k < 5; k++)
                    {
                        combi[2] = table[i];
                        combi[3] = table[j];
                        combi[4] = table[k];
                        result.Add(combi.ToList());
                    }
                }
            }

            return result;
        }
         

        /// <summary>
        /// Calculates the score out of  cards
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int Score(List<Card> hand, List<Card> _flop)
        {
            List<List<Card>> allCombos = AllCombinations(hand, _flop);
            int PlayerScore = 0;
            //For each combination of cards, check the value
            foreach (List<Card> combo in allCombos)
            {
                if (RoyalFlush(combo) > 0)
                {
                    PlayerScore = RoyalFlush(combo);
                    continue;
                }
                if (PlayerScore < 900 && StraightFlush(combo) > PlayerScore)
                {
                    PlayerScore = StraightFlush(combo);
                    continue;
                }
                if (PlayerScore < 800 && FourOfAKind(combo) > PlayerScore)
                {
                    PlayerScore = FourOfAKind(combo);
                    continue;
                }
                if (PlayerScore < 700 && FullHouse(combo) > PlayerScore)
                {
                    PlayerScore = FullHouse(combo);
                    continue;
                }
                if (PlayerScore < 600 && Flush(combo) > PlayerScore)
                {
                    PlayerScore = Flush(combo);
                    continue;
                }

                if (PlayerScore < 500 && Straight(combo) > PlayerScore)
                {
                    PlayerScore = Straight(combo);
                    continue;
                }
                if (PlayerScore < 400 && ThreeOfAKind(combo) > PlayerScore)
                {
                    PlayerScore = ThreeOfAKind(combo);
                    continue;
                }
                if (PlayerScore < 300 && TwoPairs(combo) > PlayerScore)
                {
                    PlayerScore = TwoPairs(combo);
                    continue;
                }
                if (PlayerScore < 200 && Pair(combo) > PlayerScore)
                {
                    PlayerScore = Pair(combo);
                    continue;
                }
                if (PlayerScore < 20 && HighCard(combo) > PlayerScore) 
                    PlayerScore = HighCard(combo);
            }

            return PlayerScore;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a royal flush. Returns 900 if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int RoyalFlush(List<Card> hand)
        {
            if (Flush(hand) > 0 && Straight(hand) == 414)
            {
                return 900;
            }
            return 0;
        }
        /// <summary>
        /// Takes 5 cards, determines whether it's a straight flush. Returns 800 + value of highest card if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int StraightFlush(List<Card> hand)
        {
            if (Flush(hand) > 0 && Straight(hand) > 0)
            {
                return Straight(hand) + 400;
            }
            return 0;
        }
        /// <summary>
        /// Takes 5 cards, determines whether it's a four of a kind. Returns 700 + value of the 4 of a kind if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int FourOfAKind(List<Card> hand)
        {
            IEnumerable<char> values = hand.SelectMany(x => x.Value).Distinct() ;
            if (values.Count() > 2) return 0;
            foreach (char card in values)
            {
                if (hand.Count(x => x.Value == card.ToString()) == 4) return 700 + core.GetValueOfCard(card.ToString());            
            }
            return 0;

        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a Full house. Returns 600 + value of triple card if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int FullHouse(List<Card> hand)
        {
            IEnumerable<char> values = hand.SelectMany(x => x.Value).Distinct();
            if (values.Count() > 2) return 0;
            foreach (char card in values)
            {
                if (hand.Count(x => x.Value == card.ToString()) == 3) return 600 + core.GetValueOfCard(card.ToString());
            }
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a flush. Returns 500 + total value of cards if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int Flush(List<Card> hand)
        {
        //    Console.WriteLine("Check for flush: " + hand.Count);
            int handValue = core.GetValueOfCard(hand[0].Value); 
            for (int i = 1; i < hand.Count; i++)
            {
         //       Console.WriteLine(hand[0].ToString() + "   " + hand[i].ToString());
                if (hand[0].Suit == hand[i].Suit) 
                    handValue += core.GetValueOfCard(hand[i].Value);
                else return 0;

            }
         //   Console.WriteLine("Flush found");
            return 500 + handValue;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a straight. Returns 400 + value of highest card if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int Straight(List<Card> hand)
        {
            List<int> values = new List<int>();
            foreach (Card card in hand)
            {
                values.Add(core.GetValueOfCard(card.Value));
            }
            values.Sort();
            if (values.Zip(values.Skip(1), (l, r) => l + 1 == r).All(t => t)) return 400 + values[4];
            else return 0;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a Three of a kind. Returns 300 + value of triple if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int ThreeOfAKind(List<Card> hand)
        {
            IEnumerable<char> values = hand.SelectMany(x => x.Value).Distinct();
            foreach (char card in values)
            {
                if (hand.Count(x => x.Value == card.ToString()) == 3) return 300 + core.GetValueOfCard(card.ToString());
            }
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's two pairs . Returns 200 + total value of both pairs if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int TwoPairs(List<Card> hand)
        {
            int pairs = 0;
            int valuePairs = 0;
            IEnumerable<char> values = hand.SelectMany(x => x.Value).Distinct();
            foreach (char card in values)
            {
                if (hand.Count(x => x.Value == card.ToString()) == 2)
                {
                    pairs++;
                    valuePairs += core.GetValueOfCard(card.ToString());
                }
                
            }
            if (pairs == 2) return 200 + valuePairs;
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a pair. Returns 100 + value of pair if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int Pair(List<Card> hand)
        {
            IEnumerable<char> values = hand.SelectMany(x => x.Value).Distinct();
            foreach (char card in values)
            {
                if (hand.Count(x => x.Value == card.ToString()) == 2) return 100 + core.GetValueOfCard(card.ToString());
            }
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, returns the value of the highest card.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int HighCard(List<Card> hand)
        {
            List<int> values = new List<int>();
            foreach (Card card in hand)
            {
                values.Add(core.GetValueOfCard(card.Value));
            }
            values.Sort();
            return values.Last();
        }
/*

        private int Duo(List<Card> hand)
        {
            int amountDuos = 0;
            Tuple<string, string> result;
            List<string> handValues = new List<string>();
            foreach (Card card in hand)
                handValues.Add(card.Value);
            if (core.winningPair((IEnumerable<Tuple<string, string>>)handValues.Zip(handValues.Skip(1)).Concat(handValues.Zip(handValues.Skip(2))).Concat(handValues.Zip(handValues.Skip(3))).Concat(handValues.Zip(handValues.Skip(4))), out result))
            {
                amountDuos++;
            }
            return amountDuos;
        }

        private bool Flush(List<Card> hand)
        {
            int diamonds = 0, spades = 0, hearts = 0, clubs = 0;
            foreach (Card card in hand)
            {
                if (card.Suit.Equals(Suit.Diamonds)) diamonds++;
                if (card.Suit.Equals(Suit.Spades)) spades++;
                if (card.Suit.Equals(Suit.Hearts)) hearts++;
                if (card.Suit.Equals(Suit.Clubs)) clubs++;
            }
            return diamonds >= 5 || spades >= 5 || hearts >= 5 || clubs >= 5;
        }
*/
    }

}

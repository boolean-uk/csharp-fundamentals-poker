using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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

        public Player DetermineWinner()
        {
            
            foreach (Player player in _players)
            {


            }
            return null;

        }

        
        public List<List<Card>> AllCombinations(List<Card> hand, List<Card> table)
        {
            List<List<Card>> result = [table];
            List<Card> duplicate = new List<Card>(table);
            foreach (Card handCard in hand)
            {
                foreach (Card tableCard in duplicate)
                {
                    table.Remove(tableCard);
                    table.Add(handCard);
                    result.Add(table);
                    table.Remove(handCard);
                    table.Add(tableCard);
                }
            }
            foreach (Card tableCard in duplicate)
            {
                table.Remove(tableCard);
                foreach (Card card in duplicate)
                {
                    table.Remove(card);
                    table.Concat(hand);
                    result.Add(table);
                    table.RemoveAll(hand.Contains);
                    table.Add(card);
                }
                table.Add(tableCard);
            }
            return result;
        }
         

        /// <summary>
        /// Calculates the score out of  cards
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private int Score(List<Card> hand)
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
                if (PlayerScore < 800 && StraightFlush(combo) > 0)
                {
                    PlayerScore = StraightFlush(combo);
                    continue;
                }
                if (PlayerScore < 700 && FourOfAKind(combo) > 0)
                {
                    PlayerScore = FourOfAKind(combo);
                    continue;
                }
                if (PlayerScore < 600 && FullHouse(combo) > 0)
                {
                    PlayerScore = FullHouse(combo);
                    continue;
                }
                if (PlayerScore < 500 && Flush(combo) > 0)
                {
                    PlayerScore = Flush(combo);
                    continue;
                }

                if (PlayerScore < 400 && Straight(combo) > 0)
                {
                    PlayerScore = Straight(combo);
                    continue;
                }
                if (PlayerScore < 300 && ThreeOfAKind(combo) > 0)
                {
                    PlayerScore = ThreeOfAKind(combo);
                    continue;
                }
                if (PlayerScore < 200 && TwoPairs(combo) > 0)
                {
                    PlayerScore = TwoPairs(combo);
                    continue;
                }
                if (PlayerScore < 100 && Pair(combo) > 0)
                {
                    PlayerScore = Pair(combo);
                    continue;
                }
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
            return 0;
        }
        /// <summary>
        /// Takes 5 cards, determines whether it's a straight flush. Returns 800 + value of highest card if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int StraightFlush(List<Card> hand)
        {
            return 0;
        }
        /// <summary>
        /// Takes 5 cards, determines whether it's a four of a kind. Returns 700 + value of the 4 of a kind if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int FourOfAKind(List<Card> hand)
        {
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a Full house. Returns 600 + value of highest card if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int FullHouse(List<Card> hand)
        {
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a flush. Returns 500 + total value of cards if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int Flush(List<Card> hand)
        {
            return 0;
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
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's two pairs . Returns 200 + total value of both pairs if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int TwoPairs(List<Card> hand)
        {
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, determines whether it's a pair. Returns 100 + value of pair if it is.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int Pair(List<Card> hand)
        {
            return 0;
        }

        /// <summary>
        /// Takes 5 cards, returns the value of the highest card.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public int HighCard(List<Card> hand)
        {
            return 0;
        }
/*
        private int Straight(List<Card> hand)
        {
            List<int> values = new List<int>();
            foreach (Card card in hand)
            {
                values.Add(core.GetValueOfCard(card.Value));
            }
            values.Sort();
            if (values.Zip(values.Skip(1), (l, r) => l + 1 == r).All(t => t)) return 900 + values[0];
            else return 0;
        }
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

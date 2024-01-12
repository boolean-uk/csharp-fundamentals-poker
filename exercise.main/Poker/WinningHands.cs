using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    public class WinningHands
    {
        private List<Action> _actions = new();
        private List<Card> _playerCommunityCards = new();
        private int _score = 0;

        public int IterateWinConditions(List<Card> playerCommunityCards)
        {
            _score = 0;
            _playerCommunityCards = playerCommunityCards;
            _actions = new()
            {
                // RoyalFlush,
                // StraightFlush,
                // FourOfAKind,
                // FullHouse,
                // Flush,
                // Straight,
                ThreeOfAKind,
                TwoPair,
                // Pair,
                // HighCard,
            };

            foreach (Action action in _actions)
            {
                action();
                if (_score != 0) // Break if score has changed
                {
                    break;
                }
            }

            return _score;
        }

        public int Score
        {
            get { return _score; }
        }

        private void RoyalFlush() {
            List<string> flushItems = [
                "10", "J", "Q", "K", "A"
            ];
            bool allEqualSuit = _playerCommunityCards
                .Select(x => x.Suit)
                .Distinct()
                .Count() == 1;
            bool hasFlush = _playerCommunityCards
                .Select(x => x.Value)
                .Intersect(flushItems)
                .Count() == flushItems.Count();
            if (allEqualSuit && hasFlush)
            {
                _score = 10;
            }
        }

        private void StraightFlush()
        {
            bool allEqualSuit = _playerCommunityCards.Select(x => x.Suit).Distinct().Count() == 1;
            // bool hasFlush = playerCommunityCards.Select(x => x.Value).Order(x => x.)
        }

        private void FourOfAKind()
        {
            throw new NotImplementedException();
        }

        private void FullHouse()
        {
            throw new NotImplementedException();
        }

        private void Flush()
        {
            throw new NotImplementedException();
        }

        private void Straight()
        {
            throw new NotImplementedException();
        }

        private void ThreeOfAKind()
        {
            var groupCards = _playerCommunityCards.GroupBy(x => x.Value);
            if (groupCards.Any(c => c.Count() == 3))
            {
                _score = 4;
            }
        }

        private void TwoPair()
        {
            var groupCards = _playerCommunityCards.GroupBy(x => x.Value);
            if (groupCards.Where(c => c.Count() == 2).Count() == 2)
            {
                _score = 3;
            }
        }

        private void Pair()
        {
            var groupCards = _playerCommunityCards.GroupBy(x => x.Value);
            if (groupCards.Any(c => c.Count() == 2))
            {
                _score = 2;
            }
        }

        private void HighCard()
        {
            throw new NotSupportedException();
        }
    }
}

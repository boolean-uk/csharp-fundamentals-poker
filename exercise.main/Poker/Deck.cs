using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Poker
{
    public class Deck
    {
        private List<Card> _cards;

        public void Shuffle()
        {
            _cards.OrderBy(x => Guid.NewGuid());
        }

        public void AddCard()
        {
            _cards.AddRange(_cards);
        }

        public bool IsEmpty()
        {
            return _cards.Count == 0;
        }

        public Card Deal()
        {
            Random random = new Random();
            Card returnedCard = _cards[random.Next(0, _cards.Count - 1)];
            _cards.Remove(returnedCard);
            return returnedCard;
        }

        public void GenerateCards(int amount)
        {
            _cards = new();
            Random random = new Random();
            var cardTypes = Card.valuePairs.Keys;
            for (int i = 0; i <= amount; i++)
            {
                string selectedType = cardTypes.ElementAt(random.Next(0, cardTypes.Count - 1));
                string selectedSuit = Card.suits.ElementAt(random.Next(0, Card.suits.Count - 1));
                _cards.Add(new Card(selectedType, selectedSuit));
            }
        }
    }
}

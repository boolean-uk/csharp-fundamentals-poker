using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.main.Models
{
    public class Deck
    {
        private List<Card> _cards;

        public List<Card> Cards { get => _cards; set => _cards = value; }

        // Shuffling / generating 52 standard decks size cards in the deck
        public void Shuffle() 
        { 
            var rnd = new Random();
            _cards = new List<Card>();
            for (int i = 0; i < 53; i++)
            {
                Card newCard = new Card();
                int generatedCardValue = rnd.Next(1, 15);

                bool numericValue = generatedCardValue > 0 && generatedCardValue < 11;
                if (!numericValue)
                {
                    switch (generatedCardValue)
                    {
                        case 11:
                            newCard.CardValue = "J";
                            break;
                        case 12:
                            newCard.CardValue = "Q";
                            break;
                        case 13:
                            newCard.CardValue = "K";
                            break;
                        case 14:
                            newCard.CardValue = "A";
                            break;
                    }
                }
                else
                {
                    newCard.CardValue = generatedCardValue.ToString();
                }

                int generatedSuitValue = rnd.Next(1, 5);

                switch (generatedSuitValue)
                {
                    case 1:
                        newCard.Suit = "Spades";
                        break;
                    case 2:
                        newCard.Suit = "Hearts";
                        break;
                    case 3:
                        newCard.Suit = "Clubs";
                        break;
                    case 4:
                        newCard.Suit = "Diamonds";
                        break;
                }

                Cards.Add(newCard);
            }
        }
        
        public void Deal()
        {
            var rnd = new Random();
            int cardToPick = rnd.Next(0, Cards.Count);

            Card card = Cards[cardToPick];
            Cards.RemoveAt(cardToPick);

            Console.WriteLine($"{card.CardValue} of {card.Suit}");
        }

        public int GetValueOfCard(string card)
        {
            bool isNumericCard = int.TryParse(card, out int cardNumber);

            if (isNumericCard)
            {
                return cardNumber;
            }
            else
            {
                switch (card)
                {
                    case "J":
                        return 11;
                    case "Q":
                        return 12;
                    case "K":
                        return 13;
                    case "A":
                        return 14;
                    default:
                        return 0;
                }
            }
        }
    }
}

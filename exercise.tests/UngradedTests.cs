using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class UngradedTests
    {
        [TestCase("4", "4", "H", "H")]
        [TestCase("4", "4", "S", "S")]
        [TestCase("10", "10", "C", "C")]
        [TestCase("Q", "Q", "D", "D")]
        [TestCase("A", "A", "H", "H")]
        public void testCard(string cardValue, string actualValue, string cardSuit, string actualSuit)
        {
            Card card = new Card(cardValue, cardSuit);

            string value = card.Value;
            string suit = card.Suit;

            Assert.That(value, Is.EqualTo(actualValue));
            Assert.That(suit, Is.EqualTo(actualSuit));
        }

        [Test]
        public void testDeckCreation()
        {
            Deck deck = new Deck();

            Assert.That(deck.Cards.Count, Is.EqualTo(52));
        }

        [Test]
        public void testDeckCreationValues()
        {
            Deck deck = new Deck();

            string[] suits = ["H", "C", "D", "S"];
            foreach (string suit in suits)
            {
                for (int i = 2; i < 13; i++)
                {
                    string j = i.ToString();
                    if (i == 11) j = "J";
                    else if (i == 12) j = "Q";
                    else if (i == 13) j = "K";
                    else if (i == 14) j = "A";

                    Card check = null;
                    foreach (Card card in deck.Cards)
                    {
                        if (card.Value == j && card.Suit == suit)
                        {
                            check = card;
                            break;
                        }
                    }
                    Assert.IsNotNull(check);
                }
            }
        }

        [Test]
        public void testDeckShuffleRandomization()
        {
            Deck firstDeck = new Deck();
            Deck secondDeck = new Deck();
            int totalEqual = 0;

            for (int i = 0; i < firstDeck.Cards.Count; i++)
            {
                for (int j = 0; j < secondDeck.Cards.Count; j++)
                {
                    Card firstCard = firstDeck.Cards[i];
                    Card secondCard = secondDeck.Cards[j];
                    if (firstCard.Value == secondCard.Value && firstCard.Suit == secondCard.Suit)
                    {
                        if (i == j)
                        {
                            totalEqual += 1;
                        }
                    }
                }
            }

            Assert.False(totalEqual == secondDeck.Cards.Count);
        }

        [Test]
        public void testDeckDealing()
        {
            Deck deck = new Deck();
            Card card = deck.Deal();

            Assert.That(deck.Cards.Count, Is.EqualTo(51));
            Assert.That(card.GetType(), Is.EqualTo(typeof(Card)));
            Assert.False(deck.Cards.Contains(card));
        }

        [Test]
        public void testDeckShuffleRegenerate()
        {
            Deck deck = new Deck();
            Card card = deck.Deal();

            deck.Shuffle();

            Assert.That(deck.Cards.Count, Is.EqualTo(52));
            Assert.False(deck.Cards.Contains(card));
        }


        [Test]
        public void testPlayerCreation()
        {
            Player player = new Player("Kristian");
            Assert.That(player.Name, Is.EqualTo("Kristian"));
            Assert.That(player.Hand.Count, Is.EqualTo(0));
            player = new Player("Nigel");
            Assert.That(player.Name, Is.EqualTo("Nigel"));
            Assert.That(player.Hand.Count, Is.EqualTo(0));

            List<Card> cards = new List<Card>();
            cards.Add(new Card("Q", "H"));
            cards.Add(new Card("J", "S"));
            cards.Add(new Card("3", "D"));

            player = new Player("Kristian", cards);
            Assert.That(player.Hand.Count, Is.EqualTo(3));

            player = new Player("Kristian", new Card("3", "S"));
            Assert.That(player.Hand.Count, Is.EqualTo(1));
        }

        [Test]
        public void testPlayerHandAdd()
        {
            Player player = new Player("Kristian");
            Card card = new Card("4", "H");

            player.Add(card);

            Assert.That(player.Hand.Count, Is.EqualTo(1));
            Assert.That(player.Hand[0].Value, Is.EqualTo(card.Value));
            Assert.That(player.Hand[0].Suit, Is.EqualTo(card.Suit));

            Card card2 = new Card("Q", "S");
            player.Add(card2);

            Assert.That(player.Hand.Count, Is.EqualTo(2));
            Assert.That(player.Hand[1].Value, Is.EqualTo(card2.Value));
            Assert.That(player.Hand[1].Suit, Is.EqualTo(card2.Suit));
        }

        [Test]
        public void testPlayerHandClear()
        {
            Player player = new Player("Kristian", new Card("7", "H"));

            player.Clear();

            Assert.That(player.Hand.Count, Is.EqualTo(0));
        }

        [Test]
        public void testPokerGameInitialization()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            Assert.True(pokerGame.Player1 != null);
            Assert.True(pokerGame.Player2 != null);
            Assert.That(pokerGame.Table.Count, Is.EqualTo(0));
            Assert.That(pokerGame.Player1.Hand.Count, Is.EqualTo(0));
            Assert.That(pokerGame.Player2.Hand.Count, Is.EqualTo(0));
        }

        [Test]
        public void testPokerGameInitState()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            pokerGame.initGame();

            Assert.That(pokerGame.Player1.Hand.Count, Is.EqualTo(2));
            Assert.That(pokerGame.Player2.Hand.Count, Is.EqualTo(2));
            Assert.That(pokerGame.Table.Count, Is.EqualTo(3));

            Assert.False(pokerGame.gameOver());
        }
        
        [Test]
        public void testScoreCalculationRoyalFlush()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> royalFlush = new List<Card>()
            {
                new Card("8", "H"), new Card("9", "H"), new Card("10", "H"), 
                new Card("J", "H"), new Card("Q", "H"), new Card("K", "H"),
                new Card("A", "H")
            };


            foreach (Card card in royalFlush)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("Royal Flush"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void testScoreCalculationStraightFlush()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> royalFlush = new List<Card>()
            {
                new Card("4", "H"), new Card("6", "H"), new Card("9", "H"),
                new Card("10", "H"), new Card("J", "H"), new Card("Q", "H"),
                new Card("K", "H")
            };

            foreach (Card card in royalFlush)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("Straight Flush"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void testScoreCalculationFlush()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> Flush = new List<Card>()
            {
                new Card("2", "H"), new Card("4", "H"), new Card("6", "H"),
                new Card("8", "H"), new Card("10", "H"), new Card("Q", "H"),
                new Card("A", "H")
            };


            foreach (Card card in Flush)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out _), Is.EqualTo("Flush"));
        }

        [Test]
        public void testScoreCalculationFourOfAKind()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> four = new List<Card>()
            {
                new Card("2", "H"), new Card("2", "S"), new Card("2", "D"),
                new Card("2", "C"), new Card("10", "H"), new Card("Q", "H"),
                new Card("A", "H")
            };


            foreach (Card card in four)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("Four of a Kind"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void testScoreCalculationFullHouse()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> fullHouse = new List<Card>()
            {
                new Card("2", "H"), new Card("2", "S"), new Card("2", "D"),
                new Card("4", "C"), new Card("10", "H"), new Card("10", "D"),
                new Card("A", "H")
            };

            foreach (Card card in fullHouse)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("Full House"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));

        }

        [Test]
        public void testScoreCalculationStraight()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> stright = new List<Card>()
            {
                new Card("2", "H"), new Card("3", "S"), new Card("4", "D"),
                new Card("5", "C"), new Card("6", "H"), new Card("10", "D"),
                new Card("A", "H")
            };


            foreach (Card card in stright)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("Straight"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void testScoreCalculationThreeOfAKind()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> three = new List<Card>()
            {
                new Card("2", "H"), new Card("2", "S"), new Card("2", "D"),
                new Card("5", "C"), new Card("6", "H"), new Card("10", "D"),
                new Card("A", "H")
            };


            foreach (Card card in three)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("Three of a Kind"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void testScoreCalculationTwoPairs()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> twoPairs = new List<Card>()
            {
                new Card("2", "H"), new Card("2", "S"), new Card("4", "D"),
                new Card("4", "C"), new Card("6", "H"), new Card("10", "D"),
                new Card("A", "H")
            };


            foreach (Card card in twoPairs)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("Two Pairs"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void testScoreCalculationPair()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> pair = new List<Card>()
            {
                new Card("2", "H"), new Card("2", "S"), new Card("3", "D"),
                new Card("4", "C"), new Card("6", "H"), new Card("10", "D"),
                new Card("A", "H")
            };


            foreach (Card card in pair)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("One Pair"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void testScoreCalculationHigh()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> high = new List<Card>()
            {
                new Card("2", "H"), new Card("3", "S"), new Card("4", "D"),
                new Card("5", "C"), new Card("7", "H"), new Card("10", "D"),
                new Card("A", "H")
            };

            foreach (Card card in high)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));
            Player winningHand;
            Assert.That(pokerGame.calcScore(pokerGame.Player1.Hand, out winningHand), Is.EqualTo("High Card"));
            Assert.That(winningHand.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void testWinner()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            string outcome = pokerGame.getWinner("High Card", "Flush");

            Assert.That(outcome, Is.EqualTo("Player 2"));

            outcome = pokerGame.getWinner("Flush", "Flush");

            Assert.That(outcome, Is.EqualTo("TIE"));

            outcome = pokerGame.getWinner("Straight Flush", "Flush");

            Assert.That(outcome, Is.EqualTo("Player 1"));
        }
    }
}

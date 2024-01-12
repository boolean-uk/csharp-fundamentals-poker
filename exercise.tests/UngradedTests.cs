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
        [TestCase("4", "4", "hearts", "hearts")]
        [TestCase("4", "4", "spades", "spades")]
        [TestCase("10", "10", "clubs", "clubs")]
        [TestCase("Q", "Q", "diamonds", "diamonds")]
        [TestCase("A", "A", "hearts", "hearts")]
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

            string[] suits = ["hearts", "clubs", "diamonds", "spades"];
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
            cards.Add(new Card("Q", "hearts"));
            cards.Add(new Card("J", "spades"));
            cards.Add(new Card("3", "diamonds"));

            player = new Player("Kristian", cards);
            Assert.That(player.Hand.Count, Is.EqualTo(3));

            player = new Player("Kristian", new Card("3", "spades"));
            Assert.That(player.Hand.Count, Is.EqualTo(1));
        }

        [Test]
        public void testPlayerHandAdd()
        {
            Player player = new Player("Kristian");
            Card card = new Card("4", "hearts");

            player.Add(card);

            Assert.That(player.Hand.Count, Is.EqualTo(1));
            Assert.That(player.Hand[0].Value, Is.EqualTo(card.Value));
            Assert.That(player.Hand[0].Suit, Is.EqualTo(card.Suit));

            Card card2 = new Card("Q", "spades");
            player.Add(card2);

            Assert.That(player.Hand.Count, Is.EqualTo(2));
            Assert.That(player.Hand[1].Value, Is.EqualTo(card2.Value));
            Assert.That(player.Hand[1].Suit, Is.EqualTo(card2.Suit));
        }

        [Test]
        public void testPlayerHandClear()
        {
            Player player = new Player("Kristian", new Card("7", "hearts"));

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
        public void testPokerGame()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            pokerGame.startGame();

            Assert.That(pokerGame.Player1.Hand.Count, Is.EqualTo(7));
            Assert.That(pokerGame.Player2.Hand.Count, Is.EqualTo(7));
            Assert.That(pokerGame.Table.Count, Is.EqualTo(5));

            Assert.True(pokerGame.gameOver());
        }
        
        [Test]
        public void testScoreCalculationStraightFlush()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> royalFlush = new List<Card>()
            {
                new Card("8", "hearts"), new Card("9", "hearts"), new Card("10", "hearts"), 
                new Card("J", "hearts"), new Card("Q", "hearts"), new Card("K", "hearts"),
                new Card("A", "hearts")
            };


            foreach (Card card in royalFlush)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("STRAIGHT-FLUSH"));
        }

        [Test]
        public void testScoreCalculationFlush()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> flush = new List<Card>()
            {
                new Card("2", "hearts"), new Card("4", "hearts"), new Card("6", "hearts"),
                new Card("8", "hearts"), new Card("10", "hearts"), new Card("Q", "hearts"),
                new Card("A", "hearts")
            };


            foreach (Card card in flush)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("FLUSH"));
        }

        [Test]
        public void testScoreCalculationFourOfAKind()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> four = new List<Card>()
            {
                new Card("2", "hearts"), new Card("2", "spades"), new Card("2", "diamonds"),
                new Card("2", "clubs"), new Card("10", "hearts"), new Card("Q", "hearts"),
                new Card("A", "hearts")
            };


            foreach (Card card in four)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("FOUR"));
        }

        [Test]
        public void testScoreCalculationFullHouse()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> fullHouse = new List<Card>()
            {
                new Card("2", "hearts"), new Card("2", "spades"), new Card("2", "diamonds"),
                new Card("4", "clubs"), new Card("10", "hearts"), new Card("10", "diamonds"),
                new Card("A", "hearts")
            };


            foreach (Card card in fullHouse)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("FULL"));
        }

        [Test]
        public void testScoreCalculationStraight()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> stright = new List<Card>()
            {
                new Card("2", "hearts"), new Card("3", "spades"), new Card("4", "diamonds"),
                new Card("5", "clubs"), new Card("6", "hearts"), new Card("10", "diamonds"),
                new Card("A", "hearts")
            };


            foreach (Card card in stright)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("STRAIGHT"));
        }

        [Test]
        public void testScoreCalculationThreeOfAKind()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> three = new List<Card>()
            {
                new Card("2", "hearts"), new Card("2", "spades"), new Card("2", "diamonds"),
                new Card("5", "clubs"), new Card("6", "hearts"), new Card("10", "diamonds"),
                new Card("A", "hearts")
            };


            foreach (Card card in three)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("THREE"));
        }

        [Test]
        public void testScoreCalculationTwoPairs()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> twoPairs = new List<Card>()
            {
                new Card("2", "hearts"), new Card("2", "spades"), new Card("4", "diamonds"),
                new Card("4", "clubs"), new Card("6", "hearts"), new Card("10", "diamonds"),
                new Card("A", "hearts")
            };


            foreach (Card card in twoPairs)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("TWO-PAIRS"));
        }

        [Test]
        public void testScoreCalculationPair()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> pair = new List<Card>()
            {
                new Card("2", "hearts"), new Card("2", "spades"), new Card("3", "diamonds"),
                new Card("4", "clubs"), new Card("6", "hearts"), new Card("10", "diamonds"),
                new Card("A", "hearts")
            };


            foreach (Card card in pair)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("PAIR"));
        }

        [Test]
        public void testScoreCalculationHigh()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            List<Card> high = new List<Card>()
            {
                new Card("2", "hearts"), new Card("3", "spades"), new Card("4", "diamonds"),
                new Card("5", "clubs"), new Card("7", "hearts"), new Card("10", "diamonds"),
                new Card("A", "hearts")
            };

            foreach (Card card in high)
            {
                pokerGame.Player1.Add(card);
            }

            Assert.That(pokerGame.Player1.Hand.Count(), Is.EqualTo(7));

            Assert.That(pokerGame.calcScore(pokerGame.Player1), Is.EqualTo("HIGH"));
        }

        [Test]
        public void testWinner()
        {
            PokerGame pokerGame = new PokerGame("Kristian", "Nigel");

            string outcome = pokerGame.getWinner("HIGH", "FLUSH");

            Assert.That(outcome, Is.EqualTo("PLAYER2"));

            outcome = pokerGame.getWinner("FLUSH", "FLUSH");

            Assert.That(outcome, Is.EqualTo("TIE"));

            outcome = pokerGame.getWinner("STRAIGHT-FLUSH", "FLUSH");

            Assert.That(outcome, Is.EqualTo("PLAYER1"));
        }
    }
}

using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    internal class UngradedExtensionsTests
    {
        [Test]
        public void testShuffleAndDeal()
        {
            Deck deck = new Deck();
            Deck deck1 = new Deck();
            Player player1 = new Player("John");
            Player player2 = new Player("Jane");

            deck.shuffle();
            player1.draw(deck.deal());
            player1.draw(deck.deal());

            player2.draw(deck1.deal());
            player2.draw(deck1.deal());

            Assert.IsFalse(player1.viewCards()[0] == player2.viewCards()[0] &&
                player1.viewCards()[1] == player2.viewCards()[1]);
        }
    }
}

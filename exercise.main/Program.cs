// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("STARTING POKER GAME");

Deck deck = new Deck();
deck.Shuffle();

PokerGame game = new PokerGame();
game.setTable();

game.dealCards();
game.dealCards();

game.showCards();
game.checkVictory();
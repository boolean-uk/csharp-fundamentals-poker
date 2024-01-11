# C# Poker Challenge

Welcome to the Poker challenge!

## Learning Objectives
- Build a simple program using classes, functions, loops, and flow control
- Use `git` & GitHub to commit work and open a Pull Request

## Instructions

1. Fork this repository and then:
2. Run the tests from the Test Explorer. There should be a lot of failures to begin with.
3. In GitHub, [open a Pull Request](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request) from your forked repository to the challenge repository.
4. Implement the criteria below locally and [push your code](https://docs.github.com/en/github/managing-files-in-a-repository/adding-a-file-to-a-repository-using-the-command-line) to your repository! Every push to a branch that has an open Pull Request will update it automatically with your changes.
5. Check the status of the automated tests on the Pull Request - update your implementation if needed.

# Basics
The exercise is based on poker.  Pairs of cards in a collection (hand) are winners if they are the match and are have the highest value in the hand.  

All cards have a numeric value, number cards having their face value, Jack=11, Queen=12, King=13 Ace=13.

This exercises uses Tuples, a lightweight type for storing, specifically a Tuple<string,string> which can be thought as a pair of strings to represent each card in the pair.

# Core Task
Given two hands of cards, return true if there is a winning hand and return it. A winning hand is one where both cards are the same value. If more than one hand is a pair of matching cards, then the highest pair must win.

If none of the hands is a pair, then just return false and an empty string tuple.

## Extension Task
Given hands of three cards, calculate the winning hand when the hand is a triplet of three cards of the same value. If none of the hands are a triplet, return false and an empty string tuple.

# Ungraded Extension

Simulate using different classes a Game of Texas Hold'em poker.

Requirements:
- Implement a `Card` class that stores the card value (1, 2, 3 ... J, Q, K) and the suit (spades, hearts, etc...)
- Implement a `Deck` class that stores a list / dictionary / array of `Card` objects
    - The `Deck` should have a method to `Shuffle()` / regenerate the deck
    - The `Deck` should have a method to `Deal()` one card from the deck, removing it from the list of cards in the deck
- Implement a `Player` class that stores the Name of the player and a list of cards that the player has in their hand. The class should have a method for adding 1 card to the hand; a method to clear the cards in the hand; a method for returning what cards are in the hand.
- Implement a `PokerGame` class. This class should create 2 `Players` and a `Deck`; this class should have different methods as required to start a game; check if anyone has won; store a list of cards on the table; and functions to progress from the start of a Poker round until a player has won (5 cards have been dealt).
- Write some code in `Program.cs` to run a full simulation of a round of Poker which involves resetting a deck, clearing the player's hands; dealing 2 cards to each player + 3 cards on the table; then dealing 2 more cards onto the table and finally computing the winner of that round. Your code should clearly print out messages about each stage and display the player's hands, the tables cards and the winner.
  
This is open ended, there are many ways to implement this.

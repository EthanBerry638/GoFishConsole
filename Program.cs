/* 
Layout planning

Goal: create a go fish game with a human controlled player and an ai
Main loop idea: Ask user if they want to play (if they've already played, change wording to play again)
Then if they dont want to play, close the main loop and the game. If they want to play start the game loop.
Execute go fish game loop. In game loop take user input on every turn. At the end of the game, print a message to say who won.
Then return to the main menu and loop.  

Keep program.cs short and simple using namespaces

Classes:
Player ()
AI ()
Cards (for deck of cards, shuffling etc)
Game manager (run game loop)
Menu manager (all menu functions and options)

Enums:
Game phase for dealing, playerturn, etc.
*/

using GoFish.Game;
using GoFish.GameCards;
using GoFish.Menu;
using GoFish.Players;

DeckManager deckManager = new DeckManager();
deckManager.GenerateDefaultDeck();
deckManager.ViewDeck();
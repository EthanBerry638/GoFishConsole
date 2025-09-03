﻿/* 
Layout planning

Goal: create a go fish game with a human controlled player and an ai
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
using GoFish.Menu;
using GoFish.Players;
using LeaderBoardManager;

MenuManager menuManager = GameInitializer.InitializeGame();
menuManager.MainLoop();
public class GameInitializer
{
    public static MenuManager InitializeGame()
    {
        Random sharedRandom = new Random();
        DeckManager deckManager = new DeckManager(sharedRandom);
        AI ai = new AI(deckManager, sharedRandom);
        Player player = new Player(deckManager, sharedRandom);
        TurnManager turnManager = new TurnManager(player, ai, deckManager, sharedRandom);
        GameManager gameManager = new GameManager(deckManager, player, ai, sharedRandom, turnManager);
        LeaderBoards leaderBoard = new LeaderBoards();
        return new MenuManager(gameManager, leaderBoard);
    }
}
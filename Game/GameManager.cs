using System.Security.AccessControl;
using System.Security.Cryptography;
using GoFish.GameCards;
using GoFish.HelperMethods;
using GoFish.Players;

namespace GoFish.Game
{
    public class GameManager(DeckManager deckManager, Player player, AI ai, Random sharedRandom, TurnManager turnManager)
    {
        private readonly Player _player = player;
        private readonly AI _ai = ai;
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;
        private readonly TurnManager _turnManager = turnManager;
        public void StartGame()
        {
            _deckManager.GenerateDefaultDeck();
            _player.CreateStartingHand();
            _ai.CreateStartingHand();

            _player.GetPlayerName();
            _ai.GetAIName();
        }

        public bool IsGameOver()
        {
            if (_deckManager.deck.Count == 0 && _player.PlayerHand.Count == 0 && _ai.AIHand.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void GameLoop()
        {
            // Set inital turn from a heads or tails
            HeadsOrTailsInput();
            if (HeadsOrTails())
            {
                _player.PlayerTurn = true;
            }
            else
            {
                _ai.AITurn = true;
            }
            while (!IsGameOver())
            {
                if (_player.IsHandEmpty())
                {
                    _player.RefillHandToCount(_player.PlayerHand, 5);
                }
                else if (_ai.IsHandEmpty())
                {
                    _ai.RefillHandToCount(_ai.AIHand, 5);
                }

                if (_player.PlayerTurn)
                    {
                        _turnManager.PlayerTurn();
                        if (_player.CheckForBooks() != Rank.None)
                        {
                            Console.WriteLine($"{_player.PlayerName} gets another turn!");
                            Utils.Pause(200);
                            _player.PlayerTurn = true;
                        }
                    }
                    else
                    {
                        _turnManager.AITurn();
                        if (_player.CheckForBooks() != Rank.None)
                        {
                            Console.WriteLine($"{_ai.AIName} gets another turn!");
                            Utils.Pause(200);
                            _ai.AITurn = true;
                        }
                    }
            }
        }

        private string HeadsOrTailsInput()
        {
            while (true)
            {
                string? coinFlipChoice;
                Console.WriteLine("A coin flip will be used to determine who gets the first turn!");
                Console.WriteLine("Do you pick heads or tails?");
                coinFlipChoice = Console.ReadLine();

                if (string.IsNullOrEmpty(coinFlipChoice))
                {
                    Console.WriteLine("Please enter something...");
                    continue;
                }

                coinFlipChoice = coinFlipChoice.Trim().ToLower();

                if (coinFlipChoice == "heads")
                {
                    return coinFlipChoice;
                }
                else if (coinFlipChoice == "tails")
                {
                    return coinFlipChoice;
                }
                else
                {
                    Console.WriteLine("Please enter 'heads' or 'tails'.");
                    Utils.Pause(500);
                }
            }
        }

        private bool HeadsOrTails()
        {
            int coinFlip = _sharedRandom.Next(0, 11);

            if (coinFlip <= 5)
            {
                Console.WriteLine("You guessed correctly! You go first!");
                return true;
            }

            Console.WriteLine("Unfortunately, you lost this coin flip...");
            return false;
        }
    }
}
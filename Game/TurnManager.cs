using GoFish.Players;
using GoFish.HelperMethods;
using GoFish.GameCards;
using Microsoft.VisualBasic;

namespace GoFish.Game
{
    public class TurnManager(Player player, AI ai, DeckManager deckManager, Random sharedRandom)
    {
        private readonly Player _player = player;
        private readonly AI _ai = ai;
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;
        public bool correctGuess;

        public void PlayerTurn()
        {
            correctGuess = false;
            Console.WriteLine("This is your current hand: ");
            _player.ViewHand();
            Console.WriteLine($"\nYour opponent has {_ai.AIHand.Count} cards in their current hand...\n");
            Utils.Pause(500);
            Console.WriteLine("Which rank do you want to guess they have? (1-10, Kings, Queens, Jacks, Aces)");
            Utils.Pause(400);
            var guessedRank = Rank.None;
            while (!_player.HasRank(guessedRank))
            {
                Console.WriteLine($"\nYou must ask for a rank you currently hold\n");
                Utils.Pause(200);
                guessedRank = GetPlayerInput();
            }
            var matchingCards = _ai.CheckHandRanks(guessedRank);
            correctGuess = matchingCards.Any();

            foreach (var card in matchingCards)
            {
                _ai.AIHand.Remove(card);
            }

            _player.PlayerHand.AddRange(matchingCards);


            if (correctGuess)
            {
                Console.WriteLine($"\n{_ai.AIName} has {matchingCards.Count} card(s) of rank {guessedRank}!");
            }
            else
            {
                Console.WriteLine($"\n{_ai.AIName} says Go Fish!");
                Utils.Pause(200);
                Card? card = _deckManager.DrawRandomCard();
                Console.WriteLine($"\nYou drew {card}!\n");
                Utils.Pause(1000);
                if (card != null)
                {
                    _player.PlayerHand.Add(card);
                }
            }
        }

        private Rank GetPlayerInput()
        {
            while (true)
            {
                string? playerInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(playerInput))
                    continue;

                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    if (playerInput == rank.ToString().ToLower())
                        return rank;
                }

                Console.WriteLine("\nPlease enter a valid rank. (Ace, Two, ..., King)\n");
                Utils.Pause(200);
            }
        }

        public void AITurn()
        {
            correctGuess = false;
            Console.WriteLine($"{_ai.AIName} is picking a rank...");
            Utils.Pause(500);

            var availableRanks = _ai.AIHand.Select(card => card.Rank).Distinct().ToList();
            Rank guessedRank = availableRanks[_sharedRandom.Next(availableRanks.Count)];
            Console.WriteLine($"{_ai.AIName} has guessed {guessedRank}! Checking your hand for any matching ranks...");
            var matchingCards = _player.CheckHandRank(guessedRank);
            correctGuess = matchingCards.Any();
            Utils.Pause(2500);

            foreach (var card in matchingCards)
            {
                _player.PlayerHand.Remove(card);
            }

            _ai.AIHand.AddRange(matchingCards);

            if (correctGuess)
            {
                Console.WriteLine($"\nYou had {matchingCards.Count} card(s) of rank {guessedRank}!");
            }
            else
            {
                Console.WriteLine($"\n{_ai.AIName} goes fish!\n");
                Utils.Pause(2500);
                Card? card = _deckManager.DrawRandomCard();
                if (card != null)
                {
                    _ai.AIHand.Add(card);
                }
            }
        }
    }
}
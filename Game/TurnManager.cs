using GoFish.Players;
using GoFish.HelperMethods;
using GoFish.GameCards;

namespace GoFish.Game
{
    public class TurnManager(Player player, AI ai, DeckManager deckManager, Random sharedRandom)
    {
        private readonly Player _player = player;
        private readonly AI _ai = ai;
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;

        public void PlayerTurn()
        {
            Console.WriteLine("This is your current hand: ");
            _player.ViewHand();
            Console.WriteLine($"Your opponent has {_ai.AIHand.Count} cards in their current hand...");
            Utils.Pause(500);
            Console.WriteLine("Which rank do you want to guess they have? (1-10, Kings, Queens, Jacks, Aces)");
            var guessedRank = GetPlayerInput();
            var matchingCards = _ai.CheckHandRanks(guessedRank);

            if (matchingCards.Any())
            {
                Console.WriteLine($"{_ai.AIName} has {matchingCards.Count} card(s) of rank {guessedRank}!");
            }
            else
            {
                Console.WriteLine("Go Fish!");
                Card? card = _deckManager.DrawRandomCard();
                if (card != null)
                {
                    _player.PlayerHand.Add(card);
                }
            }
            _ai.AITurn = true;
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

                Console.WriteLine("Please enter a valid rank. (Ace, Two, ..., King)");
            }
        }

        public void AITurn()
        {
            Console.WriteLine($"{_ai.AIName} is picking a rank...");
            Utils.Pause(500);
            int aiGuess = _sharedRandom.Next(0, 13);

            Rank guessedRank = _ai.GetRankFromInt(aiGuess) ?? throw new InvalidOperationException("Invalid rank value.");
            Console.WriteLine($"{_ai.AIName} has guessed {guessedRank}! Checking your hand for any matching ranks...");
            var matchingCards = _player.CheckHandRank(guessedRank);
            Utils.Pause(2500);

            if (matchingCards.Any())
            {
                Console.WriteLine($"You had {matchingCards.Count} card(s) of rank {guessedRank}!");
            }
            else
            {
                Console.WriteLine($"{_ai.AIName} goes fish!");
                Card? card = _deckManager.DrawRandomCard();
                if (card != null)
                {
                    _ai.AIHand.Add(card);
                }
            }

            _player.PlayerTurn = true;
        }
    }
}
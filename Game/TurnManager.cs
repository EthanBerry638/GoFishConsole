using GoFish.Players;
using GoFish.HelperMethods;
using GoFish.GameCards;

namespace GoFish.Game
{
    public class TurnManager(Player player, AI ai)
    {
        private readonly Player _player = player;
        private readonly AI _ai = ai;

        public void PlayerTurn()
        {
            Console.WriteLine("This is your current hand: ");
            _player.ViewHand();
            Console.WriteLine($"Your opponent has {ai.AIHand.Count} cards in their current hand...");
            Utils.Pause(500);
            Console.WriteLine("Which rank do you want to guess they have? (1-10, Kings, Queens, Jacks, Aces)");
            GetPlayerInput();
        }

        private Rank GetPlayerInput()
        {
            while (true)
            {
                Console.Write("Enter a rank (e.g., ace, two, king): ");
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

        }
    }
}
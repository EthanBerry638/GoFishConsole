using GoFish.Game;
using GoFish.GameCards;
using GoFish.HelperMethods;

namespace GoFish.Players
{
    public class Player(DeckManager deckManager, Random sharedRandom)
    {
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;
        private List<Card> PlayerHand = new List<Card>();

        public string? PlayerName { get; set; }

        public void CreateStartingHand()
        {
            for (int i = 0; i < 7; i++)
            {
                Card? card = _deckManager.DrawRandomCard();
                if (card != null)
                {
                    PlayerHand.Add(card);
                }
            }
        }

        public void ViewHand()
        {
            int count = 0;

            foreach (Card card in PlayerHand)
            {
                count += 1;
                Console.WriteLine($"{count}. {card}");
                Utils.Pause(200);
            }
        }

        public void GetPlayerName()
        {
            do
            {
                Console.WriteLine("Please enter your name. This will be used for the leaderboard (In development)");
                PlayerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(PlayerName))
                {
                    Console.WriteLine("Please enter something.");
                }
            } while (string.IsNullOrWhiteSpace(PlayerName));

            Console.WriteLine($"Welcome, {PlayerName}!");
        }
    }
}
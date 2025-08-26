using GoFish.Game;
using GoFish.GameCards;
using GoFish.HelperMethods;

namespace GoFish.Players
{
    public class Player(DeckManager deckManager, Random sharedRandom)
    {
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;
        public List<Card> PlayerHand = new List<Card>();

        public string? PlayerName { get; set; }

        public bool PlayerTurn = false;

        public int playerBooks = 0;

        private Dictionary<Rank, int> playerRanks = new Dictionary<Rank, int>();

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

        public List<Card> CheckHandRank(Rank rank)
        {
            return PlayerHand.Where(card => card.Rank == rank).ToList();
        }

        public Rank CheckForBooks()
        {
            for (int i = 0; i < PlayerHand.Count; i++)
            {
                Rank currentRank = PlayerHand[i].Rank;

                if (playerRanks.ContainsKey(PlayerHand[i].Rank))
                {
                    playerRanks[PlayerHand[i].Rank]++;
                }
                else
                {
                    playerRanks.Add(PlayerHand[i].Rank, 1);
                }

                if (playerRanks[PlayerHand[i].Rank] == 4)
                {
                    playerBooks += 1;
                    Console.WriteLine($"{PlayerName} got a book of {PlayerHand[i].Rank}! They now have {playerBooks} books!");
                    Utils.Pause(200);

                    PlayerHand.RemoveAll(card => card.Rank == currentRank);

                    return PlayerHand[i].Rank;
                }
            }

            return Rank.None;
        }

        public bool HasRank(Rank rank)
        {
            return PlayerHand.Any(card => card.Rank == rank);
        }
        
        public bool IsHandEmpty()
        {
            if (PlayerHand.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
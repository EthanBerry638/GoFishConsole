using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using GoFish.Game;
using GoFish.GameCards;
using GoFish.HelperMethods;

namespace GoFish.Players
{
    public class AI(DeckManager deckManager, Random sharedRandom)
    {
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;
        public List<Card> AIHand = new List<Card>();
        public bool AITurn = false;
        List<string> AINames = new List<string>
        {
            "Dave", "Bob", "ChatGPT", "John"
        };

        public int aiBooks = 0;

        public string? AIName { get; set; }

        private Dictionary<Rank, int> aiRanks = new Dictionary<Rank, int>();
        public bool CorrectGuess = false;

        public void CreateStartingHand()
        {
            for (int i = 0; i < 7; i++)
            {
                Card? card = _deckManager.DrawRandomCard();
                if (card != null)
                {
                    AIHand.Add(card);
                }
            }
        }

        public void ViewHand()
        {
            int count = 0;
            foreach (Card card in AIHand)
            {
                count += 1;
                Console.WriteLine($"{count}. {card}");
                Utils.Pause(200);
            }
        }

        public void GetAIName()
        {
            int index = AINames.Count();
            int chosenName = _sharedRandom.Next(index);
            AIName = AINames[chosenName];
        }

        public void ViewAIName()
        {
            Console.WriteLine($"The AI is called {AIName}");
        }

        public Rank? GetRankFromInt(int value)
        {
            if (Enum.IsDefined(typeof(Rank), value))
                return (Rank)value;
            return null;
        }

        public List<Card> CheckHandRanks(Rank rank)
        {
            return AIHand.Where(card => card.Rank == rank).ToList();
        }

        public Rank CheckForBooks()
        {
            Dictionary<Rank, int> rankCounts = new Dictionary<Rank, int>();

            foreach (Card card in AIHand)
            {
                if (rankCounts.ContainsKey(card.Rank))
                    rankCounts[card.Rank]++;
                else
                    rankCounts[card.Rank] = 1;
            }

            foreach (var pair in rankCounts)
            {
                if (pair.Value == 4)
                {
                    aiBooks++;
                    Console.WriteLine($"{AIName} got a book of {pair.Key}! They now have {aiBooks} books!");
                    Utils.Pause(200);

                    AIHand.RemoveAll(card => card.Rank == pair.Key);
                    return pair.Key;
                }
            }

            return Rank.None;
        }

        public bool IsHandEmpty()
        {
            if (AIHand.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void RefillHandToCount(List<Card> AIHand, int targetCount)
        {
            while (AIHand.Count < targetCount && _deckManager.deck.Count > 0)
            {
                Card? card = _deckManager.DrawRandomCard();
                if (card != null)
                {
                    AIHand.Add(card);
                }
            }

            Console.WriteLine($"Hand refilled to {AIHand.Count} card(s). Deck has {_deckManager.deck.Count} left.");
        }
    }
}
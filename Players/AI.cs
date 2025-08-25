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
            for (int i = 0; i < AIHand.Count; i++)
            {
                if (aiRanks.ContainsKey(AIHand[i].Rank))
                {
                    aiRanks[AIHand[i].Rank]++;
                }
                else
                {
                    aiRanks.Add(AIHand[i].Rank, 1);
                }

                if (aiRanks[AIHand[i].Rank] == 4)
                {
                    return AIHand[i].Rank;
                }
            }

            return Rank.None;
        }
    }
}
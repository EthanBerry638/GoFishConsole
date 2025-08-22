using System.Reflection.Metadata;
using GoFish.Game;
using GoFish.GameCards;
using GoFish.HelperMethods;

namespace GoFish.Players
{
    public class AI(DeckManager deckManager, Random sharedRandom)
    {
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;
        private List<Card> AIHand = new List<Card>();
        List<string> AINames = new List<string>
        {
            "Dave", "Bob", "ChatGPT", "John"
        };

        string? AIName { get; set; }

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
    }
}